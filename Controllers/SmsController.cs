using cmTest.Models;
using cmTest.Models.sms;
using cmTest.Models.sms.response;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using cmTest.Services.interfaces;
using cmTest.Services;


namespace cmTest.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController
{
    private readonly ILogger<SportsApiRetrieveController> _logger;
    private IBasketballRetrievalService _BasketballService;
    private ISmsService _SmsService;

    public SmsController(ILogger<SportsApiRetrieveController> logger, IBasketballRetrievalService basketballService, ISmsService smsService)
    {
        _logger = logger;
        _BasketballService = basketballService;
        _SmsService = smsService;
    }

    [HttpPost("SendSms")]
    public async Task<ResponseSms> postTodaysSportsResults([FromBody] NumbersRequest numbersRequest)
    {
        //quick check i think the sms service does its own number validity check otherwise it needs to added sometime
        if (numbersRequest.numbers.Count == 0) {
            new ResponseSms("No numbers were given", 500);
        }

        string matchResults = await _BasketballService.getGamesList(new DateTime(2023, 1, 4));

        return await _SmsService.sendMessage(numbersRequest.numbers, new SmsBody(matchResults));
    }
}