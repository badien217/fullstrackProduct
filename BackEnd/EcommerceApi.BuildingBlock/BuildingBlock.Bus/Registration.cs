using BuildingBlock.Bus.Queue;
using EcommerceAPI.SharedLibrary.Interfaces.SendMessage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Bus
{
    public static class Registration
    {
        public static void AddBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISendMessageRabbitMQ, QueueRabbitMq>();
        }
    }
}
