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
    public class UserManager : IUserService
    {

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            if (!IsExist(user.Id).Success)
            {
                //if (user.LastName.Length >= 2) 
                //{
                    _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
                //}
                //return new ErrorResult(Messages.UserNameInvalid);
            }
            return new ErrorResult(Messages.UserExists);
        }

        public IResult Delete(User user)
        {
            if (IsExist(user.Id).Success)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);  
        }


        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id), Messages.UserListed);
        }

        public IResult IsExist(int userId)
        {
            var userExist = GetById(userId);
            if (userExist.Data != null)
            {
                return new SuccessResult(Messages.UserExists);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IResult Update(User user)
        {
            if (IsExist(user.Id).Success)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            return new ErrorResult(Messages.UserNotFound);
            
        }
    }
}
