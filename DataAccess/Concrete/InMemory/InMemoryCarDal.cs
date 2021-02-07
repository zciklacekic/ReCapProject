using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Color> _colors;
        List<Brand> _brands;
        List<CarDetailDto> _carDetailDtos;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,ModelYear=2019,Name="Symbol"},
            new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=350,ModelYear=2019,Name="Megane"},
            new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=600,ModelYear=2019,Name="A3"},
            new Car{Id=4,BrandId=2,ColorId=3,DailyPrice=800,ModelYear=2019,Name="A5"},
            new Car{Id=5,BrandId=3,ColorId=1,DailyPrice=700,ModelYear=2020,Name="E200"},
            new Car{Id=6,BrandId=3,ColorId=3,DailyPrice=1000,ModelYear=2020,Name="S500"},

            };
            _colors = new List<Color> {
            new Color{Id=1,Name="White"},
            new Color{Id=2,Name="Gray"},
            new Color{Id=3,Name="Navy blue"}
            };
            _brands = new List<Brand> {
            new Brand{Id=1,Name="Renault"},
            new Brand{Id=2,Name="Audi"},
            new Brand{Id=3,Name="Mercedes"}
            };
            _carDetailDtos = (from c in _cars
                            join b in _brands
                            on c.BrandId equals b.Id
                            join co in _colors
                            on c.ColorId equals co.Id
                            select new CarDetailDto 
                                { CarId=c.Id, 
                                  DailyPrice= c.DailyPrice,
                                  CarName = c.Name,
                                  BrandName= b.Name,
                                  ColorName = co.Name
                                 }
                            ).ToList();
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
        public List<Car> GetAllByBrandId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c=> c.Id==car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Name = car.Name;
        }

        public List<CarDetailDto> GetCarDetails()
        {
                return _carDetailDtos;     
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
