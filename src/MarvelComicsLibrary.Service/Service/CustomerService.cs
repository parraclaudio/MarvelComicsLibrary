using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using MarvelComicsLibrary.Service.Interface;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseRepository<Customer> _repository;

        public CustomerService(IBaseRepository<Customer> repository)
        {
            _repository = repository;
        }

        public void Add(Customer obj)
        {
            _repository.Insert(obj);
        }

        public List<Customer> GetList()
        {
            return _repository.GetAll();
        }
    }
}
