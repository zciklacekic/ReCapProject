using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist.Data == null)
            {
                if (brand.Name.Length >= 2) 
                {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
                }
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            return new ErrorResult(Messages.BrandExists);
        }

        public IResult Delete(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist.Data != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            return new ErrorResult(Messages.BrandNotFound);
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);  
        }


        public IDataResult<Brand> GetById(int Id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == Id), Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist.Data != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            return new ErrorResult(Messages.BrandNotFound);
            
        }
    }
}
