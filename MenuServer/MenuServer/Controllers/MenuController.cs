using MenuServer.Data;
using MenuServer.Dtos;
using MenuServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MenuServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/menu
        [HttpGet]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IEnumerable<MenuDto> GetMenu()
        {
            string accessToken = Request.Headers[HeaderNames.Authorization];
            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<MenuDto> result = _menuService.GetAll(currentUserName).ToList();
            foreach (MenuDto menu in result)
            {
                if (menu.Dish.Ingredients.Count() > 0)
                {
                    _menuService.GetIngredientsFromCatalog("http://localhost:8072/api/v1/ingredients/byCodes/", menu.Dish, accessToken);
                    _menuService.GetIngredientsFromStore("http://localhost:8073/api/v1/ingredients/byCodes/", menu.Dish, accessToken);
                }
            }
            return result;
        }

        // GET: api/menu/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<MenuDto> GetMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MenuDto menuDto = _menuService.GetById(id);

            if (menuDto == null)
            {
                return NotFound();
            }

            return Ok(menuDto);
        }

        // PUT: api/menu/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IActionResult PutMenu([FromRoute] int id, [FromBody] MenuDto menuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuDto.MenuId)
            {
                return BadRequest();
            }

            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            menuDto.Username = currentUserName;
            menuDto = _menuService.Save(id, menuDto);

            if (!MenuExists(id))
            {
                return NotFound();
            }

            return Ok(menuDto);
        }

        // POST: api/menu
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<MenuDto> PostMenu([FromBody] MenuDto menuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            menuDto.Username = currentUserName;
            MenuDto newMenu = _menuService.Save(0, menuDto);

            return CreatedAtAction("GetMenu", new { id = newMenu.MenuId }, newMenu);
        }

        // DELETE: api/menu/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<MenuDto> DeleteMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!MenuExists(id))
            {
                return NotFound();
            }

            _menuService.Delete(id);

            return Ok();
        }

        // DELETE: api/menu
        [HttpDelete]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<MenuDto> DeleteAllMenus()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _menuService.DeleteAll(currentUserName);

            return Ok();
        }

        [HttpPost("toCart")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IActionResult PostIngredientsToCart([FromBody] List<DishDto> dishDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string accessToken = Request.Headers[HeaderNames.Authorization];
            _menuService.PostIngredientsToCart("http://localhost:8073/api/v1/cartItems/all", dishDtos, accessToken);

            return Ok();
        }

        private bool MenuExists(int id)
        {
            return _menuService.EntityExists(id);
        }
    }
}
