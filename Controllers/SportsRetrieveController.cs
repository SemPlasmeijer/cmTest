using cmTest.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

namespace cmTest.Controllers;

[ApiController]
[Route("[controller]")]
public class SportsApiRetrieveController
{
    private readonly IConfiguration _config;
    private readonly ILogger<SportsApiRetrieveController> _logger;

    private RestClient client = new RestClient("https://v3.football.api-sports.io/");


    public SportsApiRetrieveController(IConfiguration config, ILogger<SportsApiRetrieveController> logger)
    {
        _config = config;
        _logger = logger;

        if (config != null)
        {
            client.AddDefaultHeader("x-rapidapi-key", config["SportsApi:ApiKey"]);
            client.AddDefaultHeader("x-rapidapi-host", "v3.football.api-sports.io");
        }
    }

    [HttpGet("Status")]
    public async Task<Status> getSportsApiStatus()
    {
        var request = new RestRequest("status");

        var status = await client.GetAsync<Status>(request);

        return status;
    }
}