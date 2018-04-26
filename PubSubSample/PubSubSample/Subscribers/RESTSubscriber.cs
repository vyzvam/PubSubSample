
using System;

namespace PubSubSample
{
    public class RESTSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"Message {subject.Data} sent to web api");

        }
    }

}
