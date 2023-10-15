using Eatstead.Application.DTOs;
using Eatstead.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Application.Services.Abstractions;
using Valuegate.Infrastructure.Data;
using Valuegate.Infrastructure.Repositories;

namespace Eatstead.Application.Services.Implementations
{
    public class MenuService: IMenuService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuService(UnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateMenu(MenuDto menuDto)
        {
            var mapper = _mapper.Map<Menu>(menuDto);
            var menu = await _unitOfWork.MenuRepository.Add(mapper);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<MenuDto> GetMenuByIdAsync(int id)
        {
           var menu = await _unitOfWork.MenuRepository.GetById(id);
            var mapper = _mapper.Map<MenuDto>(menu);

            return mapper;
        }

        public async Task<IEnumerable<MenuDto>> GetMenus()
        {
            var menu = _unitOfWork.MenuRepository.GetAll(false);
            var mapper = _mapper.Map<IEnumerable<MenuDto>>(menu);

            return mapper;
        }

        public async Task<bool> UpdateMenu(int id, MenuDto menuDto)
        {
            var menu = await _unitOfWork.MenuRepository.GetById(id);
            if (menu is null) return false;

             _unitOfWork.MenuRepository.Update(menu);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteMenu(int id)
        {
            var menu = await _unitOfWork.MenuRepository.GetById(id);
            if (menu is null) return false;

            await _unitOfWork.MenuRepository.Remove(menu);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
