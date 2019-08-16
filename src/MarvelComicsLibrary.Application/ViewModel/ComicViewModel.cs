using MarvelComicsLibrary.Domain.Entity.Values;
using Newtonsoft.Json;
using System;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class ComicViewModel : BaseViewModel
    {
        public long ComicId { get; set; }

        public string Upc { get; set; }

        public string Title { get; set; }

        public long IssueNumber { get; set; }

        public long PageCount { get; set; }

        public string Description { get; set; }        
    }
}
