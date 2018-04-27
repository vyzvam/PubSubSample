using PubSubSample.Publishers;
using PubSubSample.Services;
using PubSubSample.Subscribers;
using System.Collections.Generic;

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
            _publisher.AddSubscribers(_subscribers);
        }
    }

}
