using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryGetTest();
            //InMemoryAddTest();
            //InMemoryGetByIdTest();
            //InMemoryUpdateTest();
            //InMemoryDeleteTest();
            //InMemoryGetDetailsTest();


            //EfGetTest();
            //EfAddTest();
            //EfUpdateTest();
            //EfGetByIdTest();
            //EfDeleteTest();
            //EfGetDetailsTest();


            // ----------------------------------------Car Creation-------------------------------------------------
            //List<Car> cars = new List<Car> {
            //new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = 2019, Name = "Symbol" },
            //new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 350, ModelYear = 2019, Name = "Megane" },
            //new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 600, ModelYear = 2019, Name = "A3" },
            //new Car { Id = 4, BrandId = 2, ColorId = 3, DailyPrice = 800, ModelYear = 2019, Name = "A5" },
            //new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 700, ModelYear = 2020, Name = "E200" },
            //new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 1000, ModelYear = 2020, Name = "S500" },
            //};
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in cars)
            //{
            //    carManager.Add(car);
            //}
            // ----------------------------------------Car Creation-------------------------------------------------

            // ----------------------------------------Color And Brand Creation-----------------------------------------
            //List<Color> colors = new List<Color>
            //{
            //    new Color {Id=1,Name="White"},
            //    new Color {Id=2,Name="Gray"},
            //    new Color {Id=3,Name="NavyBlue"}
            //};
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colors)
            //    {
            //        colorManager.Add(color);
            //    }
            //List<Brand> brands = new List<Brand> {
            //new Brand{Id=1,Name="Renault"},
            //new Brand{Id=2,Name="Audi"},
            //new Brand{Id=3,Name="Mercedes"}
            //};
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brands)
            //{
            //    brandManager.Add(brand);
            //}
            // ----------------------------------------Color And Brand Creation-----------------------------------------
            //Change Add to Delete or Update to delete or update color and brands



        }

        private static void EfGetDetailsTest()
        {
            Console.WriteLine("-------------Entity Framework Get Details-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            List<CarDetailDto> carDetails = carManager.GetCarDetails().Data;
            PrintDetailsTest(carDetails);
        }

        private static void EfDeleteTest()
        {
            Console.WriteLine("-------------Entity Framework Car Delete-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { Id = 7 };
            carManager.Delete(car); //Only Id is needed
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void EfGetByIdTest()
        {
            Console.WriteLine("-------------Entity Framework Get By Id-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = new List<Car> { carManager.GetById(3).Data };


            PrintTest(cars);
        }

        private static void EfUpdateTest()
        {
            Console.WriteLine("-------------Entity FrameWork Car Update-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 699, ModelYear = 2018, Name = "A4" };
            carManager.Update(car);
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void EfAddTest()
        {
            Console.WriteLine("-------------Entity FrameWork Car Add-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Name = "A4" };
            carManager.Add(car);
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
            
        }

        private static void EfGetTest()
        {
            Console.WriteLine("-------------Entity FrameWork Car Get-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void InMemoryGetDetailsTest()
        {
            Console.WriteLine("-------------InMemory Get Details-----------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<CarDetailDto> carDetails = carManager.GetCarDetails().Data;
            PrintDetailsTest(carDetails);
        }

        private static void PrintDetailsTest(List<CarDetailDto> carDetails)
        {
            Console.WriteLine("| Id |     Brand |     Name   |     Color  |   DailyPrice |");
            foreach (var item in carDetails)
            {

                Console.WriteLine("|{0,3} |{1,10} | {2,10} | {3,10} | {4,10}   |",
                    item.CarId, item.BrandName, item.CarName, item.ColorName, item.DailyPrice);
            }
        }

        private static void InMemoryDeleteTest()
        {
            Console.WriteLine("-------------InMemory Car Delete-----------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car = new Car { Id = 6 };
            carManager.Delete(car); //Only Id is needed
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void InMemoryUpdateTest()
        {
            Console.WriteLine("-------------InMemory Car Update-----------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car = new Car { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Name = "A4" };
            car.DailyPrice = 699;
            carManager.Update(car);
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void InMemoryGetByIdTest()
        {
            Console.WriteLine("-------------InMemory Get By Id-----------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars = new List<Car> { carManager.GetById(3).Data };


            PrintTest(cars);
        }

        private static void InMemoryAddTest()
        {
            Console.WriteLine("-------------InMemory Car Add---------------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car = new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Name = "A4" };
            carManager.Add(car);
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void InMemoryGetTest()
        {
            Console.WriteLine("-------------InMemory Get All-----------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars = carManager.GetAll().Data;
            PrintTest(cars);
        }

        private static void PrintTest(List<Car> cars)
        {

            Console.WriteLine("| Id |     Name  | BrandId | ColorId | DailyPrice | ModelYear |");
            foreach (var item in cars)
            {
                Console.WriteLine("|{0,3} |{1,10} | {2,7} | {3,7} | {4,10} | {5,9} |",
                    item.Id, item.Name, item.BrandId, item.ColorId, item.DailyPrice, item.ModelYear);

            }
        }
    }
}
