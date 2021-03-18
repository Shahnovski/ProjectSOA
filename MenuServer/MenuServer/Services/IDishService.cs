using MenuServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Services
{
    public interface IDishService : IDataService<DishDto>
    {
        IEnumerable<DishDto> GetAll();
    }
}
