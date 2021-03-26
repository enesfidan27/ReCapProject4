using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cr in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                                 on cr.BrandId equals b.BrandId
                             join cl in context.Colors
                                 on cr.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = cr.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 CarModelYear = cr.CarModelYear,
                                 CarDescription = cr.CarDescription,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarDailyPrice = cr.CarDailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
