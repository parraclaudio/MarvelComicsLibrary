using FluentValidation.Validators;
using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Domain.Validation;
using System;

namespace MarvelComicsLibrary.Domain.Entity
{
    /// <summary>
    ///  Customer Entity
    /// </summary>
    public class Customer : BaseEntity
    {
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string Telephone { get; private set; }

        public Customer(string _email,string _cpf, string _name, string _telephone)
        {
            Email = _email;
            Cpf = _cpf;
            Name = _name;
            Telephone = _telephone;

            Validate(this, new CustomerValidation());
        }
    }
}
