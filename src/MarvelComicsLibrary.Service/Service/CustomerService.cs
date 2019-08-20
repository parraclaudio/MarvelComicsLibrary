using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerBusiness _customer;
        private readonly IBorrowBusiness _borrow;
        private readonly IComicBusiness _comic;

        public CustomerService( ICustomerBusiness customer, IBorrowBusiness borrow, IComicBusiness comic)
        {
            _comic = comic;
            _customer = customer;
            _borrow = borrow;
        }

        public List<Customer> GetList()
        {
            return _customer.GetList();
        }

        public Customer Find(Guid key)
        {
            return _customer.Find(key);
        }

        public Customer Add(Customer obj)
        {
            return _customer.Add(obj);
        }

        public Customer Amend(Customer obj)
        {
            return _customer.Amend(obj);
        }
        public void Remove(Guid key)
        {
            _customer.Remove(key);
        }

        public Customer GetBorrowsByCustomer(Guid key)
        {
            var customer = _customer.Find(key);

            var borrowList = _borrow.GetListByCustomer(key) ;

            var comicList = new List<Comic>();

            foreach (var borrow in borrowList)
            {
                var comicDetail = _comic.Find(borrow.ComicKey);

                comicDetail.DevolutionDate = borrow.DevolutionDate;

                comicList.Add( comicDetail );
            }

            customer.BorrowedComics = comicList;

            return customer;
        }
    }
}
