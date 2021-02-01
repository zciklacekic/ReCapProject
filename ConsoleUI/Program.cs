using Business.Concrete;
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
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            Car car = new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Description = "A4" };
            productManager.Add(car);

            productManager.PrintAll(productManager.GetAll());

            car.DailyPrice = 699;
            productManager.Update(car);

            productManager.PrintAll(productManager.GetAll());

            productManager.Delete(car);
            productManager.PrintAll(productManager.GetAll());
            Console.WriteLine("-------Cars with ID of 1-----------");
            productManager.PrintAll(productManager.GetById(1));

        }
    }
}
