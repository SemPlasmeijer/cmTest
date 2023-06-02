namespace cmTest.Models;

public class Status
{
    public string get { get; set; } = "";
public List<int> parameters { get; set; } = new List<int>();
    public List<int> errors { get; set; } = new List<int>();
    
    //{"get":"status","parameters":[],"errors":[],"results":1,"paging":{"current":1,"total":1},"response":{"account":{"firstname":"Sem","lastname":null,"email":"plasmeijer.sem@gmail.com"},"subscription":{"plan":"Free","end":"2024-06-01T00:00:00+00:00","active":true},"requests":{"current":0,"limit_day":100}}}
}