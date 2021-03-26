using MenuServer.Models;

namespace MenuServer.Repositories
{
    abstract public class BaseRepository
    {
        protected readonly MenuServerContext _context;

        public BaseRepository(MenuServerContext context)
        {
            _context = context;
        }
    }
}
