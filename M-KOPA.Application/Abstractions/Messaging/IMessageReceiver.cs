using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M_KOPA.Application.Abstractions.Messaging
{


    /// <summary>
    /// Receives messages from a message queue, or event bus.
    /// </summary>
    /// <typeparam name="T">The marker type for the dependency injection system.</typeparam>
    public interface IMessageReceiver<T> : IMessageReceiver { }

    /// <summary>
    /// Receives messages from a message queue or event bus
    /// </summary>
    public interface IMessageReceiver
    {

        /// <summary>
        /// Gets the count of messages waiting to be processed.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The message count.</returns>
        Task<long> GetMessageCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///  Receives messages and passes them to the handle messages callback
        ///  The task completes when the listener throws an exception or the cancellationTone is cancelled
        /// </summary>
        /// <param name="handleMessages">Message handler callback</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task ListenAsync(Func<IReadOnlyCollection<Message>, CancellationToken, Task> handleMessages, CancellationToken cancellationToken = default);



        /// <summary>
        ///  Receives messages and passes them to the handle messages callback
        ///  The task completes when the listener throws an exception or the cancellationTone is cancelled
        /// </summary>
        /// <param name="handleMessages">Message handler callback</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task ListenWithRetryAsync(Func<IReadOnlyCollection<Message>, CancellationToken, Task> handleMessages, CancellationToken cancellationToken = default);


        /// <summary>
        /// Extends the message lock timeout on the given messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="timeToLive">The desired time to live.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task KeepAliveAsync(IEnumerable<Message> messages, TimeSpan? timeToLive = null, CancellationToken cancellationToken = default);


        /// <summary>
        /// Confirms the processing of messages and removes them from the queue.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task ConfirmAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);


        /// <summary>
        /// Confirms the processing of message and removes from the queue.
        /// </summary>
        /// <param name="message">The messages.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task ConfirmAsync(Message message, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rejects message and requeues for later reprocessing.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task RejectAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);


        /// <summary>
        /// Rejects messages and requeues them for later reprocessing.
        /// </summary>
        /// <param name="message">The messages.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task RejectAsync(Message message, CancellationToken cancellationToken = default);



        /// <summary>
        /// Removes the messages and moves them to the dead letter queue.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="errorDescription">The error description.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task DeadLetterAsync(IEnumerable<Message> messages, string reason, string errorDescription, CancellationToken cancellationToken = default);


        /// <summary>
        /// Removes the messages and moves them to the dead letter queue.
        /// </summary>
        /// <param name="message">The messages.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="errorDescription">The error description.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task DeadLetterAsync(Message message, string reason, string errorDescription, CancellationToken cancellationToken = default);
    }
}
