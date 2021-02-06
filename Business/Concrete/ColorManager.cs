using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IEntityService<Color>
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.Name.Length >= 2) 
            {
                _colorDal.Add(color);
            }
            else Console.WriteLine("Color Name must be at least 2 characters");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            //Is Kodları
            //Yetki ve is kontrolleri yapıldıktan sonra aşağıdaki kodlar çalışacak

            return _colorDal.GetAll(); 
        }


        public Color GetById(int Id)
        {
            return _colorDal.Get(p => p.Id == Id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
