using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Araba Modeli boş bırakılamaz");
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Vites Türü boş bırakılamaz");
            RuleFor(x => x.GasType).NotEmpty().WithMessage("Yakıt Türü boş bırakılamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Yıl boş bırakılamaz");
            RuleFor(x => x.Kilometer).NotEmpty().WithMessage("Km değeri boş bırakılamaz");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites boş bırakılamaz");
            RuleFor(x => x.SeatCount).NotEmpty().WithMessage("Koltuk sayısı boş bırakılamaz");
        }
    }
}
