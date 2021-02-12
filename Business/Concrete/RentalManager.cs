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
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (!IsExist(rental.Id).Success)
            {
                if (!IsOnRent(rental.CarId).Success) 
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.RentalAdded);
                }
                return new ErrorResult(Messages.RentalIsOnRent);
            }
            return new ErrorResult(Messages.RentalExists);
        }

        public IResult Delete(Rental brand)
        {
            if (IsExist(brand.Id).Success)
            {
                _rentalDal.Delete(brand);
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalNotFound);
        }

        public IResult EndRental(Rental rental)
        {
            if (IsExist(rental.Id).Success)
            {
                var rentalToUpdate = GetById(rental.Id);
                if (rentalToUpdate.Data.ReturnDate.Equals(null)||rentalToUpdate.Data.ReturnDate.Equals(DateTime.MinValue))
                {
                rental.CarId = rentalToUpdate.Data.CarId;
                rental.CustomerId = rentalToUpdate.Data.CustomerId;
                rental.RentDate = rentalToUpdate.Data.RentDate;
                if ((rental.ReturnDate==null) || (rental.ReturnDate==DateTime.MinValue))
                {
                    rental.ReturnDate = DateTime.Now;
                }
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalEnded);
                }
            }
            return new ErrorResult(Messages.RentalNotFound);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);  
        }


        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id), Messages.RentalListed);
        }

        public IResult IsExist(int rentalId)
        {
            var rentalExist = GetById(rentalId);
            if (rentalExist.Data != null)
            {
                return new SuccessResult(Messages.RentalExists);
            }
            return new ErrorResult(Messages.RentalNotFound);
        }

        public IResult IsOnRent(int carId)
        {
            var isOnRent = false;
            //List<Rental> rentalByCarId = new List<Rental>(_rentalDal.GetAll(p => p.CarId == carId));
            var rentalByCarId = new List<Rental>(_rentalDal.GetAll(p => p.CarId == carId));
            if (rentalByCarId.Count>0)
            {
            foreach (var rental in rentalByCarId)
                {
                if (rental.ReturnDate == DateTime.MinValue)
                    {
                    isOnRent = true;
                    }
                }
            }
            if (isOnRent)
            {
                return new SuccessResult(Messages.RentalIsOnRent);
            }
            return new ErrorResult();
        }

        public IResult Update(Rental rental)
        {
            if (IsExist(rental.Id).Success)
            {
                var rentalToUpdate=GetById(rental.Id);
                if (rental.CarId.Equals(null)||rental.CarId.Equals(0))
                {
                    rental.CarId = rentalToUpdate.Data.CarId;
                }
                if (rental.CustomerId.Equals(null)||rental.CustomerId.Equals(0))
                {
                    rental.CustomerId = rentalToUpdate.Data.CustomerId;
                }
                if (rental.RentDate.Equals(null)||rental.RentDate.Equals(DateTime.MinValue))
                {
                    rental.RentDate = rentalToUpdate.Data.RentDate;
                }
                rental.ReturnDate = DateTime.MinValue;
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalNotFound);
            
        }
    }
}
