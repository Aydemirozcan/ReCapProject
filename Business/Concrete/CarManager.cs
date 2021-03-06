﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _irentACarDal;                 //Consturactor Injection

        public CarManager(ICarDal irentACarDal)
        {
            _irentACarDal = irentACarDal;
        }
        
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IproductService.Get")]
        public IResult Add(Car car)
        {
            

            //if (car.Description.Length < 2)
            //{
            //    return new ErrorResult(Messages.CarDescriptionInvalid);
            //}

            //else if (car.Description.Length >= 2 && car.DailyPrice > 8000)
            //{
            //    _irentACarDal.Add(car);
            //    return new SuccessResult(Messages.CarAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.CarDescriptionInvalid);

            //}

            _irentACarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

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
                _irentACarDal.Add(car);
                return new SuccessDataResult<Car>(_irentACarDal.Get(c=>c.CarId==car.CarId),Messages.CarAdded);
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.CarDescriptionInvalid);

            }

        }

        public IResult Delete(Car car)
        {
            _irentACarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_irentACarDal.GetAll(),Messages.CarsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_irentACarDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetRentACarDetails()
        {
           return new SuccessDataResult<List<CarDetailsDto>>(_irentACarDal.GetCarDetails());
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _irentACarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
