using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface IComicQualityService
    {
        List<ComicQuality> GetList();
        ComicQuality Find(Guid key);

        ComicQuality Add(ComicQuality obj);
    }
}
