using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DonorDbContext _context;

        public BaseRepository(DonorDbContext context)
        {
            _context = context;
        }
    }
}
