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
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //}

            Car car1 = new Car();
            car1.Description = "Good";
            car1.DailyPrice = 10000;
            CarManager carManager1 = new CarManager(new EfCarDal());

            var result1 = carManager1.Add(car1);
            if (result1.Success == true)
            {
                Console.WriteLine(result1.Message);

            }
            else if (result1.Success == false)
            {
                Console.WriteLine(result1.Message);
            }

            Car car2 = new Car();
            car2.BrandId = 55;
            car2.Description = "Goooood";
            car2.DailyPrice = 100000;

            var result3 = carManager1.AddAndReturnData(car2);
            if (result3.Success == true)
            {
                Console.WriteLine(result3.Data.Description);
            }




            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental();
            rental.CarId = 19;
            rental.CustomerId = 1;
            var result5 = rentalManager.Add(rental);
            Console.WriteLine(result5.Message);









            //CarManager carManager2 = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetRentACarDetails())
            //{
            //    Console.WriteLine(car.Id + "/" + car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
            //}



            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetRentACarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




        }


    }
}
