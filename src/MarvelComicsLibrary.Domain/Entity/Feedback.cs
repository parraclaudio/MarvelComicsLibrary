using MarvelComicsLibrary.Domain.Entity.Base;
using System;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class Feedback : BaseEntity
    {
        public Guid CostumerKey { get; set; }
        public Guid ComicKey { get; set; }
        public int Stars { get; set; }
        public string Details { get; set; }
    }
}
