using System.Collections.Generic;

namespace PubSubSample
{
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

        public void Execute()
        {
            _publisher.AddSubscribers(_subscribers);
        }
    }

}
