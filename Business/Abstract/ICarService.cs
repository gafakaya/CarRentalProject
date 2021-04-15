using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetById(int carId);
        List<Car> GetAll();
        List<Car> OrderByDailyPriceAsc();
        List<Car> OrderByDailyPriceDesc();

    }
}
