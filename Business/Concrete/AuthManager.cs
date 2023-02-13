using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Jwt;
using Core.Utilities.Security.Hashing;
using Entity.Dtos;
using System.Net.Mail;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetOperationClaims(user);
            return _tokenHelper.CreateAccessToken(user, claims);
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            if (userToCheck is null)
            {
                return new User
                {
                    EmailAddress = userForLoginDto.Email
                };
            }

            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password,
                userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new User();
            }

            return userToCheck;
        }

        public User Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] hash, salt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out hash, out salt);
            User user = new User
            {
                EmailAddress = userForRegisterDto.Email,
                FullName = userForRegisterDto.FullName,
                PasswordHash= hash,
                PasswordSalt= salt,
            };

            _userService.Add(user);

            return user;
        }

        public bool UserExists(string email)
        {
            if (_userService.GetByMail(email) is not null)
            {
                return true;
            }

            return false;
        }
    }
}

