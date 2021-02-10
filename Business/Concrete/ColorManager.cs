using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _ıColorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _ıColorDal = ıColorDal;
        }

        public void Add(Color color)
        {
            _ıColorDal.Add(color);
            Console.WriteLine("New Color Added");
        }

        

        public void Delete(Color color)
        {
            _ıColorDal.Delete(color);
            Console.WriteLine("Deleted");
        }

        public List<Color> GetAll()
        {
            return _ıColorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _ıColorDal.Get(p => p.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _ıColorDal.Update(color);
            Console.WriteLine("Updated");
        }

      
    }
}
