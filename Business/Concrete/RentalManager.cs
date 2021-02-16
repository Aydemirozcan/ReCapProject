using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }





        public IResult Add(Rental rental)
        {

            var result = _iRentalDal.Get(p=>p.CarId==rental.CarId && p.ReturnDate==null);
            if (result!=null)
            {
                return new ErrorResult(Messages.RentalAddedError);

            }

            _iRentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }





       


        public IResult CheckReturnRental(int Id)
        {
            var result = _iRentalDal.GetRentalDetails(p => p.CarId == Id && p.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);

        }



        public IDataResult<List<RentalDetailsDto>> GetRentalDetails(int id)
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_iRentalDal.GetRentalDetails(r => r.Id == id));
        }








        public IResult Delete(Rental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.TheRentalDataDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int ıd)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(r => r.Id == ıd));
        }

        

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.TheCarUpdated);
        }

    }
}
