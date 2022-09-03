using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class PatientsController : BaseApiController
    {
       private readonly DataContext _context;
        private readonly ITokenService _tokenService;
  
        public PatientsController(DataContext context)
        {
            // _tokenService = tokenService;
            
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients(){
            var patients = _context.Patients.ToListAsync();
            // if(patients == null)
            //     return BadRequest("Failed to get the data");
            return await patients;
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id){
            var patients = _context.Patients.FindAsync(id);

            return await patients;
        }
    }
}