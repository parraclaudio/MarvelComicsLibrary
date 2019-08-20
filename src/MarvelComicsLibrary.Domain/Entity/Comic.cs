using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Domain.Entity.Values;
using System;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class Comic : BaseEntity
    {         
        public long ComicId { get; set; }

        public string Upc { get; set; }

        public string Title { get; set; }

        public long IssueNumber { get; set; }

        public long PageCount { get; set; }

        public string Description { get; set; }

        public AvaliableStatus Status { get; set; }

        public Guid CustomerKey { get; set; }

        public DateTime DevolutionDate { get; set; }
    }
}
