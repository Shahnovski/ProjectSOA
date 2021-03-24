using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuServer.Models;
using MenuServer.Services;
using MenuServer.Dtos;

namespace MenuServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/Ingredients
        [HttpGet]
        //[AllowAnonymous]
        public IEnumerable<IngredientDto> GetIngredient()
        {
            return _ingredientService.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        //[AllowAnonymous]
        public ActionResult<IngredientDto> GetIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IngredientDto ingredientDto = _ingredientService.GetById(id);

            if (ingredientDto == null)
            {
                return NotFound();
            }

            return Ok(ingredientDto);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public IActionResult PutIngredient([FromRoute] int id, [FromBody] IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IngredientDto ingredientDto2 = _ingredientService.GetById(id);

            if (id != ingredientDto.IngredientId)
            {
                return BadRequest();
            }

            if (ingredientDto.IngredientCode != ingredientDto2.IngredientCode)
            {
                if (CodeExists(ingredientDto.IngredientCode))
                {
                    return BadRequest("Ингредиент с таким кодом уже существует");
                }
            }

            ingredientDto = _ingredientService.Save(id, ingredientDto);

            if (!IngredientExists(id))
            {
                return NotFound();
            }

            return Ok(ingredientDto);
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public ActionResult<IngredientDto> PostIngredient([FromBody] IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CodeExists(ingredientDto.IngredientCode))
            {
                return BadRequest("Ингредиент с таким кодом уже существует");
            }

            IngredientDto newIngredient = _ingredientService.Save(0, ingredientDto);

            return CreatedAtAction("GetIngredient", new { id = newIngredient.IngredientId }, newIngredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public ActionResult<IngredientDto> DeleteIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!IngredientExists(id))
            {
                return NotFound();
            }

            _ingredientService.Delete(id);

            return Ok();
        }

        private bool IngredientExists(int id)
        {
            return _ingredientService.EntityExists(id);
        }

        private bool CodeExists(int code)
        {
            return _ingredientService.CodeExists(code);
        }
    }
}
