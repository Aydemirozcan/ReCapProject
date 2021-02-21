using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.NewUserAdded);
        }

        public IResult Delete(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.TheUserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll());
        }

        public IDataResult<User> GetById(int ıd)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(u => u.Id == ıd));
        }

        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.TheUserUpdated);
        }
    }
}
