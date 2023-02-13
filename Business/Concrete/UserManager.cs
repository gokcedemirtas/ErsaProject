using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public string Add(User user)
        {
            _userDal.Add(user);
            return "Ekleme başarılı";
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(x => x.EmailAddress == email);
        }

        public List<OperationClaim> GetOperationClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
