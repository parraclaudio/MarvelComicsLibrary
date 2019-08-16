using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Business.Interface
{
    public interface IFeedbackBusiness
    {
        List<Feedback> GetList();
        Feedback Find(Guid key);

        Feedback Add(Feedback obj);
    }
}
