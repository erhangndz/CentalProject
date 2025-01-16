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
	public class BrandManager : IBrandService
	{
		private readonly IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void TCreate(Brand entity)
		{
			_brandDal.Create(entity);
		}

		public void TDelete(int id)
		{
			_brandDal.Delete(id);
		}

		public List<Brand> TGetAll()
		{
			return _brandDal.GetAll();
		}

		public Brand TGetById(int id)
		{
			return _brandDal.GetById(id);
		}

		public void TUpdate(Brand entity)
		{
			_brandDal.Update(entity);
		}
	}
}
