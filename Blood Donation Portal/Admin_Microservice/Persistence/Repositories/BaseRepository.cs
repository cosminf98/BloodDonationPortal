using Admin_Microservice.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AdminDbContext _context;

        public BaseRepository(AdminDbContext context)
        {
            _context = context;
        }
    }
}
