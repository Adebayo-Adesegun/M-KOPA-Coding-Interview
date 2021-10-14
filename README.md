# M-KOPA-Coding-Interview

Contains the messaging abstractions for the Queue and Event Bus:

- **IMessagePublisher\<T>**
- **IMessagePublisher**
    - `PublishAsync(messages, cancellationToken)`: Sends a batch of messages to the queue/event bus.
- **IMessageReceiver\<T>**
- **IMessageReceiver**
    - `GetMessageCountAsync(cancellationToken)`: Gets the count of messages waiting to be processed.
    - `ListenAsync(handleMessages, cancellationToken)`: (Fails when connection cannot be established)
    - `ListenWithRetryAsync(handleMessages, cancellationToken)`: Starts listening and processing messages with the `handleMessages` function until the `cancellationToken` signals a cancellation.
    - `KeepAliveAsync(messages, timeToLive, cancellationToken)`: Extends the message lock timeout on the given messages.
    - `ConfirmAsync(messages, cancellationToken)`: Confirms the processing of messages and removes them from the queue.
    - `RejectAsync(messages, cancellationToken)`: Rejects messages and requeues them for later reprocessing.
    - `DeadLetterAsync(messages, reason, errorDescription, cancellationToken)`: Removes the messages and moves them to the dead letter queue.
- **Message\<T>:**
- **Message:** A generic message implementation.
