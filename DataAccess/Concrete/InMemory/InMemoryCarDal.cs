
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId= 1, ColorId = 1, DailyPrice = 300, ModelYear = "1969", Description = "Antikaların kralı"},
                new Car{CarId=2, BrandId= 1, ColorId = 2, DailyPrice = 1000, ModelYear = "2020", Description = "Hız tutkunları için"},
                new Car{CarId=3, BrandId= 2, ColorId = 1, DailyPrice = 200, ModelYear = "2015", Description = "Günlük ihyaç için birebir"},
                new Car{CarId=4, BrandId= 3, ColorId = 3, DailyPrice = 500, ModelYear = "2021", Description = "Lüksü sevenler gelsin"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;

        }
    }
}
