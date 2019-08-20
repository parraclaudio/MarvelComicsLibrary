using MarvelComicsLibrary.Domain.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace MarvelComicsLibrary.Domain.Entity
{
    public class Borrow : BaseEntity
    {
        public Guid ComicKey { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Comic ComicDetails {get;set;}

        public Guid CustomerKey { get; set; }

        public DateTime DevolutionDate { get; set; }
    }
}
