using Application.Dtos;
using Application.Dtos.Users;
using Domain.Users;
using Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            var dto = new UserDto()
            {

                Id = user.Id,
                UserName = user.UserName,
            };

            return dto;
        }

        public static BasicUserDto ToBasicDto(this User user)
        {
            var dto = new BasicUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Province = user.Province.GetDescription(),
            };

            return dto;
        }

        public static FullUserDto ToFullDto(this User user)
        {
            var dto = new FullUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Address = user.Address,
                City = user.City,
                PostalCode = user.PostalCode,
                Email = user.Email,
                Province = user?.Province.GetDescription(),
                UserName = user.UserName,

            };

            return dto;

        }
    }
}
