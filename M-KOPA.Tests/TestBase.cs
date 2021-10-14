using M_KOPA.Application.Abstractions.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace M_KOPA.Tests
{
    public abstract class TestBase
    {

        [Fact]
        public virtual async Task WhenRetrievingMessageCount_ThenCountIsGreaterOrEqualZero()
        {
            // Arrange
            var config = GetConfiguration();
            var receiver = CreateMessageReceiver(config);

            // Act
            var count = await receiver.GetMessageCountAsync();

            // Assert
            Assert.True(count >= 0);
        }

        protected virtual int GetMessageCount()
        {
            return 5;
        }

        protected virtual Message CreateMessage(byte[] content)
        {
            // Arrange
            return new Message(
                content: content,
                properties: new Dictionary<string, object>
                {
                    { "PhoneNumber", "+2347066576295" },
                    { "Message", "Welcome to M-KOPA" }
                });
        }

        protected abstract IMessageReceiver<MyMessage> CreateMessageReceiver(IConfiguration configuration);

        protected abstract IMessagePublisher<MyMessage> CreateMessagePublisher(IConfiguration configuration);

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }
    }

    public class MyMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
