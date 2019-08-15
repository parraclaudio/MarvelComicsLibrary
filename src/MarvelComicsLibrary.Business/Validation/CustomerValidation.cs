using FluentValidation;
using MarvelComicsLibrary.Business.Validation.Helper;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Business.Validation
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Telephone).NotNull().WithMessage("Telefone Invalido");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Invalido");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Invalido");
            RuleFor(x => x.Cpf).Must((cpf) => { return CpfValidation.IsValid(cpf); }).WithMessage("CPF Invalido");
        }
    }
}
