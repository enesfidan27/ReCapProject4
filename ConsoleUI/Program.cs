using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Galerideki Tüm Araçlar:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model/" + car.Description + ":" + car.DailyPrice + "TL");
            }
            Console.WriteLine("----------------------------");

            Car car1 = new Car() { BrandId = 1, DailyPrice = 250, Description = "Model3", ColorId = 2, ModelYear = 2020 };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model/" + car.Description + ":" + car.DailyPrice + "TL");
            }
            //Delete(carManager, car1);
            Console.WriteLine("-----------------------");
            
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+"/"+car.CarName+"/"+car.ColorName+"/"+car.DailyPrice);
            }

        }

        private static void Delete(CarManager carManager, Car car1)
        {
            Console.WriteLine("--------------------------------");
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model/" + car.Description + ":" + car.DailyPrice + "TL");
            }
        }
    }
}
