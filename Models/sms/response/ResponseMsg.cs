namespace cmTest.Models.sms.response;

public class ResponseMsg
{
    public string to { get; set; } = "";
    public string status { get; set; } = "Not Received";
    public string? reference { get; set; }
    public int parts { get; set; } = 0;
    public string? messageDetails { get; set; }
    public int messageErrorCode { get; set; } = 0;
}