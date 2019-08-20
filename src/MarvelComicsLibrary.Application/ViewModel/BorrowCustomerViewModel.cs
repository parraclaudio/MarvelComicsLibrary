using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Application.ViewModel
{
    public class BorrowCustomerViewModel 
    {
        public Guid CustomerKey { get; set; }

        public List<ComicViewModel> Comics { get; set; }
    }
}
