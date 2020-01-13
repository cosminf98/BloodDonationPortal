using Hospital_Microservice.Persistence.Contexts;

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
