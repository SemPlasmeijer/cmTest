namespace cmTest.Models.sms;

public class MessageRequest
{
    public Messages messages { get; set; }

    public MessageRequest(Messages messages)
    {
        this.messages = messages;
    }
}