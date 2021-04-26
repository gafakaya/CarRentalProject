using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId));
            
            _carDal.Add(car);
            return new SuccessResult();
        }
        //[SecuredOperation("Car.List")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            // if / koşullar / Sorgular vb.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == BrandId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == ColorId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult();
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult();
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result.Count > 20)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult BrandCountChecker()
        {
            var result = _brandService.GetAll().Data;
            if (result.Count > 20)
            {
                return new ErrorResult(Messages.BrandMaxCountError);
            }
            return new SuccessResult();
        }


    }
}
