using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileOperation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(FileOperation file, string path, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result == null)
            {
                return result;
            }
            result = BusinessRules.Run(CheckCarImageCountLimitReached(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string newImageFileName = RenameFileToGuid(file).Data;

            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;

            UploadImage(file, path, newImageFileName);

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        private static IDataResult<string> RenameFileToGuid(FileOperation file)
        {
            string[] fileNameSplit = file.files.FileName.Split('.');
            var extensionOfFile = "." + fileNameSplit[fileNameSplit.Length - 1];
            var result =
                DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" +
                DateTime.Now.Year.ToString() + "_" +
                Guid.NewGuid().ToString() + extensionOfFile;
            return new SuccessDataResult<string>(result,Messages.CarImageFileNameChanged);
        }

        public IResult Delete(string path, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result != null)
            {
                return result;
            }
            var carImageToDelete = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(path + carImageToDelete.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll().ToList();
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            if (!_carImageDal.GetAll(p => p.CarId == carId).Any())
            {
                if (_carService.IsExist(carId).Success)
                {
                    return new SuccessDataResult<List<CarImage>>(new List<CarImage> {new CarImage {Id = 0,
                    CarId = carId,
                    ImagePath = "DefaultCar.jfif",
                    Date = DateTime.MinValue
                    }
                    }
                    , Messages.CarImageListed);
                }
                return new ErrorDataResult<List<CarImage>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id), Messages.CarImageListed);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(FileOperation file, string path, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result != null)
            {
                return result;
            }
            var carImageToUpdate = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(path + carImageToUpdate.ImagePath);
            string newImageFileName = RenameFileToGuid(file).Data;
            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;
            UploadImage(file, path, newImageFileName);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult IsExist(int carImageId)
        {
            var carImageExist = GetById(carImageId);
            if (carImageExist.Data != null)
            {
                return new SuccessResult(Messages.CarImageExists);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }
        private IResult CheckCarImageCountLimitReached(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.MaxCarImageCountLimit);
            }
            return new SuccessResult();
        }


        private static void UploadImage(FileOperation file, string path, string newImageFileName)
        {
            using (FileStream fileStream = System.IO.File.Create(path + newImageFileName))
            {
                file.files.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
        private static void DeleteImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}
