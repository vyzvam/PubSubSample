
using System;

namespace PubSubSample
{
    public class EmailSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"Email from  {subject.Sender} with subject {subject.Data} sent!");

        }
    }

}
