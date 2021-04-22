using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car is added.";
        public static string ErrorCarAdded = "The car could not be added.";
        public static string RentalAdded = "Rental is added.";
        public static string ErrorRentalAdded = "Rental could not be added.";
        public static string CustomerAdded = "Customer is added";
        public static string ErrorCustomerAdded = "Customer could not be added.";
        public static string CarCountOfBrandError = "Only 20 cars can be added to a brand.";
        public static string BrandMaxCountError = "Max brand count is must be 15";
        public static string CarIdNotExistError = "This carId not exist";
        public static string CarImageCountError = "One car can only have 5 pictures.";
        public static string CarImageAdded = "Car image is added.";
        public static string CarImageDeleted = "Car image is deleted";
        public static string CarImageNotExist = "This car has not images.";
    }
}
