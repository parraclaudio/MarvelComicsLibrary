using FluentValidation;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Business.Validation
{
    public class FeedbackValidation : AbstractValidator<Feedback>
    {
        public FeedbackValidation()
        {
          
        }
    }
}
