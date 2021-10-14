using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_KOPA.Application.Abstractions.Sms
{
    public interface ISmsProvider<T> where T : class
    {
        Task<T> SendSms(SmsMessage message);
    }
}
