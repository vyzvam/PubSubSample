
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    public class ShellSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"{subject.Sender} said {subject.Data}");

        }
    }

}
