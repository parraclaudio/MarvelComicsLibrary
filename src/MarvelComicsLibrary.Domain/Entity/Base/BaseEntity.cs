using FluentValidation;
using FluentValidation.Results;
using MarvelComicsLibrary.Domain.Interface;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MarvelComicsLibrary.Domain.Entity.Base
{
    /// <summary>
    ///  Base Entity
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Key = Guid.NewGuid();
        }

        //Collection Database ID
        public Guid Id { get; set; }

        //Application ID
        public Guid Key { get;  set; }

        [BsonIgnore]
        public ValidationResult ValidationResult { get;  set; }

        [BsonIgnore]
        public bool Valid { get; set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        { 
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
