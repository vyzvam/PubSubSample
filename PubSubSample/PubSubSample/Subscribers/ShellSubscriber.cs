
using PubSubSample.Publishers;
using System;

namespace PubSubSample.Subscribers
{
    /// <summary>
    /// Internal subscribers used for console logging
    /// </summary>
    public class ShellSubscriber : ISubscriber
    {
        /// <summary>
        /// Receiving of console message either by manual call or to be attached to a publisher
        /// </summary>
        /// <param name="subject"> the publisher object that this subscriber is attached to</param>
        /// <returns></returns>
        public bool Receive(IPublisher subject)
        {
            Console.WriteLine($"{subject.Sender} said {subject.Data}");
            return true;

        }
    }

}
