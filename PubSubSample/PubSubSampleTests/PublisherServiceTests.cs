
using NUnit.Framework;
using PubSubSample.Publishers;
using PubSubSample.Services;
using PubSubSample.Subscribers;
using System.Collections.Generic;
using System.Linq;

namespace PubSubSampleTests
{
    [TestFixture]
    public class PublisherServiceTests
    {
        [Test]
        public void CanProduceMessagePublisher()
        {
            var message = new Message("Test");
            var serviceMock = new Moq.Mock<IService<IPublisher>>();
            serviceMock.Setup(s => s.Serve()).Returns(message);

            var service = serviceMock.Object;
            var result = service.Serve();

            Assert.IsInstanceOf<Message>(result);
        }
    }
}
