using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        List<T> QueryAll();

        bool Insert(T obj);
    }
}
