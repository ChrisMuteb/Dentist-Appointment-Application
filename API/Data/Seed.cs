using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedDoctors(DataContext context){
            if(await context.Doctors.AnyAsync()) return;

            var doctorData = await System.IO.File.ReadAllTextAsync("Data/DoctorSeedData.json");
            var doctors = JsonSerializer.Deserialize<List<Doctor>>(doctorData);
            foreach(var doc in doctors){
                context.Doctors.Add(doc);
            }

            await context.SaveChangesAsync();
        }
    }
}