using cmTest.Models;
using cmTest.Models.enums;
using cmTest.Models.basketball;

namespace cmTest.Services.interfaces;

public interface IBasketballRetrievalService
{
    public Task<Status> getApiStatus();
    public Task<string> getGamesList(DateTime? date, leagues league = leagues.NBA);
    public string transformGamesListToString(GamesList games);
}