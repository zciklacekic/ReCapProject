using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Car> _cars;

        public InMemoryProductDal(List<Car> cars)
        {
            _cars = new List<Car> { 
            new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,ModelYear=2019,Description="Symbol"},
            new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=350,ModelYear=2019,Description="Megane"},
            new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=600,ModelYear=2019,Description="A3"},
            new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=800,ModelYear=2019,Description="A5"},
            new Car{Id=4,BrandId=3,ColorId=1,DailyPrice=700,ModelYear=2020,Description="E200"},
            new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=1000,ModelYear=2020,Description="S500"},

            };
        }
        List<Color> _colors;

        public InMemoryProductDal(List<Color> colors)
        {
            _colors = new List<Color> { 
            new Color{ColorId=1,ColorName="White"},
            new Color{ColorId=2,ColorName="Gray"},
            new Color{ColorId=3,ColorName="Navy blue"}
            };
        }

        List<Brand> _brands;

        public InMemoryProductDal(List<Brand> brands)
        {
            _brands = new List<Brand> { 
            new Brand{BrandId=1,BrandName="Renault"},
            new Brand{BrandId=2,BrandName="Audi"},
            new Brand{BrandId=3,BrandName="Mercedes"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=> c.Id==carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c=> c.Id==car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
