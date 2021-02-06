using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //public class ProductManager : IProductService
    //{
    //    //IProductDal _productDal;
    //    IProductDal2 _productDal2;

    //    public ProductManager(IProductDal2 productDal2)
    //    {
    //        _productDal2 = productDal2;

    //    }

    //    public void Add(Car car)
    //    {
    //        PrintAll(new List<Car> { car });
    //        Console.WriteLine("----------Added");
    //        _productDal2.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        PrintAll(new List<Car> { car });
    //        Console.WriteLine("----------Deleted");
    //        _productDal2.Delete(car);
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _productDal2.GetAll();
    //    }

    //    public List<Car> GetAllByColorId(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<CarWCB> GetAllProducts()
    //    {
    //        return _productDal2.GetAllProducts();
    //    }

    //    public List<Car> GetById(int carId)
    //    {
    //        return _productDal2.GetById(carId);
    //    }

    //    public void PrintAll(List<Car> cars)
    //    {
    //        Console.WriteLine("-------------------------------");
    //        foreach (var product in cars)
    //        {
    //            Console.WriteLine(product.Id + " " + product.BrandId + " " + product.ColorId + " " + product.DailyPrice + " " + product.ModelYear + " " + product.Name);
    //        }
    //    }

    //    public void PrintAllProducts(List<CarWCB> products)
    //    {
    //        Console.WriteLine("-------------------------------");
    //        foreach (var product in products)
    //        {
    //            Console.WriteLine(product.Id + " " + product.BrandId + " " + product.ColorId + " " + product.DailyPrice + " " + product.ModelYear + " " + product.ColorName + " " + product.BrandName + " " + product.Name);
    //        }
    //    }

    //    public void Update(Car car)
    //    {
    //        PrintAll(new List<Car> { car });
    //        Console.WriteLine("----------Updated");
    //        _productDal2.Update(car);
    //    }

    //    List<Car> IProductService.GetAllByCategoryId(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class ProductManager : IProductService
    {
        ICarDal _carDal;

        public ProductManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if ((car.Name.Length >=2) && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
            }
            else Console.WriteLine("Car Name must be at least 2 characters and Daily Price must be greater than 0");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //Is Kodları
            //Yetki ve is kontrolleri yapıldıktan sonra aşağıdaki kodlar çalışacak

            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetById(int Id)
        {
            return _carDal.GetAll(p => p.Id == Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
