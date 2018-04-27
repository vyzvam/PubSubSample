
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    public class EmailSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"Email from  {subject.Sender} with subject {subject.Data} sent!");

        }
    }

}
