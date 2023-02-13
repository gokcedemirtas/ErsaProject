using Core.Entities.Concrete;
using Core.Utilities.Jwt;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto);
        User Login(UserForLoginDto userForLoginDto);

        bool UserExists(string email);
        AccessToken CreateAccessToken(User user); 
    }
}
