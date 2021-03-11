using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
