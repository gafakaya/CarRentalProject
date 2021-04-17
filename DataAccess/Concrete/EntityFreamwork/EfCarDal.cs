using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDBContext context = new MyDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId, BrandName = b.BrandName, ColorName = color.ColorName, DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
