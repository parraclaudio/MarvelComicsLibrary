using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MarvelComicsLibrary.Domain.Entity.Base
{

    /// <summary>
    /// To notify 
    /// Has the attributes that will respond if a object is valid or not
    /// </summary>
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            ValidationResult = new ValidationResult();
        }

        [BsonIgnore]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public bool Valid => ValidationResult.IsValid;
    }
}
