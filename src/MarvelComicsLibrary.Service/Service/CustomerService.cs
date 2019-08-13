using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerBusiness _business;
        public CustomerService(ICustomerBusiness business)
        {
            _business = business;
        }

        public bool Add(Customer obj)
        {
            return _business.Add(obj);
        }

        public List<Customer> GetList()
        {
            return _business.GetList();
        }
    }
}
