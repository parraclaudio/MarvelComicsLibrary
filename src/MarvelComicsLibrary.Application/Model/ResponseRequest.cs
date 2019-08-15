using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.Model
{
    public class ResponseRequest
    {
        public bool Success { get; set; }
        public List<MessageError> MessageError { get; set; }
        public string Data { get; set; }

        public ResponseRequest(bool _success, IList<ValidationFailure> validationErrors, object data)
        {
            Success = _success;
            Data = JsonConvert.SerializeObject(data);

            MessageError = new List<MessageError>();
            foreach (var error in validationErrors)
            {
                MessageError.Add(new MessageError { ErrorCode = error.ErrorCode, Message = error.ErrorMessage });
            }

            
        }

    }
}
