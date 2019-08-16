using MarvelComicsLibrary.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class ComicQuality : BaseEntity
    {
        //0 a 10
        public int Quality { get; set; }

        public string QualityDetails { get; set; }
    }
}
