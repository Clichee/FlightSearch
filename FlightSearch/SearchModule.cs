using RequestNs;
using ResponseNs;
using System.Net.Http.Json;
using System.Text.Json;

namespace SearchModuleNs;

public class SearchModule
{
    static HttpClient client = new HttpClient();
    public readonly string createUrl = "https://partners.api.skyscanner.net/apiservices/v3/flights/live/search/create";
    private readonly string pollUrl = "https://partners.api.skyscanner.net/apiservices/v3/flights/live/search/poll/{sessionToken}";

    public RequestModel getRequestModel(string originIata, string destIata, Date departDate)
    {
        PlaceId origin = new PlaceId(originIata);
        PlaceId dest = new PlaceId(destIata);

        QueryLeg queryLeg = new QueryLeg()
        {
            originPlaceId = origin,
            destinationPlaceId = dest,
            date = departDate
        };

        RequestModel requestModel = new RequestModel()
        {
            queryLegs = [queryLeg]
        };

        return requestModel;
    }

    public async Task<ResponseModel> postRequest(string uri, RequestModel request)
    {
        RequestQuery requestQuery = new RequestQuery()
        {
            query = request
        };

        return await postRequest(uri,requestQuery);
    }

    public async Task<ResponseModel> postRequest(string uri, RequestQuery request)
    {
        string content = JsonSerializer.Serialize(request);
        HttpResponseMessage response = null;

        try
        {
            response = await client.PostAsJsonAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.ToString()}");
            return null;
        }

        string responseJson = await response.Content.ReadAsStringAsync();
        ResponseModel responseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();

        return responseModel ?? null;
    }
}
