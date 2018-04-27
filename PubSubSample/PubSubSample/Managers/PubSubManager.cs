using PubSubSample.Publishers;
using PubSubSample.Services;
using PubSubSample.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PubSubSample.Managers
{
    /// <summary>
    /// A manager that handles the workflow of the pubsub procedures
    /// </summary>
    public class PubSubManager : IManager
    {
        private readonly IPublisher _publisher;
        private IEnumerable<ISubscriber> _subscribers;
        private readonly IService<IPublisher> _pubService;
        private readonly IService<IEnumerable<ISubscriber>> _subService;

        public PubSubManager()
        {
            _pubService = new PublisherService();
            _publisher = _pubService.Serve();
            _subService = new ListAllSubscriberService();
            _subscribers = _subService.Serve();
        }

        public PubSubManager(IPublisher publisher)
        {
            _publisher = publisher;
            _subService = new ListAllSubscriberService();
            _subscribers = _subService.Serve();
        }

        public PubSubManager(IPublisher publisher, IList<ISubscriber> subscribers)
        {
            _publisher = publisher;
            _subscribers = subscribers;
        }

        public void Start()
        {
            if (_publisher == null)
                throw new NullReferenceException("Publisher is not available!");

            if (_subscribers == null || !_subscribers.Any())
                throw new NullReferenceException("Subscriber(s)  not available!");

            _publisher.AddSubscribers(_subscribers);
        }
    }

}
