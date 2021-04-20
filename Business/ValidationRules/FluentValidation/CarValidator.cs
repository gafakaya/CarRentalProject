using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :  AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(300).When(p => p.BrandId == 6);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(350).When(p => p.BrandId == 7 || p.BrandId == 8);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(2000).When(p => p.BrandId == 1009);

        }
    }
}
