using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        IRentACarDal _rentACarDal;                 //Consturactor Injection

        public CarManager(IRentACarDal rentACarDal)
        {
            _rentACarDal = rentACarDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }

            else if (car.Description.Length >2 && car.DailyPrice > 8000)
            {
                _rentACarDal.Add(car);
            }
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _rentACarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_rentACarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_rentACarDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<RentACarDetails>> GetRentACarDetails()
        {
           return new SuccessDataResult<List<RentACarDetails>>(_rentACarDal.GetRentACarDetails());
        }

        public IResult Update(Car car)
        {
            _rentACarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
