using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c=>c.Id == carImage.Id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarImageNotExist);
            }
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);

        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var fileUpdate = FileHelper.Update(file, carImage.ImagePath);
            carImage.ImagePath = fileUpdate.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckCarHasImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckCarHasImage(carId).Data);

        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == carImageId));
        }


        //private IResult CheckExistCarIdFromCarIdList(int carId)
        //{
        //    var result = _carService.GetAll().Data.Where(c => c.CarId == carId).Any();
        //    if (!result)
        //    {
        //        return new ErrorResult(Messages.CarIdNotExistError);
        //    }
        //    return new SuccessResult();
        //}

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count > 4)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckCarHasImage(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }

    }
}
