using Hospital_Microservice.Models;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Microservice_Tests.ServicesFake
{
    class FakeHospitalService : IHospitalService
    {
        private readonly List<Hospital> _hospitals;

        public FakeHospitalService()
        {
            _hospitals = new List<Hospital>()
            {
                new Hospital(){ Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Name = "Spital1", City="Iasi",
                 County = "Iasi", Address = "Strada", Email="hospital@email.com", UserName="user" },
                new Hospital(){ Id= new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Name = "Spital2", City="Roman",
                 County = "Neamt", Address = "Strada2", Email="hospital2@email.com", UserName="user2" },
                new Hospital(){ Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"), Name = "Spital3", City="Horia",
                 County = "Neamt", Address = "Strada", Email="hospital3@email.com", UserName="user3" },
                new Hospital(){ Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d19da"), Name = "Spital3", City="Roman",
                 County = "Neamt", Address = "Strada", Email="hospital213@email.com", UserName="us3er3" }
            };
        }



        Task<IEnumerable<Hospital>> IHospitalService.GetHospitalsAsync()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Hospital>> IHospitalService.GetHospitalsByCityOrCountyAsync(string cityOrCounty)
        {
            return _hospitals.Where(h => h.City.Contains(cityOrCounty)
           || h.County.Contains(cityOrCounty));
        }

        public async Task<ActionResult<Hospital>> HospitalRegister(RegisterInformation info)
        {
            throw new NotImplementedException();
        }

        public bool Authorize2(ClaimsIdentity identity, string type)
        {
            throw new NotImplementedException();
        }
    }
}
