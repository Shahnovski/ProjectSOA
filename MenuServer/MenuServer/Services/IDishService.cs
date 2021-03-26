using MenuServer.Dtos;
using System.Collections.Generic;

namespace MenuServer.Services
{
    public interface IDishService : IDataService<DishDto>
    {
        IEnumerable<DishDto> GetAll();
    }
}
