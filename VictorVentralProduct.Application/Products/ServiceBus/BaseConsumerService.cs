using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text;

namespace VictorVentralProduct.Application.Products.ServiceBus
{
    public abstract class BaseConsumerService<T> : BackgroundService
    {
        private readonly ISubscriptionClient _subscriptionClient;

        protected BaseConsumerService(ISubscriptionClient subscriptionClient)
        {
            _subscriptionClient = subscriptionClient ?? throw new ArgumentNullException(nameof(subscriptionClient));
        }

        protected abstract Task HandleMessageAsync(T message);

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _subscriptionClient.RegisterMessageHandler(async (message, token) =>
            {
                try
                {
                    var deserializedObject = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));

                    await HandleMessageAsync(deserializedObject);

                    await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                    await _subscriptionClient.AbandonAsync(message.SystemProperties.LockToken);
                }
            },
            new MessageHandlerOptions(args => Task.CompletedTask)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1,
            });

            return Task.CompletedTask;
        }
    }
}
