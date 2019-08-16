using FluentValidation;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Business.Validation
{
    public class ComicQualityValidation : AbstractValidator<ComicQuality>
    {
        public ComicQualityValidation()
        {
          
        }
    }
}
