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
            IUserService userService = new UserManager(new EfUserDal());
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            ICustomerService customerService = new CustomerManager(new EfCustomerDal());


            //AddUserTest(userService);
            //AddUsersTest(userService);

            //customerService.Add(new Customer { Id = 1, CompanyName = "A Firması", UserId = 1 });
            //AddCustomersTest(customerService);

            //AddRentalTest(rentalService);

            //GetAllRentals(rentalService);

        }

        private static void GetAllRentals(IRentalService rentalService)
        {
            foreach (var rental in rentalService.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2}", rental.CarId, rental.CustomerId, rental.RentDate);
            }
        }

        private static void AddRentalTest(IRentalService rentalService)
        {
            rentalService.Add(new Rental
            {
                Id = 1,
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now
            });
        }

        private static void AddCustomersTest(ICustomerService customerService)
        {
            customerService.Add(new Customer { Id = 2, CompanyName = "B Firması", UserId = 2 });
            customerService.Add(new Customer { Id = 3, CompanyName = "C Firması", UserId = 3 });
            customerService.Add(new Customer { Id = 4, CompanyName = "D Firması", UserId = 4 });
        }

        private static void AddUsersTest(IUserService userService)
        {
            userService.Add(new User { Id = 2, FirstName = "Ayşe", LastName = "Demir", Email = "a.demir@mail.com", Password = "123456" });
            userService.Add(new User { Id = 3, FirstName = "Ahmet", LastName = "Yılmaz", Email = "a.yilmaz@mail.com", Password = "123456" });
            userService.Add(new User { Id = 4, FirstName = "John", LastName = "Carpenter", Email = "j.carpenter@mail.com", Password = "123456" });
        }

        private static void AddUserTest(IUserService userService)
        {
            userService.Add(new User
            {
                Id = 1,
                FirstName = "Mehmet",
                LastName = "Kaya",
                Email = "kaya@gmail.com",
                Password = "12345"
            });
        }
    }
}
