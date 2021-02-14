using Business.Abstract;
using Business.Constans;
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
        IUserDal _ıUserDal;

        public UserManager(IUserDal ıUserDal)
        {
            _ıUserDal = ıUserDal;
        }

        public IResult Add(User user)
        {
            _ıUserDal.Add(user);
            return new SuccessResult(Messages.NewUserAdded);
        }

        public IResult Delete(User user)
        {
            _ıUserDal.Delete(user);
            return new SuccessResult(Messages.TheUserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_ıUserDal.GetAll());
        }

        public IDataResult<User> GetById(int ıd)
        {
            return new SuccessDataResult<User>(_ıUserDal.Get(u => u.Id == ıd));
        }

        public IResult Update(User user)
        {
            _ıUserDal.Update(user);
            return new SuccessResult(Messages.TheUserUpdated);
        }
    }
}
