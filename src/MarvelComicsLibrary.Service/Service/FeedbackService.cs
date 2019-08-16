using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackBusiness _comicQA;
        
        public FeedbackService(IFeedbackBusiness comicQA)
        {
            _comicQA = comicQA;
        }

        public Feedback Add(Feedback obj)
        {
            return _comicQA.Add(obj);
        }

        public Feedback Find(Guid key)
        {
            return _comicQA.Find(key);
        }

        public List<Feedback> GetList()
        {
            return _comicQA.GetList();
        }
    }
}
