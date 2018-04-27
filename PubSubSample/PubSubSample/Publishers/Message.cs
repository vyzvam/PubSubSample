using PubSubSample.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PubSubSample.Publishers
{
    /// <summary>
    /// A text message implementation of publisher
    /// </summary>
    public class Message : IPublisher
    {
        private string _sender;
        public string Sender { get => _sender; set => _sender = value; }

        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;

                var validateResult = _validator.Validate();
                if (!string.IsNullOrEmpty(validateResult))
                    throw new Exception(validateResult);

                Notify();
            }
        }

        private readonly IValidator<string> _validator;

        private delegate bool UpdateSubscriber(IPublisher subject);
        private event UpdateSubscriber OnStateChange;

        public Message(string name)
        {
            Sender = name;
            _validator = new PublisherValidator(this);
        }

        /// <summary>
        /// Notifies the intended subscribers with the message
        /// </summary>
        /// <returns>Received Status</returns>
        public bool? Notify()
        {
            return OnStateChange?.Invoke(this);
        }

        /// <summary>
        /// Add a new subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        public void AddSubscriber(ISubscriber subscriber)
        {
            OnStateChange += subscriber.Receive;
        }

        /// <summary>
        /// Remove an existing subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        public void RemoveSubscriber(ISubscriber subscriber)
        {
            OnStateChange -= subscriber.Receive;
        }

        /// <summary>
        /// Add multiple subscribers
        /// </summary>
        /// <param name="subscribers"></param>
        public void AddSubscribers(IEnumerable<ISubscriber> subscribers)
        {
            subscribers.AsParallel().ForAll(AddSubscriber);
        }

        /// <summary>
        /// remove multiple existing subscribers
        /// </summary>
        /// <param name="subscribers"></param>
        public void RemoveSubscribers(IEnumerable<ISubscriber> subscribers)
        {
            subscribers.AsParallel().ForAll(RemoveSubscriber);
        }
    }

}
