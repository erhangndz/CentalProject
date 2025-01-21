using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        public EfCarDal(CentalContext context) : base(context)
        {
        }

        public List<Car> GetCarsWithBrands()
        {
            //Eager Loading    vs. //Lazy Loading
           return _context.Cars.Include(x => x.Brand).ToList();
        }
    }
}
