namespace cmTest.Models.basketball;

public class GamesList
{
    public string get { get; set; } = "";
    //public List<int> parameters { get; set; } = new List<int>();
    //public List<int> errors { get; set; } = new List<int>();
    public int results { get; set; } = 0;
    public List<Game> response { get; set; } = new List<Game>();
}