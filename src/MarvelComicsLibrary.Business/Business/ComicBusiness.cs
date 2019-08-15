using System;
using System.Collections.Generic;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Integration.Interface;
using MarvelComicsLibrary.Repository.Interface;

namespace MarvelComicsLibrary.Business.Business
{
    public class ComicBusiness : IComicBusiness
    {
        private readonly IBaseRepository<Comic> _repository;

        public ComicBusiness(IBaseRepository<Comic> repository, IMarvelApi marvelApi)
        {
            _repository = repository;
        }

        public Comic Add(Comic obj)
        {
            _repository.Insert(obj);

            return obj;
        }

        public Comic Amend(Comic obj)
        {
            throw new NotImplementedException();
        }

        public Comic Find(Guid key)
        {
            throw new NotImplementedException();
        }

        public List<Comic> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
