namespace cmTest.Models.sms;

public class Messages
{
    public Authentication authentication { get; set; }

    public List<Msg> msg { get; set; }

    public Messages(Authentication authentication, List<Msg> msg)
    {
        this.authentication = authentication;
        this.msg = msg;
    }
}