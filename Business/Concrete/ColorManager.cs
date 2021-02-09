using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist == null)
            {
                if (color.Name.Length >= 2)
                {
                    _colorDal.Add(color);
                }
                else Console.WriteLine("Color Name must be at least 2 characters");
            }
            else Console.WriteLine("Color with Id " + color.Id + " already exist");
        }

        public void Delete(Color color)
        {
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist != null)
            {
                _colorDal.Delete(color);
            }
            else
            {
                Console.WriteLine("Color with Id " + color.Id + " does not exist");
            }
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
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist != null)
            {
                _colorDal.Update(color);
            }
            else
            {
                Console.WriteLine("Color with Id " + color.Id + " does not exist");
            }
        }
    }
}
