using AutoMapper;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car, CreateCarDto>().ReverseMap();
        }
    }
}
