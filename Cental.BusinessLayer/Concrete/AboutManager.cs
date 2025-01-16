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
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void TCreate(About entity)
		{
			_aboutDal.Create(entity);
		}

		public void TDelete(int id)
		{
			_aboutDal.Delete(id);
		}

		public List<About> TGetAll()
		{
			return _aboutDal.GetAll();
		}

		public About TGetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public void TUpdate(About entity)
		{
			_aboutDal.Update(entity);
		}
	}
}
