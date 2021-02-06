using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Car> GetAll();
        //List<CarWCB> GetAllProducts();
        List<Car> GetById(int carId);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        //void PrintAll(List<Car> cars);
        //void PrintAllProducts(List<CarWCB> products);
    }

}
