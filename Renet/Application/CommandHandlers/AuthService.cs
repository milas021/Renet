using Application.Commands;
using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using Application.Services;
using Domain.Common;
using Domain.Tokens;
using Domain.Users;
using Infrastructure.Exceptions;
using Infrastructure.Extentions;

namespace Application.CommandHandlers {
    public class AuthService {
        private readonly IUserRepository _userRepository;

        private readonly TokenService _tokenService;
        private readonly ITokenRepository _tokenRepository;

        public AuthService(IUserRepository userRepository, TokenService tokenService, ITokenRepository tokenRepository) {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _tokenRepository = tokenRepository;

        }

        public async Task<UserData> Registration(RegistrationCommand command, UserAgent userAgent) {
            var isExist = await _userRepository.IsUserExist(command.UserName);

            if (isExist)
                throw new Exception("کاربر وجود دارد");

            var user = new User(command.UserName, command.Password.ToBase64Encode());

            await _userRepository.Add(user);
            await _userRepository.Save();
            var userDto = user.ToDto();

            var tokens = await _tokenService.GenerateTokens(user, userAgent);

            var result = new UserData {
                Tokens = tokens,
                User = userDto
            };

            return result;

        }

        public async Task<SendOTPDto> SignUp(SendOTPCommand command, UserAgent userAgent) {

            User user;
            var isExist = await _userRepository.IsUserExistByMobile(command.Mobile);
            if (isExist) {
                user = await _userRepository.GetByMobile(command.Mobile);
            }
            else {
                user = User.CreatByMobile(command.Mobile);
                await _userRepository.Add(user);
            }

            //todo : Send OTP

            var random = new Random();
            var dto = new SendOTPDto {
                //todo : random number should replace with real OTP Id
                OtpId = random.NextInt64(999, 9999),
                UserId = user.Id
            };

            return dto;
        }

        public async Task<UserData> VerifyOtp(VerifyOTPCommand command, UserAgent userAgent) {
            var user = await _userRepository.GetById(command.UserId);

            if (user == null)
                throw new AppException(ErrorMessage.UserNotExist);

            // todo : check otp
            user.ConfirmMobile();

            var userDto = user.ToDto();

            var tokens = await _tokenService.GenerateTokens(user, userAgent);

            var result = new UserData {
                Tokens = tokens,
                User = userDto
            };

            return result;

        }

        public async Task<UserData> Login(LoginCommand command, UserAgent userAgent) {
            var user = await _userRepository.GetByUserName(command.UserName);

            if (user == null)
                throw new Exception("کاربر وجود ندارد");

            //todo : why base64 ??
            if (command.Password.ToBase64Encode() != user.Password)
                throw new Exception("رمز نا درست است");


            var tokens = await _tokenService.GenerateTokens(user, userAgent);
            var userDto = user.ToDto();
            var result = new UserData {
                Tokens = tokens,
                User = userDto
            };
            return result;

        }

        

        public async Task Logout(string refreshToken) {
            await _tokenService.RemoveRefreshToken(refreshToken);
        }

        public async Task<UserData> Refresh(string accessToken, string refreshToken, UserAgent userAgent) {
            await _tokenService.ValidateAccessToken(accessToken);
            await _tokenService.ValidateRefreshToken(refreshToken);

            var currentToken = await _tokenRepository.Get(refreshToken);

            var user = await _userRepository.GetById(currentToken.UserID);
            var userDto = user.ToDto();
            var tokens = await _tokenService.GenerateTokens(user, userAgent);

            var userdata = new UserData {
                Tokens = tokens,
                User = userDto
            };

            return userdata;

        }




    }
}
