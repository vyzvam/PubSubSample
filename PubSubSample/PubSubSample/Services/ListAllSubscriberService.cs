using PubSubSample.Subscribers;
using System.Collections.Generic;
using System.Linq;

namespace PubSubSample.Services
{
    /// <summary>
    /// Service that retrieves list of all available subscribers
    /// </summary>
    public class ListAllSubscriberService : IService<IEnumerable<ISubscriber>>
    {
        public IEnumerable<ISubscriber> Serve()
        {
            return new ISubscriber[] { new ShellSubscriber(), new SmsSubscriber(), new RESTSubscriber(), new EmailSubscriber() }
                .Select(s => s);
        }
    }

}
