using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface ICustomerBusiness
    {
        List<Customer> GetList();
        Customer Find(Guid key);
        Customer Add(Customer obj);
        Customer Amend(Customer obj);
        void Remove(Guid key);
    }
}
