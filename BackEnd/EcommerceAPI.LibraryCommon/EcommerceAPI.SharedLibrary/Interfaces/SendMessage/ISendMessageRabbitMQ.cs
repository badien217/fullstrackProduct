using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.SharedLibrary.Interfaces.SendMessage
{
    public interface ISendMessageRabbitMQ
    {
        void SendMessage<T>(T message);
    }
}
