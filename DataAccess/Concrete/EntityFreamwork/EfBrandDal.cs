using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, MyDBContext>,IBrandDal
    {    
    }
}
