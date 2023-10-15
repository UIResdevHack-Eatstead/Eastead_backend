using Eatstead.Application.DTOs;
using Eatstead.Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eatstead.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeteriaController : ControllerBase
    {
        private readonly ICafeteriaService _cafeteriaService;
        public CafeteriaController(ICafeteriaService cafeteriaService)
        {
            _cafeteriaService= cafeteriaService;
        }

        [HttpGet("/get-cafeteria-by-id")]
        public async Task<ActionResult<CafeteriaDto>> GetCafeteriaById(int id)
        {
            var menu = await _cafeteriaService.GetCafeteriaByIdAsync(id);
            if (menu is null) return NotFound();

            return Ok(menu);
        }

        [HttpGet("/get-cafeterias")]
        public async Task<ActionResult<CafeteriaDto>> GetCafeterias()
        {
            var menu = await _cafeteriaService.GetCafeterias();

            return Ok(menu);
        }

        [HttpPost("/create-cafeteria")]
        public async Task<ActionResult<CafeteriaDto>> CreateCafeteria(CafeteriaDto cafeteriaDto)
        {
            var menu = await _cafeteriaService.CreateCafeteria(cafeteriaDto);
            if (menu is false) return BadRequest();

            return Ok(menu);
        }

        [HttpPut("/update-cafeteria")]
        public async Task<ActionResult<CafeteriaDto>> UpdateCafeteria(int cafeteriaId, CafeteriaDto cafeteriaDto)
        {
            var menu = await _cafeteriaService.UpdateCafeteria(cafeteriaId, cafeteriaDto);
            if (menu is false) return BadRequest();

            return Ok(menu);
        }


        [HttpDelete("/delete-cafeteria")]
        public async Task<ActionResult<CafeteriaDto>> DeleteCafeteria(int cafeteriaId)
        {
            var menu = await _cafeteriaService.DeleteCafeteria(cafeteriaId);
            if (menu is false) return NotFound();

            return Ok(menu);
        }
    }
}
