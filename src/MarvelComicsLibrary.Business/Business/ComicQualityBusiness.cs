using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Business
{
    public class ComicQualityBusiness : IComicQualityBusiness
    {
        private readonly IBaseRepository<ComicQuality> _repository;

        public ComicQualityBusiness(IBaseRepository<ComicQuality> repository)
        {
            _repository = repository;
        }

        public ComicQuality Add(ComicQuality obj)
        {
            Validate(obj, Activator.CreateInstance<ComicQualityValidation>());

            if (obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public ComicQuality Find(Guid key)
        {
            return _repository.GetByKey(key);
        }

        public List<ComicQuality> GetList()
        {
            return _repository.GetAll();
        }

        private void Validate(ComicQuality obj, AbstractValidator<ComicQuality> validator)
        {
            obj.ValidationResult = validator.Validate(obj);
        }
    }
}
