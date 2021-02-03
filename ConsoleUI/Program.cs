using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryRentACarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
        }
    }
}
