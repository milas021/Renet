using Application.Commands;
using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using Domain.Users;
using Infrastructure;
using Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.CommandHandlers
{
    public class AuthCommandHandler : ICommandHandler<RegistrationCommsnd, UserData>
    {
        private readonly IUserRepository _userRepository;

        public AuthCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserData> Handle(RegistrationCommsnd command)
        {
           var isExist = await _userRepository.IsUserExist(command.UserName);

            if (isExist)
                throw new Exception("کاربر وجود دارد");

            var user = new User(command.UserName, command.Password.ToBase64Encode());

            await _userRepository.Add(user);



            var userDto = user.ToDto();
            var tokens = new TokenDto
            {
                AccessToken = "",
                RefreshToken = ""
            };
            var result = new UserData
            {
                Tokens = tokens,
                User = userDto
            };

            return result;

            


        }

       
    }
}
