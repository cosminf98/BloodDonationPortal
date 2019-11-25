using Admin_Microservice.Persistence.Contexts;
using Admin_Microservice.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Persistence.Repositories
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        public AdminRepository(AdminDbContext context) : base(context) { }
    }
}
