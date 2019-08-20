using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface IBorrowService
    {
        List<Borrow> GetList();
        List<Borrow> GetListByCustomer(Guid customerKey);
        Borrow Find(Guid key);
        Borrow Add(Borrow obj);
    }
}
