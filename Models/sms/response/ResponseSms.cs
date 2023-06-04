namespace cmTest.Models.sms.response;

public class ResponseSms
{
    public string details { get; set; } = "";
    public int errorCode { get; set; } = 0;
    //public ResponseMsg messages { get; set; } = new ResponseMsg();

    public ResponseSms(string details, int errorCode)
    {
        this.details = details;
        this.errorCode = errorCode;
    }
}