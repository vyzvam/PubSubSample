
using NUnit.Framework;
using PubSubSample.Publishers;
using PubSubSample.Subscribers;

namespace PubSubSampleTests
{
    [TestFixture]
    public class SubscriberTests
    {
        [Test]
        public void IsSuccessSentToSubscriber()
        {
            var message = new Message("Emailer");

            var subscriberMock = new Moq.Mock<ISubscriber>();
            subscriberMock.Setup(s => s.Receive(message)).Returns(true);

            var subscriber = subscriberMock.Object;
            var status = subscriber.Receive(message);

            Assert.That(status, Is.True);
        }

        [Test]
        public void IsFailedSentToSubscriber()
        {
            var message = new Message("Emailer");

            var subscriberMock = new Moq.Mock<ISubscriber>();
            subscriberMock.Setup(s => s.Receive(message)).Returns(false);

            var subscriber = subscriberMock.Object;
            var status = subscriber.Receive(message);

            Assert.That(status, Is.False);
        }

    }
}
