namespace PubSubSample
{
    public interface ISubscriber
    {
        void Receive(IPublisher subject);
    }

}
