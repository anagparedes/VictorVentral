using Microsoft.Azure.ServiceBus;
using VictorVentralProduct.Infraestructure.ServiceBus.Contracts;

namespace VictorVentralProduct.Infraestructure.ServiceBus
{
    public class CreatedSaleConsumerService(ISubscriptionClient subscriptionClient) : BaseConsumerService<CreatedSale>(subscriptionClient)
    {
        protected override async Task HandleMessageAsync(CreatedSale message)
        {
            Console.WriteLine($"New Sale created: {message.ProductId}, Price: {message.Quantity}, UnitPrice: {message.UnitPrice}, Total: {message.Total}");

            await Task.CompletedTask;
        }
    }
}
