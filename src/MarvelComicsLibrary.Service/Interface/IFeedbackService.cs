using MarvelComicsLibrary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Service.Interface
{
    public interface IFeedbackService
    {
        List<Feedback> GetList();
        Feedback Find(Guid key);

        Feedback Add(Feedback obj);
    }
}
