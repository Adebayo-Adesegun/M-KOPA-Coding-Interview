using System;
using System.Collections.Generic;

namespace M_KOPA.Application.Abstractions.Messaging
{

    /// <summary>
    /// A generic message with deserialized content to be used in all queue implementations.
    /// </summary>
    public class Message<T> : Message, IEquatable<Message<T>>
    {
        /// <summary>
        /// Creates an instance of class/>.
        /// </summary>
        /// <param name="id">The message ID.</param>
        /// <param name="content">The message content.</param>
        /// <param name="deserializedObject">The deserialized object.</param>
        /// <param name="properties">The message user properties.</param>
        /// <param name="partitionId">The partition ID.</param>
        /// <param name="enqueueTime">The enqueue time to delay the message delivery.</param>
        public Message(
            string id = null,
            byte[] content = null,
            T deserializedObject = default,
            IReadOnlyDictionary<string, object> properties = null,
            string partitionId = null,
            DateTimeOffset? enqueueTime = null)
            : base(id, content, properties, partitionId, enqueueTime)
        {
            Object = deserializedObject;
        }

        /// <summary>
        /// Gets the JSON deserialzed content.
        /// </summary>
        public T Object { get; }

        public bool Equals(Message<T> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Message<T>);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public class Message : IEquatable<Message>
    {

        /// <summary>
        /// Creates an instance of Message/>.
        /// </summary>
        /// <param name="content">The message content.</param>
        public Message(byte[] content)
            : this(null, content: content)
        {
        }

        public Message(
            string id = null,
            byte[] content = null,
            IReadOnlyDictionary<string, object> properties = null,
            string partitionId = null, 
            DateTimeOffset? enqueueTime = null)
        {
            Id = id;
            Content = content ?? new byte[0];
            Properties = properties ?? new Dictionary<string, object>();
            PartitionId = partitionId;
            EnqueueTime = enqueueTime;
        }

        /// <summary>
        /// Gets the message ID.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the message content as byte array.
        /// </summary>
        public byte[] Content { get; }

        /// <summary>
        /// Gets the partition key.
        /// </summary>
        public string PartitionId { get; }

        /// <summary>
        /// Gets the properties for this message.
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }


        /// <summary>
        /// Gets the enqueue time to delay the message delivery.
        /// </summary>
        public DateTimeOffset? EnqueueTime { get; }

        /// <summary>
        /// Clones the message.
        /// </summary>
        /// <returns>The cloned message.</returns>
        public Message Clone()
        {
            return new Message(Id, Content, Properties, PartitionId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Message);
        }

        public bool Equals(Message other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
