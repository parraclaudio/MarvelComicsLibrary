using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
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

        public Comic BorrowComic(Guid customerKey, Guid comicKey, AvaliableStatus status)
        {
            var borrowComic = _comic.Find(comicKey);

            borrowComic.CustomerKey = customerKey;
            borrowComic.Status = status;
            borrowComic.DevolutionDate = _comic.CalculateReturnDate(borrowComic.PageCount, status);
        
            return _comic.Amend(borrowComic);
        }

        public List<Comic> GetListByCustomer(Guid customerKey)
        {
            return _comic.GetListByCustomer(customerKey);
        }

        public void Remove(Guid key)
        {
            _comic.Remove(key);
        }
    }
}
