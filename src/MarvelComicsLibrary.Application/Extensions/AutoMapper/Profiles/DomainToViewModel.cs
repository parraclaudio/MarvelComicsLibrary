using AutoMapper;
using FluentValidation.Results;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using Newtonsoft.Json;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Customer, CustomerViewModel>();

            CreateMap<Customer, ResponseRequest>().ConstructUsing( src => new ResponseRequest( src.Valid, src.ValidationResult.Errors, src) );
        }
    }
}
