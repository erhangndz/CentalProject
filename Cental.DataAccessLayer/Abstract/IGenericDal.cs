using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {

        List<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Create(T entity);
        void Update(T entity);


    }
}
