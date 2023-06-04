namespace cmTest.Models.sms;

public class SmsBody
{
    public string type { get; set; } = "auto";

    public string content { get; set; }

    public SmsBody(string content)
    {
        this.content = content;
    }
}