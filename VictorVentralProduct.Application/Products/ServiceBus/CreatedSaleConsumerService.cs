using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentralProduct.Application.Products.ServiceBus.Contracts;

namespace VictorVentralProduct.Application.Products.ServiceBus
{
    public class CreatedSaleConsumerService(ISubscriptionClient subscriptionClient) : BaseConsumerService<CreatedSale>(subscriptionClient)
    {
        protected override async Task HandleMessageAsync(CreatedSale message)
        {
            Console.WriteLine($"New Sale created: {message.ProductId}, Price: {message.Quantity}");
            await Task.CompletedTask;
        }
    }
}
