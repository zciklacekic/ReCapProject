using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------InMemory Product Dal-----------------------");
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());

            //Car car = new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Name = "A4" };
            //productManager.Add(car);

            //productManager.PrintAll(productManager.GetAll());

            //car.DailyPrice = 699;
            //productManager.Update(car);

            //productManager.PrintAll(productManager.GetAll());
            

            //productManager.Delete(car);
            //productManager.PrintAll(productManager.GetAll());
            //Console.WriteLine("-------Cars with ID of 1-----------");
            //productManager.PrintAll(productManager.GetById(1));
            //productManager.PrintAllProducts(productManager.GetAllProducts());
            Console.WriteLine("-------------EFramework with Database Dal-----------------------");
            CarManager carManager = new CarManager(new EfCarDal2());
            //Car _car = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = 2019, Name = "Symbol" };
            //productManager.Add(_car);

            // ----------------------------------------Car Creation-------------------------------------------------
            //List<Car> cars = new List<Car> {
            //new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = 2019, Name = "Symbol" },
            //new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 350, ModelYear = 2019, Name = "Megane" },
            //new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 600, ModelYear = 2019, Name = "A3" },
            //new Car { Id = 4, BrandId = 2, ColorId = 3, DailyPrice = 800, ModelYear = 2019, Name = "A5" },
            //new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 700, ModelYear = 2020, Name = "E200" },
            //new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 1000, ModelYear = 2020, Name = "S500" },
            //};
            //CarManager carManager = new CarManager(new EfCarDal2());
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
            //ColorManager colorManager = new ColorManager(new EfColorDal2());
            //foreach (var color in colors)
            //    {
            //        colorManager.Add(color);
            //    }
            //List<Brand> brands = new List<Brand> {
            //new Brand{Id=1,Name="Renault"},
            //new Brand{Id=2,Name="Audi"},
            //new Brand{Id=3,Name="Mercedes"}
            //};
            //BrandManager brandManager = new BrandManager(new EfBrandDal2());
            //foreach (var brand in brands)
            //{
            //    brandManager.Add(brand);
            //}
            // ----------------------------------------Color And Brand Creation-----------------------------------------

            //foreach (var product in productManager.GetAll())
            Console.WriteLine("Writing the cars with color --------------------" + new ColorManager(new EfColorDal2()).GetById(3).Name);
            foreach (var car in carManager.GetCarsByColorId(3))
            //foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine("Writing the cars with brand --------------------" + new BrandManager(new EfBrandDal2()).GetById(2).Name);
            foreach (var car in carManager.GetCarsByBrandId(2))
            //foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(car.Name);
            }


        }
    }
}
