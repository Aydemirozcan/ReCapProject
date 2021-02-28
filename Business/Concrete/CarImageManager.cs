using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile image , CarImage carImage)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (imageCount >= 5)
            {                                                                              //5 den fazla fotoğraf olmasın diye yazdığımız kural
                return new ErrorResult(Messages.ImageLimitExceded);
            }

            var imageResult = ImageUploadHelper.Upload(image);
            carImage.ImagePath = imageResult.Message;                       //Upload dan gelen mesaj bir dosya yoludur.
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAded);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image==null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            ImageUploadHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile image, CarImage carImage)
        {
            var theImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (theImage == null)
            {
                return new ErrorResult("Image Not Found");                          //Seçilen bir resim yoksa bunu ver.
            }

            var updatedFile = ImageUploadHelper.Update(image, theImage.ImagePath);
            theImage.ImagePath = updatedFile.Message;
            theImage.Date = DateTime.Now;
            _carImageDal.Update(theImage);
            return new SuccessResult(Messages.ImageUpdated);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetImageById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, Id = 0, Date = DateTime.Now, ImagePath = "/images/IMG_20200128_153629.png" });     //Eğer ki bu Id de herhangi bir resim yoksa ona Default bir reim atıyor. 
            return new SuccessDataResult<List<CarImage>>(images);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(p=>p.CarId==carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }

       
    }
}
