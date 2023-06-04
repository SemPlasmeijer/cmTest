namespace cmTest.Models.sms;

public class Msg
{
    public string[] allowedChannels { get; set; } = { "SMS" };
    public string from { get; set; } = "Sem";
    public List<ToNumber> to { get; set; }
    public int minimumNumberOfMessageParts { get; set; } = 1;
    public int maximumNumberOfMessageParts { get; set; } = 8;
    public SmsBody body { get; set; }

    public Msg(List<ToNumber> numbers, SmsBody body)
    {
        this.to = numbers;
        this.body = body;
    }
}