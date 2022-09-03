using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IDoctorRepository
    {
        void Update(Doctor doc);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<Doctor> GetDoctorByNameAsync(string docName);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(int id);
        
    }
}