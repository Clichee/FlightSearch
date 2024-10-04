namespace RequestNameSpace;

public class RequestModel
{
    public string market { get; set; } = "DE";
    public string locale { get; set; } = "de-DE";
    public string currency { get; set; } = "EUR";
    public List<queryLeg> queryLegs { get; set; }
    public int adults { get; set; } = 1;
}

public class queryLeg
{
    public placeId originPlaceId { get; set; }
    public placeId destinationPlaceId { get; set; }
    public Date date { get; set; } = new Date(DateTime.Today);
}

public class placeId
{
    public string iata { get; set; }
    public string entityId { get; set; }
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
