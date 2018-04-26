
using System;

namespace PubSubSample
{
    public class SmsSubscriber : ISubscriber
    {
        public void Receive(IPublisher subject)
        {
            Console.WriteLine($"Sms from {subject.Sender} with message {subject.Data} sent");

        }
    }

}
