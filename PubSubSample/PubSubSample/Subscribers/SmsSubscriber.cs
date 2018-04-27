
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    /// <summary>
    /// Sms messaging subscriber
    /// </summary>
    public class SmsSubscriber : ISubscriber
    {
        /// <summary>
        /// Receiving of sms message either by manual call or to be attached to a publisher
        /// </summary>
        /// <param name="subject"> the publisher object that this subscriber is attached to</param>
        /// <returns></returns>
        public bool Receive(IPublisher subject)
        {
            Console.WriteLine($"Sms from {subject.Sender} with message {subject.Data} sent");
            return true;

        }
    }

}
