using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager(ICarDal _carDal) : ICarService
    {

        public void TCreate(Car entity)
        {
            _carDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _carDal.Delete(id);
        }

        public List<Car> TGetAll()
        {
            return _carDal.GetAll();
        }

        public Car TGetById(int id)
        {
           return _carDal.GetById(id);
        }

        public List<Car> TGetCarsWithBrands()
        {
            return _carDal.GetCarsWithBrands();
        }

        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
