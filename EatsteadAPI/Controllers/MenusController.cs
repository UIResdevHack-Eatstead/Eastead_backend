using Eatstead.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Valuegate.Application.Services.Abstractions;

namespace Eatstead.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("/get-menu-by-id")]
        public async Task<ActionResult<MenuDto>> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            if (menu is null) return NotFound();

            return Ok(menu);
        }

        [HttpGet("/get-menus")]
        public async Task<ActionResult<MenuDto>> GetMenus()
        {
            var menu = await _menuService.GetMenus();
         
            return Ok(menu);
        }

        [HttpPost("/create-menu")]
        public async Task<ActionResult<MenuDto>> CreateMenu(MenuDto menuDto)
        {
            var menu = await _menuService.CreateMenu(menuDto);
            if (menu is false) return BadRequest();

            return Ok(menu);
        }

        [HttpPut("/update-menu")]
        public async Task<ActionResult<MenuDto>> UpdateMenu(int menuId, MenuDto menuDto)
        {
            var menu = await _menuService.UpdateMenu(menuId, menuDto);
            if (menu is false) return BadRequest();

            return Ok(menu);
        }


        [HttpDelete("/delete-menu")]
        public async Task<ActionResult<MenuDto>> DeleteMenu(int menuId)
        {
            var menu = await _menuService.DeleteMenu(menuId);
            if (menu is false) return NotFound();

            return Ok(menu);
        }
    }
}
