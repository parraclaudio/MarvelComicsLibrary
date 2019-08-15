using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Integration.Constant
{
    public class MarvelApiConstants
    {
        public const string BaseUrl = "http://gateway.marvel.com/";

        public const string ApiPath = "/v1/public";

        public const string ApiKey = "ff9dda3f4f1d9eed8c2c861394596f63";

        public const string Hash = "179f6347fd3fb89f2def48223cea4e88";

        public const string TimeStamp = "637012374943146952";

        public const string ComicsEndpoint = BaseUrl + ApiPath + "/comics";
    }
}
