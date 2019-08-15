using FluentValidation;
using FluentValidation.Results;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Domain.Validation
{
    public class CustomerValidation : AbstractValidator<Customer> 
    {
        public CustomerValidation()
        {
           /* RuleFor(x => x.Telephone).NotNull().WithMessage("Telefone Invalido");
            RuleFor(x => x.Name).Length(0, 40).WithMessage("Nome Invalido"); 
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Invalido");*/
        }
    }
}
