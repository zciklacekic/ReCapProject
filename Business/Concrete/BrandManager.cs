using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (!IsExist(brand.Id).Success)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            return new ErrorResult(Messages.BrandExists);
        }

        public IResult Delete(Brand brand)
        {
            if (IsExist(brand.Id).Success)
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

        public IResult IsExist(int brandId)
        {
            var brandExist = GetById(brandId);
            if (brandExist.Data != null)
            {
                return new SuccessResult(Messages.BrandExists);
            }
            return new ErrorResult(Messages.BrandNotFound);
        }

        public IResult Update(Brand brand)
        {
            
            //var brandExist = GetById(brand.Id); //Check if the record exist
            if (IsExist(brand.Id).Success)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            return new ErrorResult(Messages.BrandNotFound);
            
        }
    }
}
