
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    /// <summary>
    /// REST based subscribers, used for API subscribers
    /// </summary>
    public class RESTSubscriber : ISubscriber
    {
        /// <summary>
        /// Receiving of REST Request via http call either by manual call or to be attached to a publisher
        /// </summary>
        /// <param name="subject"> the publisher object that this subscriber is attached to</param>
        /// <returns></returns>
        public bool Receive(IPublisher subject)
        {
            Console.WriteLine($"Message {subject.Data} sent to web api");
            return true;

        }
    }

}
