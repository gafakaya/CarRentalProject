using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectDal
    {
        List<Car> GetById(int carId);
        List<Car> GetAll();
        List<Car> OrderByDailyPriceAsc();
        List<Car> OrderByDailyPriceDesc();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
