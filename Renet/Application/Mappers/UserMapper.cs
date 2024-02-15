using Application.Dtos;
using Domain.Users;
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
    }
}
