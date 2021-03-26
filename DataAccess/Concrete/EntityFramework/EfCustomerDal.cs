using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ct in context.Customers
                             join us in context.Users
                                 on ct.UserId equals us.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = ct.CustomerId,
                                 UserId = us.UserId,
                                 CompanyName = ct.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,

                                 LastName = us.LastName,
                                 Status = us.Status
                             };
                return result.ToList();




            }
        }
    }
}