
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryProjectDal : IProjectDal
    {
        List<Car> _cars;

        public InMemoryProjectDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId= 1, ColorId = 1, DailyPrice = 300, ModelYear = "1969", Description = "Antikaların kralı"},
                new Car{Id=2, BrandId= 1, ColorId = 2, DailyPrice = 1000, ModelYear = "2020", Description = "Hız tutkunları için"},
                new Car{Id=3, BrandId= 2, ColorId = 1, DailyPrice = 200, ModelYear = "2015", Description = "Günlük ihyaç için birebir"},
                new Car{Id=4, BrandId= 3, ColorId = 3, DailyPrice = 500, ModelYear = "2021", Description = "Lüksü sevenler gelsin"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            List<Car> getToCarById = _cars.Where(c => c.Id == carId).ToList();
            return getToCarById;
        }

        public List<Car> OrderByDailyPriceAsc()
        {
            List<Car> OrderByAsc = _cars.OrderBy(c => c.DailyPrice).ToList();
            return OrderByAsc;
        }

        public List<Car> OrderByDailyPriceDesc()
        {
            List<Car> OrderByAsc = _cars.OrderByDescending(c => c.DailyPrice).ToList();
            return OrderByAsc;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;

        }
    }
}
