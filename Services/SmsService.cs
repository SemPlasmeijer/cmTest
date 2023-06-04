using cmTest.Models;
using cmTest.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using cmTest.Models.sms;
using cmTest.Models.sms.response;

namespace cmTest.Services;

public class SmsService : ISmsService
{
    private RestClient client = new RestClient("https://gw.cmtelecom.com/v1.0/");
    private readonly IConfiguration _config;
    private readonly ILogger _logger;

    public SmsService(IConfiguration config, ILogger<SmsService> logger)
    {
        _config = config;
        _logger = logger;

        client.AddDefaultHeader("Content-type", "application/json");
    }


    public async Task<ResponseSms> sendMessage(List<ToNumber> numbers, SmsBody smsBody)
    {
        try
        {
            var request = new RestRequest("message");

            MessageRequest messageRequest = createMessage(numbers, smsBody);
            //create json for body
            var jsonRequest = JsonSerializer.Serialize(messageRequest);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(jsonRequest);

            ResponseSms messages = await client.PostAsync<ResponseSms>(request);

            return messages == null ? new ResponseSms("No Message Found", 500) : messages;
        }
        catch (HttpRequestException e)
        {
            return new ResponseSms(e.ToString(), 500);
        }
    }

    public MessageRequest createMessage(List<ToNumber> numbers, SmsBody smsBody)
    {
        //create msg smsbody should be filled already msg needs to be a list in the body for single message add it to empty list
        Msg msg = new Msg(numbers, smsBody);
        List<Msg> msgList = new List<Msg>() { msg };

        //retrieve token from user-secrets
        Authentication auth = new Authentication(_config["CM:ProductToken"]);

        //create complete message
        Messages messages = new Messages(auth, msgList);

        MessageRequest request = new MessageRequest(messages);
        return request;
    }
}