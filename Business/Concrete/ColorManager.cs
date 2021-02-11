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
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist.Data == null)
            {
                if (color.Name.Length >= 2)
                {
                    _colorDal.Add(color);
                    return new SuccessResult(Messages.ColorAdded);
                }
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            return new ErrorResult(Messages.ColorExists);
        }

        public IResult Delete(Color color)
        {
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist.Data != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            return new ErrorResult(Messages.ColorNotFound);
        }

        public IDataResult<List<Color>> GetAll()
        {
            //Is Kodları
            //Yetki ve is kontrolleri yapıldıktan sonra aşağıdaki kodlar çalışacak

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed); 
        }


        public IDataResult<Color> GetById(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.Id == Id),Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            var colorExist = GetById(color.Id); //Check if the record exist
            if (colorExist.Data != null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            return new ErrorResult(Messages.ColorNotFound);
        }
    }
}
