using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface IComicService
    {
        List<Comic> GetList();
        Comic Find(Guid key);
        Comic Add(Comic obj);
        Comic Amend(Comic obj);
        void Remove(Guid key);
    }
}
