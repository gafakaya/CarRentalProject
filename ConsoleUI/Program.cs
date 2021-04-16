using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFreamwork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());
            IColorService colorService = new ColorManager(new EfColorDal());

            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.CarId);
            //    Console.WriteLine(car.BrandId);
            //    Console.WriteLine(car.ColorId);
            //    Console.WriteLine(car.ModelYear);
            //    Console.WriteLine(car.Description);
            //    Console.WriteLine(car.DailyPrice);
            //}

            //carService.Add(new Car
            //{
            //    CarId = 6,
            //    BrandId = 2,
            //    ColorId = 4,
            //    ModelYear = "2021",
            //    DailyPrice = 550,
            //    Description = "Hammer"
            //});

            //brandService.Add(new Brand
            //{
            //    BrandId = 8,
            //    BrandName = "Lamborgini"
            //});

            //foreach (var brand in brandService.GetAll())
            //{
            //    Console.WriteLine("Name: {0}\nID: {1}", brand.BrandName, brand.BrandId);
            //}

            //colorService.Add(new Color
            //{
            //    ColorId = 12,
            //    ColorName = "Fuchsia"
            //});

            //foreach (var color in colorService.GetAll())
            //{
            //    Console.WriteLine("Name: {0}\nID: {1}", color.ColorName, color.ColorId);
            //}

        }
    }
}
