using MarvelComicsLibrary.Integration.Constant;
using MarvelComicsLibrary.Integration.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsLibrary.Integration.Factory
{
    public class HttpFactory : IHttpFactory
    {
        public IRestResponse RestHttp(string url, RestRequest request)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

            //Header necessario para Chamada do serviço no cornerstone
            request.AddParameter("ts", MarvelApiConstants.TimeStamp );
            request.AddParameter("apikey", MarvelApiConstants.ApiKey);
            request.AddParameter("hash", MarvelApiConstants.Hash);
            request.AddParameter("titleStartsWith", "Hulk");
            request.AddParameter("format", "Comic");

            //create RestSharp client and POST request object
            var client = new RestClient(url);

            // Common fields for every request
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            //make the API request and return a response
            return client.Execute(request);
        }
    }
}
