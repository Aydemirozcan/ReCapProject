using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).Must(CheckReturnCar).WithMessage("The car did't return,You should choose another car");
        }

        private bool CheckReturnCar(int arg)
        {
            IRentalDal rentalDal = new EfRentalDal();
            var checkcar = rentalDal.GetRentalDetails(r => r.CarId == arg && r.ReturnDate == null);
            
            if (checkcar.Count>0)
            {
                return false;
            }
            return true;
        }   
    }
}
