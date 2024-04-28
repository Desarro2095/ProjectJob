using RestSharp;
using System.Threading;

namespace Job.Services
{
    public static class ClientService
    {
        private static RestRequest GetReadyTemplate(string json, Method method)
        {
            
            RestRequest request = new RestRequest();
            request.Method = method;
            request.AddHeader("content-type", "application/json");
            if (!string.IsNullOrEmpty(json))
            {
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }
            return request;
        }

        public static string Get(string uri, string json)
        {
            RestClient client = new RestClient(string.Concat(Resource.UrlBase, uri));
            RestResponse response = client.Execute(GetReadyTemplate(json, Method.Get));
            return response.Content;
        }

        public static string Post(string uri, string json)
        {
            RestClient client = new RestClient(string.Concat(Resource.UrlBase, uri));
            RestResponse response = client.Execute(GetReadyTemplate(json, Method.Post));
            return response.Content;
        }
    }
}
