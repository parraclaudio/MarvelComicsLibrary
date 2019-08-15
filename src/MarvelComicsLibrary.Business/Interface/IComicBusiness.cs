using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface IComicBusiness
    {
        List<Comic> GetList();
        Comic Find(Guid key);
        Comic Add(Comic obj);
        Comic Amend(Comic obj);
        void Remove(Guid key);
    }
}
