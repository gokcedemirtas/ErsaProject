using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ErsaContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var ersaContext = new ErsaContext())
            {
                //IQueyable
                var opClaims = from operationClaims in ersaContext.OperationClaims
                               join userOperationClaims in ersaContext.UserOperatonClaims
                               on operationClaims.OperationClaimId equals userOperationClaims.OperationClaimId
                               where userOperationClaims.UserId == user.UserId
                               select new OperationClaim 
                               {
                                   OperationClaimId = operationClaims.OperationClaimId,
                                   Name = operationClaims.Name 
                               };

                return opClaims.ToList();
            }
        }
    }
}
