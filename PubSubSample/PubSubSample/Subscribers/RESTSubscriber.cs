
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    public class RESTSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"Message {subject.Data} sent to web api");

        }
    }

}
