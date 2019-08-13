﻿using AutoMapper;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
