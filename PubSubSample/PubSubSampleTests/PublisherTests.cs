
using NUnit.Framework;
using PubSubSample.Publishers;
using PubSubSample.Subscribers;

namespace PubSubSampleTests
{
    [TestFixture]
    public class PublisherTests
    {
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void PublishState(bool? state)
        {
            var subscriber = new EmailSubscriber();

            var publisherMock = new Moq.Mock<IPublisher>();
            publisherMock.Setup(s => s.Notify()).Returns(state);

            var publisher = publisherMock.Object;
            var status = publisher.Notify();

            Assert.That(status, Is.EqualTo(state));
        }

        [Test]
        public void DoesPublisherHaveNoSubscribers()
        {
            var publisher = new Message("Suba");
            var status = publisher.Notify();
            Assert.That(status, Is.Null);
        }

        [Test]
        public void DoesPublisherHaveSubscriber()
        {
            var publisher = new Message("Suba");

            var subscriber = new SmsSubscriber();
            publisher.AddSubscriber(subscriber);

            var status = publisher.Notify();
            Assert.That(status, Is.True);
        }

        [Test]
        public void IsSubscriberRemovedFromPublisher()
        {
            var publisher = new Message("Suba");
            var subscriber = new SmsSubscriber();
            publisher.AddSubscriber(subscriber);
            publisher.RemoveSubscriber(subscriber);
            var status = publisher.Notify();
            Assert.That(status, Is.Null);
        }

    }
}
