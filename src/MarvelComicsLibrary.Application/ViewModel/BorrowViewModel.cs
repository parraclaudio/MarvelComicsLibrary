using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class BorrowViewModel : BaseViewModel
    {
        public Guid CustomerKey { get; set; }

        public Guid ComicKey { get; set; }

    }
}
