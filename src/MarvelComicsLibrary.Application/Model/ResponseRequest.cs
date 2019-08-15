using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.Model
{
    public class ResponseRequest
    {
        public bool Success { get; set; }
        public List<MessageError> MessageError { get; set; }
        public List<string> Data { get; set; }

        public ResponseRequest(bool _success, IList<ValidationFailure> validationErrors, object data)
        {
            Success = _success;

            MessageError = new List<MessageError>();
            Data = new List<string>();

            if (_success)
            { 
                Data.Add( JsonConvert.SerializeObject(data) );
            }

            foreach (var error in validationErrors)
            {
                MessageError.Add(new MessageError { ErrorCode = error.ErrorCode, Message = error.ErrorMessage });
            }

        }
    }
}
