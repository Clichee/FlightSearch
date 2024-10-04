using RequestNs;
using ResponseNs;
using SearchModuleNs;

Date departDate = new Date(DateTime.Parse("2024-11-01"));

SearchModule search = new SearchModule();
RequestModel request = search.getRequestModel("FRA", "FUK", departDate);

await search.postRequest(search.createUrl, request);





