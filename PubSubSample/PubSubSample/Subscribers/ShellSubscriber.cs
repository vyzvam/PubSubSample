
using System;

namespace PubSubSample
{
    public class ShellSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"{subject.Sender} said {subject.Data}");

        }
    }

}
