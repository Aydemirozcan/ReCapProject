using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
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

        public IResult Add(Color color)
        {
            _ıColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        

        public IResult Delete(Color color)
        {
            _ıColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ıColorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_ıColorDal.Get(p => p.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _ıColorDal.Update(color);
            return new SuccessResult(Messages.CarUpdated);
        }

      
    }
}
