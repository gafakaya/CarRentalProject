using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, MyDBContext>, ICarImageDal
    {
    }
}
