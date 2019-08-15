using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(x=> x.Key, opt=> opt.Ignore());

            CreateMap<CustomerViewModel, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.Valid, src.ValidationResult.Errors, src));
        }
    }
}
