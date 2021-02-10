using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Description.Length >2 && car.DailyPrice > 8000)
            {
                _rentACarDal.Add(car);
                Console.WriteLine("Added");
            }
        }

        public void Delete(Car car)
        {
            _rentACarDal.Delete(car);
            Console.WriteLine("Deleted");
        }

        public List<Car> GetAll()
        {
            return _rentACarDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _rentACarDal.Get(p => p.Id == carId);
        }

        public List<RentACarDetails> GetRentACarDetails()
        {
           return _rentACarDal.GetRentACarDetails();
        }

        public void Update(Car car)
        {
            _rentACarDal.Update(car);
            Console.WriteLine("Updated");
        }
    }
}
