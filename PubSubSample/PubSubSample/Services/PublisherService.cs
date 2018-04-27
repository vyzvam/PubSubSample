using PubSubSample.Publishers;

namespace PubSubSample.Services
{
    /// <summary>
    /// A Service that retrieves the required publisher
    /// </summary>
    public class PublisherService : IService<IPublisher>
    {
        public IPublisher Serve()
        {
            return new Message("Suba");
        }
    }

}
