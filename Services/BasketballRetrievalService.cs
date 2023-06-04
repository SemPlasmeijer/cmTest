using cmTest.Models;
using cmTest.Models.basketball;
using cmTest.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using cmTest.Models.enums;

namespace cmTest.Services;

public class BasketballRetrievalService : IBasketballRetrievalService
{
    private RestClient client = new RestClient("https://v1.basketball.api-sports.io/");

    private readonly IConfiguration _config;

    private readonly ILogger _logger;

    public BasketballRetrievalService(IConfiguration config, ILogger<BasketballRetrievalService> logger)
    {
        _logger = logger;
        _config = config;

        if (config != null)
        {
            client.AddDefaultHeader("x-rapidapi-key", config["SportsApi:ApiKey"]);
            client.AddDefaultHeader("x-rapidapi-host", "v1.basketball.api-sports.io");
        }
    }

    public async Task<Status> getApiStatus()
    {
        var request = new RestRequest("status");

        return await client.GetAsync<Status>(request);
    }

    public async Task<string> getGamesList(DateTime? date, leagues league = leagues.NBA)
    {

        if (date == null) date = DateTime.Now;

        try
        {
            var request = new RestRequest("games");
            var parameters = new
            {
                date = date?.ToString("yyyy-MM-dd"),
                league = (int)leagues.NBA,

                //for the sake of time we just assume you only want to retrieve games of the current season
                //otherwise this can resolved in the front end or directly asked of the user.
                season = date?.AddYears(-1).ToString("yyyy") + "-" + date?.ToString("yyyy"),
            };

            request.AddObject(parameters);

            GamesList? games = await client.GetAsync<GamesList>(request);

            return transformGamesListToString(games);

        }
        catch (Exception e)
        {
            return e.ToString();
        }

    }

    public string transformGamesListToString(GamesList games)
    {
        //loop through all games if response has a length of zero no games where played that day;
        try
        {
            if (games == null) throw new NullReferenceException("No Games Where Retrieved");
            if (games.response.Count == 0) return "No Games were played today";

            //loop through games and create nice response for sms
            string gamesString = "";
            foreach (Game game in games.response)
            {
                gamesString += game.ToString();
            }

            return gamesString;
        }
        catch (NullReferenceException e)
        {
            return e.ToString();
        }
    }
}