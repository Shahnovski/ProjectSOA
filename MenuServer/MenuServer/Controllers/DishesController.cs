using System.Collections.Generic;
using MenuServer.Data;
using MenuServer.Dtos;
using MenuServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MenuServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // GET: api/Dishes
        [HttpGet]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IEnumerable<DishDto> GetDish()
        {
            return _dishService.GetAll();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<DishDto> GetDish([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DishDto dishDto = _dishService.GetById(id);

            if (dishDto == null)
            {
                return NotFound();
            }

            return Ok(dishDto);
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public IActionResult PutDish([FromRoute] int id, [FromBody] DishDto dishDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dishDto.DishId)
            {
                return BadRequest();
            }

            dishDto = _dishService.Save(id, dishDto);

            if (!DishExists(id))
            {
                return NotFound();
            }

            return Ok(dishDto);
        }

        // POST: api/Dishes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public ActionResult<DishDto> PostDish([FromBody] DishDto dishDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DishDto newDish = _dishService.Save(0, dishDto);

            return CreatedAtAction("GetDish", new { id = newDish.DishId }, newDish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public ActionResult<DishDto> DeleteDish([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!DishExists(id))
            {
                return NotFound();
            }

            _dishService.Delete(id);

            return Ok();
        }

        private bool DishExists(int id)
        {
            return _dishService.EntityExists(id);
        }
    }
}
