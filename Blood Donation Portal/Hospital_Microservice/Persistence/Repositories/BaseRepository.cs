using Hospital_Microservice.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly HospitalDbContext _context;

        public BaseRepository(HospitalDbContext context)
        {
            _context = context;
        }
    }
}
