using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class ComicQualityService : IComicQualityService
    {
        private readonly IComicQualityBusiness _comicQA;
        
        public ComicQualityService(IComicQualityBusiness comicQA)
        {
            _comicQA = comicQA;
        }

        public ComicQuality Add(ComicQuality obj)
        {
            return _comicQA.Add(obj);
        }

        public ComicQuality Find(Guid key)
        {
            return _comicQA.Find(key);
        }

        public List<ComicQuality> GetList()
        {
            return _comicQA.GetList();
        }
    }
}
