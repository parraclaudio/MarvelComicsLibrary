using System;
using System.Collections.Generic;
using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
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

        private void Validate(Comic obj, AbstractValidator<Comic> validator)
        {
            obj.ValidationResult = validator.Validate(obj);
        }
    }
}
