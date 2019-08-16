using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Domain.Entity.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class Borrow : BaseEntity
    {
        public Guid ComicKey { get; set; }

        public Guid CustomerKey { get; set; }

        public DateTime DevolutionDate { get; set; }
    }
}
