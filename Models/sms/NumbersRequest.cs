namespace cmTest.Models.sms;

public class NumbersRequest
{
    public List<ToNumber> numbers { get; set; } = new List<ToNumber>();
}