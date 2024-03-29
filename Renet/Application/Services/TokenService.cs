﻿using Application.Dtos;
using Application.IRepositories;
using Domain.Tokens;
using Domain.Users;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService
    {
        private readonly AccessTokenSettings _accessTokenSetting;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(IOptions<AccessTokenSettings> accessTokenSetting, ITokenRepository tokenRepository)
        {
            _accessTokenSetting = accessTokenSetting.Value;
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenDto> GenerateTokens(User user, UserAgent userAgent)
        {
            var refreshToken = await GenerateRefreshToken(user.Id, userAgent);

            var accessToken = this.GenerateAccessToken(user);

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.RefreshToken,
                Expired = refreshToken.Expired,
                LifeTime = refreshToken.LifeTime,
            };
        }


        public async Task SaveRefreshTokenAsync(Guid userId, string refreshToken, UserAgent userAgent)
        {
            var userToken = await _tokenRepository.Get(userId, userAgent.OS, userAgent.Browser);

            if (userToken is not null)
            {
                userToken.UpdateToken(refreshToken);
                await _tokenRepository.Save();
            }
            else
            {

                var token = new Token(userId, refreshToken, userAgent);
                await _tokenRepository.Add(token);
                await _tokenRepository.Save();
            }
        }

        public async Task RemoveRefreshToken(string refreshToken)
        {
            var token = await _tokenRepository.Get(refreshToken);
            if (token == null)
                throw new Exception("رفرش توکن یافت نشد");

            await _tokenRepository.Delete(token);

        }

        public async Task ValidateRefreshToken(string refreshToken)
        {
            var token = await _tokenRepository.Get(refreshToken);

            if (token == null)
                throw new Exception("رفرش توکن در دیتابیس موجود نسیت");

            if (DateTime.Now >= token.Expired)
                throw new Exception("رفرش توکن معتبر نیست");
        }

        public async Task ValidateAccessToken(string accessToken)
        {
           
        }



        #region PrivateMethod

        private async Task<Token> GenerateRefreshToken(Guid userId, UserAgent userAgent)
        {
            var randomNumber = new byte[32];
            string refreshToken = "";
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }

            var token = await _tokenRepository.Get(userId, userAgent.OS, userAgent.Browser);

            if (token == null)
            {
                token = new Token(userId, refreshToken, userAgent);
                await _tokenRepository.Add(token);
                await _tokenRepository.Save();
                return token;
            }

            else
            {
                token.UpdateToken(refreshToken);
                await _tokenRepository.Save();
            }

            return token;


        }



        private string GenerateAccessToken(User user)
        {
            var now = DateTime.Now;
            var expires = now.Add(TimeSpan.FromMinutes(_accessTokenSetting.LifeTime));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                //new(ClaimTypes.Email, user.Email)
            };


            var secretKey = Encoding.UTF8.GetBytes(_accessTokenSetting.Key);
            var securityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var jwt = new JwtSecurityToken(_accessTokenSetting.Issuer,
                _accessTokenSetting.Audience,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }


        #endregion 
    }
}
