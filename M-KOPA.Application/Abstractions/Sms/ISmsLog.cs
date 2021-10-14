using System.Threading.Tasks;

namespace M_KOPA.Application.Abstractions.Sms
{
    public interface ISmsLog<T> where T : class
    {
        Task RecordSendSms(T smsProviderResponse);
    }
}
