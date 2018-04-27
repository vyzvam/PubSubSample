
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    /// <summary>
    /// Email based subscribers
    /// </summary>
    public class EmailSubscriber : ISubscriber
    {
        /// <summary>
        /// Receiving of email either by manual call or to be attached to a publisher
        /// </summary>
        /// <param name="subject"> the publisher object that this subscriber is attached to</param>
        /// <returns></returns>
        public bool Receive(IPublisher subject)
        {
            Console.WriteLine($"Email from  {subject.Sender} with subject {subject.Data} sent!");
            return true;

        }
    }

}
