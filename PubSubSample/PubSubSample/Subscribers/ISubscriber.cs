using PubSubSample.Publishers;

namespace PubSubSample.Subscribers
{
    public interface ISubscriber
    {
        void Receive(IPublisher subject);
    }

}
