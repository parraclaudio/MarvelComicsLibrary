using FluentValidation;
using MarvelComicsLibrary.Business.Validation.Helper;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Business.Validation
{
    public class ComicValidation : AbstractValidator<Comic>
    {
        public ComicValidation()
        {
          
        }
    }
}
