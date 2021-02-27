using Core.Utilities.FileOperation;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult Add(FileOperation file, string filePath, CarImage carImage);
        IResult Delete(string filePath, CarImage carImage);
        IResult Update(FileOperation file,string filePath, CarImage carImage);
    }
}
