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
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(CentalContext context) : base(context)
        {
        }

        public List<About> GetActiveAbouts()
        {
           return _context.Abouts.Where(x => x.AboutId == 1).ToList();
        }
    }
}
