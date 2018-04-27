using PubSubSample.Publishers;

namespace PubSubSample.Subscribers
{
    public interface ISubscriber
    {
        bool Receive(IPublisher subject);
    }

}
