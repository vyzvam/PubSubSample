namespace PubSubSample.Publishers
{

    public class PublisherValidator : IValidator<string>
    {
        private readonly IPublisher _publisher;
        public PublisherValidator(IPublisher publisher)
        {
            _publisher = publisher;
        }
        public string Validate()
        {
            if (string.IsNullOrWhiteSpace(_publisher.Sender))
                return "Must provide a Sender!";

            if (string.IsNullOrWhiteSpace(_publisher.Data))
                return "Must provide data!";

            return string.Empty;

        }
    }

}
