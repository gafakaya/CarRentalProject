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

            //GetCarDetailTest(carService);

            //GetAllCarTest(carService);

            //AddCarTest(carService);

            //AddBrandTest(brandService);

            //GetAllBrandTest(brandService);

            //AddColorTest(colorService);

            //GetAllColorTest(colorService);

            //var result = brandService.GetById(1);
            //Console.WriteLine(result.BrandName);

        }

        private static void GetAllColorTest(IColorService colorService)
        {
            foreach (var color in colorService.GetAll())
            {
                Console.WriteLine("Name: {0}\nID: {1}", color.ColorName, color.ColorId);
            }
        }

        private static void AddColorTest(IColorService colorService)
        {
            colorService.Add(new Color
            {
                ColorId = 12,
                ColorName = "Fuchsia"
            });
        }

        private static void GetAllBrandTest(IBrandService brandService)
        {
            foreach (var brand in brandService.GetAll())
            {
                Console.WriteLine("Name: {0}\nID: {1}", brand.BrandName, brand.BrandId);
            }
        }

        private static void AddBrandTest(IBrandService brandService)
        {
            brandService.Add(new Brand
            {
                BrandId = 8,
                BrandName = "Lamborgini"
            });
        }

        private static void AddCarTest(ICarService carService)
        {
            carService.Add(new Car
            {
                CarId = 6,
                BrandId = 2,
                ColorId = 4,
                ModelYear = "2021",
                DailyPrice = 550,
                Description = "Hummer"
            });
        }

        private static void GetAllCarTest(ICarService carService)
        {
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
                Console.WriteLine(car.DailyPrice);
            }
        }

        private static void GetCarDetailTest(ICarService carService)
        {
            foreach (var detail in carService.GetCarDetails())
            {
                Console.WriteLine("Car Id : {0}\nBrand Name: {1}\nColor Name: {2}\nDaily Price: {3}\n", detail.CarId, detail.BrandName, detail.ColorName, detail.DailyPrice);
            }
        }
    }
}
