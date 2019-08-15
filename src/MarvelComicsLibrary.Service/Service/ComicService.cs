using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class ComicService : IComicService
    {
        private readonly IComicBusiness _comic;
        
        public ComicService(IComicBusiness comic)
        {
            _comic = comic;
        }

        public List<Comic> GetList()
        {
            return _comic.GetList();
        }

        public Comic Find(Guid key)
        {
            return _comic.Find(key);
        }

        public Comic Add(Comic obj)
        {
            return _comic.Add(obj);
        }

        public Comic Amend(Comic obj)
        {
            return _comic.Amend(obj);
        }
        public void Remove(Guid key)
        {
            _comic.Remove(key);
        }
    }
}
