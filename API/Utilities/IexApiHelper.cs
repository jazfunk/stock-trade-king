using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace API.Utilities
{
    public class IexApiHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://cloud.iexapis.com/stable/stock/";
        public string intradayUrl = "/intraday-prices?chartLast=1&token=";
        public string pToken = "pk_05c40d7c1b96480583b08175d1fb4408";

        // Used for full data object from IEX
        // Costs 1pt.
        // Not currently used in this Helper class
        public string quoteUrl = "quote?token=";

        public RestClient SetUrl(string symbol)
        {
            var publicUrl = Path.Combine(baseUrl, symbol);
            var url = Path.Combine(publicUrl, intradayUrl, pToken);
            var restClient = new RestClient(url);
            return restClient;
        }

        // Currently no need for a post requiest in this helper class
        // Here for learning purposes.
        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application.json");
            return restRequest;
        }


        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }
    }
}
