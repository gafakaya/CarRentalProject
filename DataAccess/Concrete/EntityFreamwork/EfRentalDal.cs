using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDBContext context = new MyDBContext())
            {
                var result = from r in context.Rentals
                             join u in context.Users
                             on r.UserId equals u.UserId
                             join ca in context.Cars
                             on r.CarId equals ca.CarId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = br.BrandName,
                                 Customer = u.FirstName + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();

            }
        }
    }
}
