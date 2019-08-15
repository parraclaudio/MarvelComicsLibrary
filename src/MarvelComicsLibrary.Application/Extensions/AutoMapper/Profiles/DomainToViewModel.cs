using AutoMapper;
using FluentValidation.Results;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
