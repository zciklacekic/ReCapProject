using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (!IsExist(car.Id).Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarExists);
        }

        public IResult Delete(Car car)
        {
            if (IsExist(car.Id).Success)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new SuccessResult(Messages.CarNotFound);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id), Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            if (IsExist(car.Id).Success)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

            return new ErrorResult(Messages.CarNotFound);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IResult IsExist(int carId)
        {
            var carExist = GetById(carId);
            if (carExist.Data != null)
            {
                return new SuccessResult(Messages.CarExists);
            }
            return new ErrorResult(Messages.CarNotFound);
        }
    }
}
