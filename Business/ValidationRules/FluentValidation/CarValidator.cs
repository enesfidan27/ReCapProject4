using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {   
            RuleFor(c => c.CarDescription).NotEmpty();
            RuleFor(c=>c.CarDescription).MinimumLength(2);
            RuleFor(c => c.CarDailyPrice).NotEmpty();
            RuleFor(c => c.CarDailyPrice).GreaterThan(0);
            RuleFor(c => c.CarDailyPrice).GreaterThanOrEqualTo(600).When(c => c.BrandId == 1);
            RuleFor(c => c.CarDescription).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
