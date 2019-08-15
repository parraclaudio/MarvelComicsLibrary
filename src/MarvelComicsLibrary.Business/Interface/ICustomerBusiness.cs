﻿using MarvelComicsLibrary.Domain.Entity;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface ICustomerBusiness
    {
        List<Customer> GetList();

        Customer Save(Customer obj);
    }
}
