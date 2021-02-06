using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
            Car car1 = new Car();
            car1.Description = "Good";
            car1.DailyPrice = 10000;
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(car1);
        }
        

    }
}
