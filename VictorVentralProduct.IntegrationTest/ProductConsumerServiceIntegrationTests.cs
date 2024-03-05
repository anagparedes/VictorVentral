using Microsoft.Azure.ServiceBus;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VictorVentralProduct.Infraestructure;
using VictorVentralProduct.Infraestructure.ServiceBus.Contracts;

namespace VictorVentralProduct.IntegrationTest
{
    public class ProductConsumerServiceIntegrationTests
    {
        [Fact]
        public async Task SendMessageCreatedSale_ShouldReceivedMessage()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .AddRepositories()
                .AddServiceBus(configuration)
                .AddSingleton<ITopicClient>(x =>
                    new TopicClient(
                        configuration.GetValue<string>("ServiceBus:ConnectionString"),
                        configuration.GetValue<string>("ServiceBus:TopicName")
                    )
                )
                .BuildServiceProvider();

            var topicClient = serviceProvider.GetService<ITopicClient>();
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes("{\"ProductId\":1,\"Quantity\":50,\"UnitPrice\":2480,\"Total\":124000.00}"));
            serviceBusMessage.UserProperties["messageType"] = typeof(CreatedSale).Name;
            await topicClient.SendAsync(serviceBusMessage);
        }
    }
}