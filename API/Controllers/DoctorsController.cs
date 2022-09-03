using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class DoctorsController : BaseApiController
    {
        
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetDoctors(){
            var doctors = await _doctorRepository.GetMembersAsync();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetDoctor(int id){
            return await _doctorRepository.GetMemberAsync(id);
        }

        // [HttpGet("{name}")]
        // public async Task<ActionResult<Doctor>> GetDoctor(string name){
        //     return await _doctorRepository.GetDoctorByNameAsync(name);
        // }
    }
}