﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        T GetByKey(Guid Key);

        Guid GetIdByKey(Guid Key);

        List<T> GetAll();

        void Insert(T obj);

        void Update(T obj);
    }
}
