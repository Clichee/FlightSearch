namespace RequestNs;

public class RequestModel
{
    public string market { get; set; } = "DE";
    public string locale { get; set; } = "de-DE";
    public string currency { get; set; } = "EUR";
    public List<Flight> flights { get; set; }
    public int adults { get; set; } = 1;
    public int children { get; set; } = 0;
    public int infants { get; set; } = 0;
    public string cabinClass { get; set; } = "economy";
    public List<string> stops { get; set; } = ["direct", "1stop"];
    public string sort { get; set; } = "cheapest_first";
}

public class Flight
{
    public string fromEntityId { get; set; }
    public string toEntityId { get; set; }
    public string departDate { get; set; }
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
