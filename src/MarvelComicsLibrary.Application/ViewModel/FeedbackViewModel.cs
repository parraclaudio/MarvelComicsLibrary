using MarvelComicsLibrary.Domain.Entity.Values;
using Newtonsoft.Json;
using System;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class FeedbackViewModel : BaseViewModel
    {
        public Guid CostumerKey { get; set; }
        public Guid ComicKey { get; set; }
        public int Stars { get; set; }
        public string Details { get; set; }
    }
}
