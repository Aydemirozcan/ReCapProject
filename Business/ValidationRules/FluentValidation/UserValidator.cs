using Core.Entities.Concrete;
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
            
            RuleFor(u => u.Email).MaximumLength(20);

        }

      
    }
}
