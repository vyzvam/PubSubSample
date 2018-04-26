using System.Collections.Generic;

namespace PubSubSample
{
    public interface IPublisher
    {
        string Sender { get; set; }
        string Data { get; set; }
        void Notify();
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);

        void AddSubscribers(IEnumerable<ISubscriber> subscribers);
        void RemoveSubscribers(IEnumerable<ISubscriber> subscribers);
    }

}
