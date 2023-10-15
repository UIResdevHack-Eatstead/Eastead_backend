using Eatstead.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatstead.Application.Services.Abstractions
{
    public interface ICafeteriaService
    {
        Task<bool> CreateCafeteria(CafeteriaDto restaurantDto);
        Task<IEnumerable<CafeteriaDto>> GetCafeteriaByIdAsync(int id);
        Task<IEnumerable<CafeteriaDto>> GetCafeterias();
        Task<bool> UpdateCafeteria(int id, CafeteriaDto menuDto);
        Task<bool> DeleteCafeteria(int id);
    }
}
