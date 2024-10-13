using Newtonsoft.Json;
using RequestNs;
using ResponseNs;
using System.Net.Http.Headers;

namespace SearchModuleNs;

public class SearchModule
{
    static HttpClient client = new HttpClient();

    private readonly HttpMethod method = HttpMethod.Post;
    private readonly Uri skyscannerUri = new Uri("https://sky-scanner3.p.rapidapi.com/flights/search-multi-city");


    public HttpRequestMessage GetRequestMessage(string content) 
    {
        return new HttpRequestMessage
        {
            Method = this.method,
            RequestUri = this.skyscannerUri,
            Headers =
            {
                { "x-rapidapi-key", "<<RAPID-API-KEY>>" },
                { "x-rapidapi-host", "sky-scanner3.p.rapidapi.com" },
            },
            Content = new StringContent(content)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            }
        };
    }

    public RequestModel getRequestModel(string originIata, string destIata, string departDate)
    {
        Flight flight = new Flight()
        {
            fromEntityId = originIata,
            toEntityId = destIata,
            departDate = departDate
        };

        return new RequestModel()
        {
            flights = [flight]
        };
    }

    public async Task<ResponseModel> postRequest(string uri, RequestModel request)
    {
        string content = JsonConvert.SerializeObject(request);
        HttpRequestMessage requestMessage = GetRequestMessage(content);
        HttpResponseMessage response = null;

        try
        {
            response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.ToString()}");
            return null;
        }

        string responseJson = await response.Content.ReadAsStringAsync();
        ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
        return responseModel ?? null;
    }
}
