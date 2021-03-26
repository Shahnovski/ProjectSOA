using MenuServer.Dtos;
using MenuServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //[AllowAnonymous]
        public IEnumerable<MenuDto> GetMenu()
        {
            return _menuService.GetAll();
        }

        // GET: api/menu/5
        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[AllowAnonymous]
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
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
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
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
        public ActionResult<MenuDto> PostMenu([FromBody] MenuDto menuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MenuDto newMenu = _menuService.Save(0, menuDto);

            return CreatedAtAction("GetMenu", new { id = newMenu.MenuId }, newMenu);
        }

        // DELETE: api/menu/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = Policies.Admin, AuthenticationSchemes = "Bearer")]
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

        private bool MenuExists(int id)
        {
            return _menuService.EntityExists(id);
        }
    }
}
