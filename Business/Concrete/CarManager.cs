using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        IProjectDal _projectDal;

        public CarManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public List<Car> GetAll()
        {
            // if / koşullar / Sorgular vb.
            return _projectDal.GetAll();
        }

        public List<Car> GetById(int carId)
        {
            return _projectDal.GetById(carId);

        }

        public List<Car> OrderByDailyPriceAsc()
        {
            return _projectDal.OrderByDailyPriceAsc();
        }

        public List<Car> OrderByDailyPriceDesc()
        {
            return _projectDal.OrderByDailyPriceDesc();

        }
    }
}
