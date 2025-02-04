using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfUserSocialDal : GenericRepository<UserSocial>, IUserSocialDal
    {
        public EfUserSocialDal(CentalContext context) : base(context)
        {
        }

        public List<UserSocial> GetSocialsByUserId(int userId)
        {
            return _context.UserSocials.Where(x=>x.UserId== userId).ToList();
        }
    }
}
