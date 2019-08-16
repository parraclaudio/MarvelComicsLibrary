using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface IComicQualityBusiness
    {
        List<ComicQuality> GetList();
        ComicQuality Find(Guid key);

        ComicQuality Add(ComicQuality obj);
    }
}
