using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowBusiness _borrow;
        private readonly IComicBusiness _comic;

        public BorrowService(IBorrowBusiness borrow, IComicBusiness comic)
        {
            _borrow = borrow;
            _comic = comic;
        }

        public List<Borrow> GetList()
        {
            return _borrow.GetList();
        }

        public List<Borrow> GetListByCustomer(Guid customerKey)
        {
            var borrowList = _borrow.GetListByCustomer(customerKey);
            
            foreach (var borrow in borrowList)
            {
                borrow.ComicDetails = _comic.Find(borrow.ComicKey);
                borrow.ComicDetails.DevolutionDate = borrow.DevolutionDate;
            }

            return borrowList;
        }

        public Borrow Find(Guid key)
        {
            return _borrow.Find(key);
        }

        public Borrow Add(Borrow obj)
        {
            var comic = _comic.Find(obj.ComicKey);

            obj.DevolutionDate = _borrow.CalculateReturnDate(comic.PageCount);

            comic.Status = AvaliableStatus.Borrowed;

            _comic.Amend(comic);

            return _borrow.Add(obj);
        }
    }
}
