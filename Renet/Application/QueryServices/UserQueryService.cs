using Application.Dtos;
using Application.Dtos.Users;
using Application.IRepositories;
using Application.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryServices
{
    public class UserQueryService
    {
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PaginationDto<BasicUserDto>> GetAllUser(int page, int pageSize)
        {
            var user = await _userRepository.GetAllUser(page, pageSize);
            var dto = user.Select(x => x.ToBasicDto()).ToList();
            var result = new PaginationDto<BasicUserDto>()
            {
                Results = dto,
                TotalRecord = await _userRepository.GetAllUserCount()
            };
            return result;
        }

        public async Task<FullUserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            var dto = user.ToFullDto();
            return dto;
        }


    }
}
