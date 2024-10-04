using System.Text.Json.Serialization;

namespace RequestNs;

public class RequestQuery 
{
    [JsonPropertyName("query")]
    public RequestModel query { get; set; }
}

public class RequestModel
{
    public string market { get; set; } = "DE";
    public string locale { get; set; } = "de-DE";
    public string currency { get; set; } = "EUR";
    public List<QueryLeg> queryLegs { get; set; }
    public int adults { get; set; } = 1;
    public string cabinClass { get; set; } = "CABIN_CLASS_UNSPECIFIED";
}

public class QueryLeg
{
    public PlaceId originPlaceId { get; set; }
    public PlaceId destinationPlaceId { get; set; }
    public Date date { get; set; } = new Date(DateTime.Today);
}

public class PlaceId
{
    public string iata { get; set; }
    public string entityId { get; set; }

    public PlaceId(string iata)
    {
        this.iata = iata;
    }
}

public class Date
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }

    public Date(DateTime date)
    {
        year = date.Year;
        month = date.Month;
        day = date.Day;
    }
}
