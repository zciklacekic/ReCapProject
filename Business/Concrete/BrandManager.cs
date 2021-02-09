using Business.Abstract;
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

        public void Add(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist == null)
            {
                if (brand.Name.Length >= 2) 
                {
                _brandDal.Add(brand);
                }
                else Console.WriteLine("Brand Name must be at least 2 characters");
            }
            else Console.WriteLine("Brand with Id " + brand.Id + " already exist");
        }

        public void Delete(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist != null)
            {
                _brandDal.Delete(brand);
            }
            else
            {
                Console.WriteLine("Brand with Id " + brand.Id + " does not exist");
            }
        }

        public List<Brand> GetAll()
        {

            return _brandDal.GetAll(); 
        }


        public Brand GetById(int Id)
        {
            return _brandDal.Get(p => p.Id == Id);
        }

        public void Update(Brand brand)
        {
            var brandExist = GetById(brand.Id); //Check if the record exist
            if (brandExist != null)
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Brand with Id " + brand.Id + " does not exist");
            }
        }
    }
}
