using cmTest.Models.sms;
using cmTest.Models.sms.response;
using RestSharp;

namespace cmTest.Services.interfaces;

public interface ISmsService
{
    public Task<ResponseSms> sendMessage(List<ToNumber> numbers, SmsBody smsBody);
    public MessageRequest createMessage(List<ToNumber> numbers, SmsBody smsBody);
}
