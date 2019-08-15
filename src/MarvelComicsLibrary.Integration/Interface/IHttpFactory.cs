using RestSharp;

namespace MarvelComicsLibrary.Integration.Interface
{
    public interface IHttpFactory
    {
        IRestResponse RestHttp(string Url, RestRequest Request);
    }
}
