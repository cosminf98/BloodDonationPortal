using Donor_Microservice.Persistence.IRepositories;
using Hospital_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence.Repositories
{
    public class DonorRepository : BaseRepository, IDonorRepository
    {
        public DonorRepository(DonorDbContext context) : base(context) {}

        //public Task<IEnumerable<Hospital>> GetNearbyHospitalsAsync()
        //{


        //    throw new NotImplementedException();
        //}
    }
}
