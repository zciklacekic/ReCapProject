using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Car car)
        {
            PrintAll(new List<Car> { car });
            Console.WriteLine("----------Added");
            _productDal.Add(car);
        }

        public void Delete(Car car)
        {
            PrintAll(new List<Car> { car });
            Console.WriteLine("----------Deleted");
            _productDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Car> GetById(int carId)
        {
            return _productDal.GetById(carId);
        }

        public void PrintAll(List<Car> cars)
        {
            Console.WriteLine("-------------------------------");
            foreach (var product in cars)
            {
                Console.WriteLine(product.Id + " " + product.BrandId + " " + product.ColorId + " " + product.DailyPrice + " " + product.ModelYear + " " + product.Description);
            }
        }

        public void Update(Car car)
        {
            PrintAll(new List<Car> { car });
            Console.WriteLine("----------Updated");
            _productDal.Update(car);
        }

    }
}
