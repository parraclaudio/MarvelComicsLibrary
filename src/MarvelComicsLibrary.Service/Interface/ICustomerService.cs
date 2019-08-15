using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface ICustomerService
    {
        List<Customer> GetList();

        void Add(Customer obj);
    }
}
