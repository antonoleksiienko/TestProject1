using RestSharp;

namespace TestProject2
{
    public class ApiService
    {
        private readonly RestClient _restClient;

        public ApiService(Config config)
        {
            _restClient = new RestClient(config.Url);
        }

        public RestResponse GetLoginFailTotalRequest(string? userName = null, int? failCount = null, int? fetchLimit = null, string? token = null)
        {
            RestRequest request = new("/loginfailtotal", Method.Get);

            if (token != null)
            {
                request.AddHeader("Authorization", token);
            }

            if (userName != null)
            {
                request.AddQueryParameter("user_name", userName);
            }

            if (failCount != null)
            {
                request.AddQueryParameter("fail_count", failCount.ToString());
            }

            if (fetchLimit != null)
            {
                request.AddQueryParameter("fetch_limit", fetchLimit.ToString());
            }

            RestResponse restResponse = _restClient.Execute(request);
            return restResponse;
        }

        public RestResponse ResetLoginFailTotalRequest(string userName, string? token = null)
        {
            RestRequest request = new("/resetloginfailtotal", Method.Put);

            if (token != null)
            {
                request.AddHeader("Authorization", token);
            }

            request.AddQueryParameter("Username", userName);
            RestResponse restResponse = _restClient.Execute(request);
            return restResponse;
        }
    }
}
