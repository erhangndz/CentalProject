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
    public class AboutManager : GenericManager<About>, IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IGenericDal<About> genericDal, IAboutDal aboutDal) : base(genericDal)
        {
            _aboutDal = aboutDal;
        }

        public List<About> TGetActiveAbouts()
        {
           return _aboutDal.GetActiveAbouts();
        }
    }
}
