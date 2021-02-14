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

        ICarDal _rentACarDal;                 //Consturactor Injection

        public CarManager(ICarDal rentACarDal)
        {
            _rentACarDal = rentACarDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }

            else if (car.Description.Length >=2 && car.DailyPrice > 8000)
            {
                _rentACarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
                
            }
           
        }

        public IDataResult<Car> AddAndReturnData(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorDataResult<Car>(car ,Messages.CarDescriptionInvalid);
            }

            else if (car.Description.Length >= 2 && car.DailyPrice > 8000)
            {
                car.Description = car.Description + "!!";
                _rentACarDal.Add(car);
                return new SuccessDataResult<Car>(_rentACarDal.Get(c=>c.Id==car.Id),Messages.CarAdded);
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.CarDescriptionInvalid);

            }

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

        public IDataResult<List<CarDetailsDto>> GetRentACarDetails()
        {
           return new SuccessDataResult<List<CarDetailsDto>>(_rentACarDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _rentACarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
