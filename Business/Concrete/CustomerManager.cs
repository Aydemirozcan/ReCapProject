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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ıCustomerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _ıCustomerDal = ıCustomerDal;
        }

        public IResult Add(Customer customer)
        {
            _ıCustomerDal.Add(customer);
            return new SuccessResult(Messages.NewCustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _ıCustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_ıCustomerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_ıCustomerDal.Get(c => c.CustomerId == customerId));
        }

        public IResult Update(Customer customer)
        {
            _ıCustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
