namespace cmTest.Models.basketball;

public class Game
{
    public int id { get; set; } = 0;
    public DateTime date { get; set; } = new DateTime();
    public string time { get; set; } = "";
    public int timestamp { get; set; } = 0;
    public string timezone { get; set; } = "";
    public string? stage { get; set; }
    public int? week { get; set; }
    public string get { get; set; } = "";
    public GameStatus status { get; set; } = new GameStatus();
    public MatchUp teams { get; set; } = new MatchUp();
    public MatchUpScores scores { get; set; } = new MatchUpScores();

    public override string ToString()
    {
        if (status.@short == "FT")
        {
            return $"{teams.home.name} @Home vs {teams.away.name} at {time}: {scores.home.total} - {scores.away.total} \r\n";
        }
        return $"{teams.home.name} @Home vs {teams.away.name} at {time}: {status.@long} \r\n";
    }
}