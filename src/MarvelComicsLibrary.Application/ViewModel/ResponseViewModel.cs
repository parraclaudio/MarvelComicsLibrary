using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class ResponseViewModel
    {
        public bool Success { get; set; }
        public string MessageError { get; set; }
        public string Data { get; set; }
    }
}
