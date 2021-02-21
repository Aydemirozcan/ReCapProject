using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id).GreaterThanOrEqualTo(8);
            RuleFor(u => u.Email).Must(CheckEmail).WithMessage("This e-mail belongs to another user.You must write different e-mail");
        }

        private bool CheckEmail(string arg)
        {
            IUserDal userDal = new EfUserDal();
            var check = userDal.Get(u => u.Email == arg);

            if (check ==null)
            {
                return true;
            }
            return false;        
        
        }
    }
}
