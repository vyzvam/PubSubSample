namespace PubSubSample.Services
{
    public interface IService<T>
    {
        T Serve();
    }

}
