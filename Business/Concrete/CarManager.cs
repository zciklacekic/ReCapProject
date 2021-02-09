using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            var carExist = GetById(car.Id); //Check if the record exist
            if (carExist == null)
            {
                if ((car.Name.Length >= 2) && (car.DailyPrice > 0))
                {
                    _carDal.Add(car);
                }
                else Console.WriteLine("Car Name must be at least 2 characters and Daily Price must be greater than 0");
            }
            else Console.WriteLine("Car with Id "+car.Id+"already exist");
        }

        public void Delete(Car car)
        {
            var carExist = GetById(car.Id); //Check if the record exist
            if (carExist != null)
            {
                _carDal.Delete(car);
            }
            else
            {
                Console.WriteLine("Car with Id " + car.Id + "Does not exist");
            }
        }

        public List<Car> GetAll()
        {
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

        public Car GetById(int Id)
        {
            return _carDal.Get(p => p.Id == Id);
        }

        public void Update(Car car)
        {
            var carExist = GetById(car.Id); //Check if the record exist
            if (carExist != null)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Car with Id " + car.Id + "Does not exist");
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
