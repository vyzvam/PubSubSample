using System.Collections.Generic;
using System.Linq;

namespace PubSubSample
{
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
                Notify();
            }
        }

        private delegate void UpdateObserver(IPublisher subject);
        private event UpdateObserver OnStateChange;

        public Message(string name)
        {
            Sender = name;
        }

        public void Notify()
        {
            OnStateChange?.Invoke(this);
        }

        public void AddSubscriber(ISubscriber observer)
        {
            OnStateChange += observer.Receive;
        }

        public void RemoveSubscriber(ISubscriber observer)
        {
            OnStateChange -= observer.Receive;
        }

        public void AddSubscribers(IEnumerable<ISubscriber> observers)
        {
            observers.AsParallel().ForAll(AddSubscriber);
        }

        public void RemoveSubscribers(IEnumerable<ISubscriber> observers)
        {
            observers.AsParallel().ForAll(RemoveSubscriber);
        }
    }

}
