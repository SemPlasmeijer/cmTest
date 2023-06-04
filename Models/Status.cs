namespace cmTest.Models;

public class Status
{
    public string get { get; set; } = "";
    public List<int> parameters { get; set; } = new List<int>();
    public List<int> errors { get; set; } = new List<int>();
}