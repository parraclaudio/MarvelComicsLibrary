using MarvelComicsLibrary.Integration.Constant;
using MarvelComicsLibrary.Integration.Interface;
using MarvelComicsLibrary.Integration.Model;
using Newtonsoft.Json;
using RestSharp;

namespace MarvelComicsLibrary.Integration.Service
{
    public class MarvelApi : IMarvelApi
    {
        private readonly IHttpFactory _httpFactory;

        public MarvelApi(IHttpFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }
        
        public MarvelComic GetComicByUpc(string upc)
        {
            var request = new RestRequest(Method.GET);

            request.AddParameter("upc", upc);

            var response = _httpFactory.RestHttp(MarvelApiConstants.ComicsEndpoint, request);

            return JsonConvert.DeserializeObject<MarvelComic>( response.Content );
        }
    }
}
