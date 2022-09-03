using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoctorRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> GetDoctorByNameAsync(string docName)
        {
            return await _context.Doctors
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.Name == docName);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(int id)
        {
            return await _context.Doctors
                .Where(x => x.Id == id)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Doctors
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Doctor doc)
        {
            _context.Entry(doc).State = EntityState.Modified;
        }
    }
}