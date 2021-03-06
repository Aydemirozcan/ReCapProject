﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryRentACarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryRentACarDal()
        {

            _cars = new List<Car> {
                new Car{ CarId=1,BrandId=1,ColorId=5,ModelYear=1996,DailyPrice=30,Description="Red Car"},
                new Car{ CarId=2,BrandId=2,ColorId=6,ModelYear=1996,DailyPrice=37,Description="Blue Car"},
                new Car{ CarId=3,BrandId=3,ColorId=7,ModelYear=1996,DailyPrice=35,Description="Green Car"},
                new Car{ CarId=4,BrandId=4,ColorId=8,ModelYear=1996,DailyPrice=40,Description="Black Car"},
                new Car{ CarId=5,BrandId=5,ColorId=9,ModelYear=1996,DailyPrice=45,Description="White Car"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(c => c.CategoryId == categoryId).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
