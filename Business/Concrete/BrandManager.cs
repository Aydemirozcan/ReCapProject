using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _ıBrandDal;

        public BrandManager(IBrandDal ıBrandDal)
        {
            _ıBrandDal = ıBrandDal;
        }

        public void Add(Brand brand)
        {
            _ıBrandDal.Add(brand);
            Console.WriteLine("New Brand Added");
        }

        public void Delete(Brand brand)
        {
            _ıBrandDal.Delete(brand);
            Console.WriteLine("Deleted");
        }

        public List<Brand> GetAll()
        {
            return _ıBrandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _ıBrandDal.Get(p => p.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _ıBrandDal.Update(brand);
            Console.WriteLine("Brand Updated");
        }
    }
}
