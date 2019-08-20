using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface IComicService
    {
        Comic BorrowComic(Guid customerKey, Guid comicKey, AvaliableStatus status);
        List<Comic> GetListByCustomer(Guid customerKey);
        List<Comic> GetList();
        Comic Find(Guid key);
        Comic Add(Comic obj);
        Comic Amend(Comic obj);
        void Remove(Guid key);
    }
}
