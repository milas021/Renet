using Application.Commands;
using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using Application.Services;
using Domain.Tokens;
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
    public class AuthService 
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserData> Registration(RegistrationCommand command , UserAgent userAgent)
        {
           var isExist = await _userRepository.IsUserExist(command.UserName);

            if (isExist)
                throw new Exception("کاربر وجود دارد");

            var user = new User(command.UserName, command.Password.ToBase64Encode());

            await _userRepository.Add(user);
            await _userRepository.Save();
            var userDto = user.ToDto();

            var tokens = _tokenService.GenerateTokens(user);
            await _tokenService.SaveRefreshTokenAsync(user.Id, tokens.RefreshToken, userAgent);
            
            var result = new UserData
            {
                Tokens = tokens,
                User = userDto
            };

            return result;

            


        }

       
    }
}
