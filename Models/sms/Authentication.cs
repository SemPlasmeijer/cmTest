namespace cmTest.Models.sms;

public class Authentication
{
    public string productToken { get; set; }

    public Authentication(string productToken) {
        this.productToken = productToken;
    }
}