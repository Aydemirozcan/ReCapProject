using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDataBaseContext>, IRentalDal
    {

        
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (MyDataBaseContext myDataBaseContext = new MyDataBaseContext())
            {
                var result = from r in myDataBaseContext.Rentals.Where(filter)
                             join b in myDataBaseContext.Customers
                             on r.CustomerId equals b.CustomerId
                             join c in myDataBaseContext.Cars
                             on r.CarId equals c.Id
                             select new RentalDetailsDto
                             {
                                 CarId=c.Id,
                                 CustomerName = b.CustomerName,
                                 ReturnDate = r.ReturnDate,
                                 RentDate = r.RentDate

                             };
                return result.ToList();
            }
        }
    }
}
