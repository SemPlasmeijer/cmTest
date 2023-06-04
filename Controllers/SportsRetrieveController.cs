using cmTest.Models;
using cmTest.Models.basketball;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using cmTest.Services.interfaces;
using cmTest.Services;


namespace cmTest.Controllers;

[ApiController]
[Route("[controller]")]
public class SportsApiRetrieveController
{
    private readonly ILogger<SportsApiRetrieveController> _logger;

    private IBasketballRetrievalService _BasketballService;

    public SportsApiRetrieveController(ILogger<SportsApiRetrieveController> logger, IBasketballRetrievalService basketballService)
    {
        _logger = logger;
        _BasketballService = basketballService;
    }

    [HttpGet("Status")]
    public async Task<Status> getSportsApiStatus()
    {
        return await _BasketballService.getApiStatus();
    }

    [HttpGet("GamesToday")]
    public async Task<String> getTodaysGamesList()
    {
        //should be datetime.Now but for testing this date will be selected.
        return await _BasketballService.getGamesList(new DateTime(2023, 1, 4));
    }
}