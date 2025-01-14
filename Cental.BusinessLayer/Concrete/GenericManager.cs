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
    public class GenericManager<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TCreate(T entity)
        {

           _genericDal.Create(entity);
        }

        public void TDelete(int id)
        {
           
            _genericDal.Delete(id);
        }

        public List<T> TGetAll()
        {
          return _genericDal.GetAll();
        }

        public T TGetById(int id)
        {
          var value =  _genericDal.GetById(id);
            if (value == null)
            {
                throw new Exception("Id'ye göre değer bulunamadı");
            }
            return value;
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
