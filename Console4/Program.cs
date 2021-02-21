using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Console4
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddRentals();
            //ShowCustomers();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            List<Customer> customers = new List<Customer>
            {
                new Customer{CustomerId=1,CompanyName="Özfidan Doğalgaz"},
                new Customer{CustomerId=2,CompanyName="Enes Holding"},
                new Customer{CustomerId=3,CompanyName="Fidan Emlak"},
                new Customer{CustomerId=4,CompanyName="BNBÇM Holding"}
            };
            foreach (var customer in customers)
            {
                customerManager.Add(customer);
            }
        }

        private static void ShowCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customers = customerManager.GetAll();
            foreach (var customer in customers.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void AddRentals()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            List<Rental> rentals = new List<Rental>
            {
                new Rental{Id=1,CarId=3,CustomerId=1,RentDate="20.02.2021",ReturnDate=null},
                new Rental{Id=2,CarId=2,CustomerId=2,RentDate="15.02.2021",ReturnDate="20.02.2021"},
                new Rental{Id=3,CarId=1,CustomerId=3,RentDate="11.02.2021",ReturnDate="13.02.2021"}
            };
            foreach (var rental in rentals)
            {
                rentalManager.Add(rental);

            }
        }
    }
}
