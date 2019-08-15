using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Domain.Entity.Values;
using System;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class Comic : BaseEntity
    {         
        public long ComicId { get; set; }

        public long DigitalId { get; set; }

        public string Title { get; set; }

        public long IssueNumber { get; set; }

        public string Upc { get; set; }

        public AvaliableStatus Status { get; set; }

        public DateTime? DevolutionDate { get; set; }
    }
}
