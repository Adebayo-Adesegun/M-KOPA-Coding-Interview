using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M_KOPA.Application.Abstractions.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"> T represents the type for the dependecy injection system </typeparam>
    public interface IMessagePublisher<T> : IMessagePublisher { }

    /// <summary>
    /// Publishes messages to a message queue or event bus
    /// </summary>
    public interface IMessagePublisher : IDisposable
    {
        /// <summary>
        /// Sends a batch of messages to the queue or event bus
        /// </summary>
        Task PublishAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);

        Task PublishAsync(Message message, CancellationToken cancellationToken = default);
    }
}
