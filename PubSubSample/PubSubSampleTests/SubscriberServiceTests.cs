
using NUnit.Framework;
using PubSubSample.Publishers;
using PubSubSample.Services;
using PubSubSample.Subscribers;
using System.Collections.Generic;
using System.Linq;

namespace PubSubSampleTests
{
    [TestFixture]
    public class SubscriberServiceTests
    {
        [Test]
        public void CanProduceEmailSubscriber()
        {
            var subscriberList = new ISubscriber[] { new EmailSubscriber() }.Select(s => s);

            var serviceMock = new Moq.Mock<IService<IEnumerable<ISubscriber>>>();
            serviceMock.Setup(s => s.Serve()).Returns(subscriberList);

            var service = serviceMock.Object;
            var subscribers = service.Serve();
            var subscriber = subscribers.FirstOrDefault();

            Assert.IsInstanceOf<EmailSubscriber>(subscriber);
        }

        [Test]
        public void CanProduceShellSubscriber()
        {
            var subscriberList = new ISubscriber[] { new ShellSubscriber() }
                .Select(s => s);

            var serviceMock = new Moq.Mock<IService<IEnumerable<ISubscriber>>>();
            serviceMock.Setup(s => s.Serve()).Returns(subscriberList);

            var service = serviceMock.Object;
            var subscribers = service.Serve();
            var subscriber = subscribers.FirstOrDefault();

            Assert.IsInstanceOf<ShellSubscriber>(subscriber);
        }

        [Test]
        public void CanProduceSmsSubscriber()
        {
            var subscriberList = new ISubscriber[] { new SmsSubscriber() }
                .Select(s => s);

            var serviceMock = new Moq.Mock<IService<IEnumerable<ISubscriber>>>();
            serviceMock.Setup(s => s.Serve()).Returns(subscriberList);

            var service = serviceMock.Object;
            var subscribers = service.Serve();
            var subscriber = subscribers.FirstOrDefault();

            Assert.IsInstanceOf<SmsSubscriber>(subscriber);
        }
        [Test]
        public void CanProduceRESTSubscriber()
        {
            var subscriberList = new ISubscriber[] { new RESTSubscriber() }
                .Select(s => s);

            var serviceMock = new Moq.Mock<IService<IEnumerable<ISubscriber>>>();
            serviceMock.Setup(s => s.Serve()).Returns(subscriberList);

            var service = serviceMock.Object;
            var subscribers = service.Serve();
            var subscriber = subscribers.FirstOrDefault();

            Assert.IsInstanceOf<RESTSubscriber>(subscriber);
        }
    }
}
