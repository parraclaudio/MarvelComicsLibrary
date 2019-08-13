using System.Collections.Generic;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;

namespace MarvelComicsLibrary.Business.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly IBaseRepository<Customer> _repository;

        public CustomerBusiness(IBaseRepository<Customer> repository)
        {
            _repository = repository;
        }

        public bool Add(Customer obj)
        {
            return _repository.Insert(obj);
        }

        public List<Customer> GetList()
        {
            return _repository.QueryAll();
        }
    }
}
