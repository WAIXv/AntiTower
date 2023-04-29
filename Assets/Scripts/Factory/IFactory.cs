namespace Reality.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}