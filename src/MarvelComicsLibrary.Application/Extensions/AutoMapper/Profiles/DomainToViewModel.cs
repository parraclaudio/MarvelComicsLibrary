using AutoMapper;
using FluentValidation.Results;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using MarvelComicsLibrary.Integration.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Customer, CustomerViewModel>();

            CreateMap<Result, Comic>()
                .ForMember(src => src.Status, opt => opt.MapFrom(o => AvaliableStatus.NotAvaliable))
                .ForMember(src => src.DevolutionDate, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(src => src.CoverImage, opt => opt.MapFrom(o => o.Thumbnail.Path.ToString() + '.' + o.Thumbnail.Extension));

            CreateMap<Comic, ComicViewModel>();

//            CreateMap<List<Comic>, List<ComicViewModel>>();

            CreateMap<ComicQuality, ComicQualityViewModel>();
        }
    }
}
