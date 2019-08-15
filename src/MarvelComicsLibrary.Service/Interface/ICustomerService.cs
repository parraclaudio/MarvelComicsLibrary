using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface ICustomerService
    {
        List<Customer> GetList();
        Customer Find(Guid key);
        void Add(Customer obj);
        void Amend(Customer obj);
        void Remove(Guid key);
    }
}
