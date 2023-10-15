using Eatstead.Application.DTOs;
using Eatstead.Application.Services.Abstractions;
using Eatstead.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Infrastructure.Repositories;

namespace Eatstead.Application.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantService(UserManager<ApplicationUser> userManager, UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreateCafeteria(CafeteriaDto restaurantDto)
        {
            var user = _userManager.Users.Any(x => x.Id == restaurantDto.UserId);
            if (!user) return false;

            var mapper = _mapper.Map<Cafeteria>(restaurantDto);

             await _unitOfWork.CafeteriaRepository.Add(mapper);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<CafeteriaDto>> GetCafeteriaByIdAsync(int id)
        {
            var cafeteria =  _unitOfWork.CafeteriaRepository.FindandInclude(x => x.Id == id, true);
            var mapper = _mapper.Map<IEnumerable<CafeteriaDto>>(cafeteria);

            return mapper;
        }

        public async Task<IEnumerable<CafeteriaDto>> GetCafeteria()
        {
            var cafeteria = _unitOfWork.CafeteriaRepository.GetAll(true);
            var mapper = _mapper.Map<IEnumerable<CafeteriaDto>>(cafeteria);

            return mapper;
        }

        public async Task<bool> UpdateCafeteria(int id, CafeteriaDto menuDto)
        {
            var cafeteria = await _unitOfWork.CafeteriaRepository.GetById(id);
            if (cafeteria is null) return false;

            _unitOfWork.CafeteriaRepository.Update(cafeteria);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteCafeteria(int id)
        {
            var cafeteria = await _unitOfWork.CafeteriaRepository.GetById(id);
            if (cafeteria is null) return false;

            await _unitOfWork.CafeteriaRepository.Remove(cafeteria);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
