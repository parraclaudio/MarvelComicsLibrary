using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface IComicBusiness
    {
        DateTime CalculateReturnDate(long pageCount, AvaliableStatus status);
        List<Comic> GetListByCustomer(Guid customerKey);
        List<Comic> GetList();
        Comic Find(Guid key);
        Comic Add(Comic obj);
        Comic Amend(Comic obj);
        void Remove(Guid key);
    }
}
