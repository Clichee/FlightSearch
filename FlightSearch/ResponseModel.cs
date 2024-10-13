namespace ResponseNs;
public class ResponseModel
{
    public ResponseData data { get; set; }
    public bool status { get; set; }
    public string message { get; set; }
}

public class ResponseData
{
    public List<Itinerary> itineraries { get; set;}
}

public class Itinerary
{
    public string id { get; set; }
    public Price price { get; set; }
    public List<ItineraryLeg> legs { get; set; }
}

public class Price
{
    public double raw { get; set; }
    public string formatted { get; set; }
    public string pricingOptionId { get; set; }
}

public class ItineraryLeg
{
    public string id { get; set; }
    public ItineraryPlace origin { get; set; }
    public ItineraryPlace destination { get; set; }
    public string durationInMinutes { get; set; }
    public int stopcount { get; set; }
    public string departure { get; set; }
    public string arrival { get; set; }
}

public class ItineraryPlace
{
    public string id { get; set; }
    public string entityId { get; set; }
    public string name { get; set; }
    public string displayCode { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public bool isHighlighted { get; set; }
}