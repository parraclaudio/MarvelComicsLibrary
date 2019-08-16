using MarvelComicsLibrary.Domain.Entity.Values;
using Newtonsoft.Json;
using System;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class ComicQualityViewModel : BaseViewModel
    {
        public int Quality { get; set; }

        public string QualityDetails { get; set; }
    }
}
