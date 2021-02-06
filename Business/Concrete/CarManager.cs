using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _rentACarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _rentACarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _rentACarDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
