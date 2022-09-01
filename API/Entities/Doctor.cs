using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        // public Photo Photos { get; set; }

        public int GetAge(){
            return DateOfBirth.CalculateAge();
        }
    }
}