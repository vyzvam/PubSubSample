
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubSample
{
    public interface IPublisher
    {
        string Sender { get; set; }
        string Data { get; set; }
        void Notify();
        void AddObserver(ISubscriber subscriber);
        void RemoveObserver(ISubscriber subscriber);

        void AddObservers(IEnumerable<ISubscriber> subscriber);
        void RemoveObservers(IEnumerable<ISubscriber> subscriber);
    }

    public interface ISubscriber
    {
        void Receive(IPublisher subject);
    }

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

        public void AddObserver(ISubscriber subscriber)
        {
            OnStateChange += subscriber.Receive;
        }

        public void RemoveObserver(ISubscriber subscriber)
        {
            OnStateChange -= subscriber.Receive;
        }

        public void AddObservers(IEnumerable<ISubscriber> subscribers)
        {
            subscribers.AsParallel().ForAll(AddObserver);
        }

        public void RemoveObservers(IEnumerable<ISubscriber> subscribers)
        {
            subscribers.AsParallel().ForAll(RemoveObserver);
        }
    }

    public class Customer : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"{subject.Sender} said {subject.Data}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Message("Suba");

            var customers = new int[] { 1, 2 }
                                .Select(s => new Customer());

            publisher.AddObservers(customers);

            Console.WriteLine("What is your name?:");
            publisher.Sender = Console.ReadLine();

            Console.WriteLine("What is your message?:");
            publisher.Data = Console.ReadLine();

            Console.Read();

        }
    }
}
