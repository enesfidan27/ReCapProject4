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
            //AddCustomers();
            //ShowCustomers();
            //AddUserAndShow();
            //CarDetails();
            //ShowColors();
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = new List<Car>
            {
              new Car {BrandId=5,ColorId=3,CarName="Cybertruck",}
            };
        }

        private static void ShowColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.CarName + "/" + car.ColorName + "/" + car.DailyPrice + "TL");
            }
        }

      /*  private static void AddUserAndShow()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            List<User> users = new List<User>
            {
                new User {FirstName="Enes",LastName="Fidan",Email="enesfidan27@gmail.com",Password="enes67"},
                new User {FirstName="Hakan",LastName="Fidan",Email="hakanfidan12@gmail.com",Password="hakan12"},
                new User {FirstName="Serdar",LastName="Aktolga",Email="nacizane112",Password="serdar123"}
            };
            foreach (var user in users)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
        }

        private static void AddCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            List<Customer> customers = new List<Customer>
            {
                new Customer{CustomerId=1,CompanyName="ÖzfidanDoğalgaz"},
                new Customer{CustomerId=2,CompanyName="EnesHolding"},
                new Customer{CustomerId=3,CompanyName="FidanEmlak"},
                new Customer{CustomerId=4,CompanyName="BNBÇMHolding"}
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
        }*/
    }
}
