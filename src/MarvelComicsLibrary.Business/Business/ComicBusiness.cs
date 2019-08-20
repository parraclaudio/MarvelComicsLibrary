using System;
using System.Collections.Generic;
using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using MarvelComicsLibrary.Integration.Interface;
using MarvelComicsLibrary.Repository.Interface;

namespace MarvelComicsLibrary.Business.Business
{
    public class ComicBusiness : IComicBusiness
    {
        private readonly IBaseRepository<Comic> _repository;

        public ComicBusiness(IBaseRepository<Comic> repository)
        {
            _repository = repository;
        }

        public DateTime CalculateReturnDate(long pageCount, AvaliableStatus status)
        {

            if (status == AvaliableStatus.Avaliable)
                return DateTime.Now;


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

        public Comic Add(Comic obj)
        {
            Validate(obj, Activator.CreateInstance<ComicValidation>());

            if (obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public Comic Amend(Comic obj)
        {
            Validate(obj, Activator.CreateInstance<ComicValidation>());

            if (obj.Valid)
            {
                _repository.Update(obj);
            }

            return obj;
        }

        public Comic Find(Guid key)
        {
            return _repository.GetByKey(key);
        }

        public List<Comic> GetList()
        {
            return _repository.GetAll();
        }

        public void Remove(Guid key)
        {
             _repository.Delete(key);
        }

        public List<Comic> GetListByCustomer(Guid customerKey)
        {
            return _repository.GetAllByExpression(x => x.CustomerKey == customerKey);
        }

        private void Validate(Comic obj, AbstractValidator<Comic> validator)
        {
            obj.ValidationResult = validator.Validate(obj);
        }
    }
}
