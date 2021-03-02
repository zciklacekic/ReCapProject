using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

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
            var result = BusinessRules.Run(IsExist(user.Id));
            if (result == null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            var result = BusinessRules.Run(IsExist(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }


        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            var result = BusinessRules.Run(IsExist(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        private IResult IsExist(int userId)
        {
            var userExist = GetById(userId);
            if (userExist.Data != null)
            {
                return new SuccessResult(Messages.UserExists);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        //public class UserManager : IUserService
        //{
        //    IUserDal _userDal;

        //    public UserManager(IUserDal userDal)
        //    {
        //        _userDal = userDal;
        //    }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
            {
                return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
            }

        //public void Add(User user)
        //{
        //    _userDal.Add(user);
        //}


        //Refactored
        public IDataResult<User> GetByMail(string email)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            }
        //}

    }
}
