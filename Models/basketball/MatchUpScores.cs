namespace cmTest.Models.basketball;

public class MatchUpScores
{
    public BasketballScores home { get; set; } = new BasketballScores();
    public BasketballScores away { get; set; } = new BasketballScores();
}