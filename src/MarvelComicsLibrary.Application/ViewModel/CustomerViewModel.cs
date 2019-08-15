using Newtonsoft.Json;
using System;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {  
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
