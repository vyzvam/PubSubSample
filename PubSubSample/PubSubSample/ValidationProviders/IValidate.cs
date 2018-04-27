namespace PubSubSample.Publishers
{
    public interface IValidator<TReturn>
    {
        TReturn Validate();
    }

}
