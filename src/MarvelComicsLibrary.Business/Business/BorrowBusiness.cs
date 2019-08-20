using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Business
{
    public class BorrowBusiness : IBorrowBusiness
    {
        private readonly IBaseRepository<Borrow> _repository;

        public BorrowBusiness(IBaseRepository<Borrow> repository)
        {
            _repository = repository;
        }

        public Borrow Add(Borrow obj)
        {
            Validate(obj, Activator.CreateInstance<BorrowValidation>());

            if (obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public Borrow Find(Guid key)
        {
            return _repository.GetByKey(key);
        }

        public List<Borrow> GetListByCustomer(Guid customerKey)
        {
            return  _repository.GetAllByExpression(x => x.CustomerKey == customerKey);
        }

        public List<Borrow> GetList()
        {
            return _repository.GetAll();
        }

        public DateTime CalculateReturnDate(long pageCount)
        {
            var daysToRead = pageCount / 4;
            var retDate = DateTime.Now;

            if (daysToRead <= 5)
                daysToRead = 5;

           retDate = retDate.AddDays(daysToRead);

            if (retDate.DayOfWeek == DayOfWeek.Saturday)
                retDate = retDate.AddDays(2);

            if (retDate.DayOfWeek == DayOfWeek.Sunday)
                retDate = retDate.AddDays(1);

            return retDate;
        }

        private void Validate(Borrow obj, AbstractValidator<Borrow> validator)
        {
            obj.ValidationResult = validator.Validate(obj);
        }
    }
}
