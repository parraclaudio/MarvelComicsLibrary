using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Business
{
    public class FeedbackBusiness : IFeedbackBusiness
    {
        private readonly IBaseRepository<Feedback> _repository;

        public FeedbackBusiness(IBaseRepository<Feedback> repository)
        {
            _repository = repository;
        }

        public Feedback Add(Feedback obj)
        {
            Validate(obj, Activator.CreateInstance<FeedbackValidation>());

            if (obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public Feedback Find(Guid key)
        {
            return _repository.GetByKey(key);
        }

        public List<Feedback> GetList()
        {
            return _repository.GetAll();
        }

        private void Validate(Feedback obj, AbstractValidator<Feedback> validator)
        {
            obj.ValidationResult = validator.Validate(obj);
        }
    }
}
