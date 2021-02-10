using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDataBaseContext>, IRentACarDal
    {
        public List<RentACarDetails> GetRentACarDetails()
        {
            using (MyDataBaseContext myDataBaseContext=new MyDataBaseContext())
            {
                var result = from c in myDataBaseContext.Cars
                             join b in myDataBaseContext.Brands
                             on c.BrandId equals b.BrandId
                             join cl in myDataBaseContext.Colors
                             on c.ColorId equals cl.ColorId
                             select new RentACarDetails

                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList();




            }
        }
    }
}
