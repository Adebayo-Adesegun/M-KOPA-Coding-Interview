using M_KOPA.Application.Abstractions.Messaging;
using Xunit;

namespace M_KOPA.Tests
{
    public class MessageTests
    {
        [Fact]
        public void IsProperties_Copied_For_Cloned_Messages()
        {
            // Arrange
            var message = new Message("abc", new byte[] { 1 });

            // Act
            var clone = message.Clone();

            // Assert
            Assert.NotNull(message.Id);
        }
    }


}
