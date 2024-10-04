using RequestNameSpace;
using ResponseNameSpace;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

public class FlightSearch
{
    static HttpClient client = new HttpClient();

    public async Task<ResponseModel> postRequest(string uri, RequestModel request)
    {
        string content = JsonSerializer.Serialize(request);
        HttpResponseMessage response = await client.PostAsJsonAsync(uri, content);

        try
        {
            response.EnsureSuccessStatusCode();
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.ToString()}");
            return null;
        }

        ResponseModel responseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();

        return responseModel ?? null;
    }
}




