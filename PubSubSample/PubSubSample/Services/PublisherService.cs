namespace PubSubSample
{
    public class PublisherService : IService<IPublisher>
    {
        public IPublisher Serve()
        {
            return new Message("Suba");
        }
    }

}
