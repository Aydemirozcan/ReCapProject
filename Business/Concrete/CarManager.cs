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

        public List<Car> GetAll()
        {
            return _rentACarDal.GetAll();
        }
    
       
    
    }
}
