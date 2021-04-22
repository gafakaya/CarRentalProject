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
            //ICarService carService = new CarManager(new EfCarDal());
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

        
    }
}
