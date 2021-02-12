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
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (!IsExist(customer.Id).Success)
            {
                if (customer.CompanyName.Length >= 2) 
                {
                    _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
                }
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            return new ErrorResult(Messages.CustomerExists);
        }

        public IResult Delete(Customer customer)
        {
            if (IsExist(customer.Id).Success)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);  
        }


        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == Id), Messages.CustomerListed);
        }

        public IResult IsExist(int customerId)
        {
            var customerExist = GetById(customerId);
            if (customerExist.Data != null)
            {
                return new SuccessResult(Messages.CustomerExists);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }

        public IResult Update(Customer customer)
        {
            if (IsExist(customer.Id).Success)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerNotFound);
            
        }
    }
}
