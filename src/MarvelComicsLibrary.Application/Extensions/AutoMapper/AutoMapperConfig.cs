using AutoMapper;
using MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicsLibrary.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(p =>
            {
                p.AddProfile(new DomainToViewModel());
                p.AddProfile(new ViewModelToDomain());
            });
        }

    }
}
