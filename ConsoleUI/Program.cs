using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryProjectDal());

            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //    Console.WriteLine(car.BrandId);
            //    Console.WriteLine(car.ColorId);
            //    Console.WriteLine(car.ModelYear);
            //    Console.WriteLine(car.Description);
            //    Console.WriteLine(car.DailyPrice);
            //    Console.WriteLine("\n-----------\n");
            //}

            foreach (var car in carService.OrderByDailyPriceAsc())
            {
                Console.WriteLine(car.DailyPrice);
            }

            foreach (var car in carService.OrderByDailyPriceDesc())
            {
                Console.WriteLine(car.DailyPrice);
            }


        }
    }
}
