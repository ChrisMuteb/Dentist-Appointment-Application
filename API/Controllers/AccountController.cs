using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){
            if(await PatientExists(registerDto.Email))
                return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var pat = new Patient{
                Email = registerDto.Email.ToLower(),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Gender = registerDto.Gender,
                PhoneNumber = registerDto.PhoneNumber,
                DateofBirth = registerDto.DateofBirth,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Patients.Add(pat);
            await _context.SaveChangesAsync();

            return new UserDto{
                Email = pat.Email,
                Token = _tokenService.CreateToken(pat)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto){
            var patient = await _context.Patients
                .SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if(patient == null) return Unauthorized("Invalid credential");

            using var hmac = new HMACSHA512(patient.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i=0; i < computedHash.Length; i++){
                if(computedHash[i] != patient.PasswordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDto{
                Email = patient.Email,
                Token = _tokenService.CreateToken(patient)
            };
        }

        private async Task<bool> PatientExists(string email){
            return await _context.Patients.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}