﻿

using AutoMapper;
using MarvelComicsLibrary.Application.AutoMapper;

namespace MarvelComicsLibrary.Test.Config
{
    public class AutoMapperConfigTest
    {
       public static IMapper GetInstance()
        {
            var mapperConfig = AutoMapperConfig.Register();
            return mapperConfig.CreateMapper();
        }
    }
}
