using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IEntityService<Brand>
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.Name.Length >= 2) 
            {
                _brandDal.Add(brand);
            }
            else Console.WriteLine("Brand Name must be at least 2 characters");
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
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
            _brandDal.Update(brand);
        }
    }
}
