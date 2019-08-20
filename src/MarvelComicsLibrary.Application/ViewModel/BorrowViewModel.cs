using MarvelComicsLibrary.Domain.Entity.Values;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class BorrowViewModel 
    {
        public Guid CustomerKey { get; set; }

        public Guid ComicKey { get; set; }

        public AvaliableStatus status { get; set; }
    }
}
