using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface IBorrowBusiness
    {
        List<Borrow> GetList();
        Borrow Find(Guid key);
        Borrow Add(Borrow obj);
        DateTime CalculateReturnDate(long pageCount);
    }
}
