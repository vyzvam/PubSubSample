using PubSubSample.Publishers;

namespace PubSubSample.Services
{
    public class PublisherService : IService<IPublisher>
    {
        public IPublisher Serve()
        {
            return new Message("Suba");
        }
    }

}
