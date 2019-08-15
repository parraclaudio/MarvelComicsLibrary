using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class BaseViewModel
    {
        public Guid Key { get; private set; }
        [JsonIgnore]
        public bool Valid { get; private set; }
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
    }
}
