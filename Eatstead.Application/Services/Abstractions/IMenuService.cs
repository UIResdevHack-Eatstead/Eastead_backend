using Eatstead.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuegate.Application.Services.Abstractions
{
    public interface IMenuService
    {
        Task<bool> CreateMenu(MenuDto menuDto);
        Task<MenuDto> GetMenuByIdAsync(int id);
        Task<IEnumerable<MenuDto>> GetMenus();
        Task<bool> UpdateMenu(int id, MenuDto menuDto);
        Task<bool> DeleteMenu(int id);
    }
}
