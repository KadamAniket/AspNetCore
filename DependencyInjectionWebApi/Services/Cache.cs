namespace DependencyInjectionWebApi.Services
{
    public interface ICache<T>
    {
        void save(T obj);
        T get();
    }
    public class Cache<T> : ICache<T>
    {
        private T data;
        public T get()
        {
            return data;
        }

        public void save(T obj)
        {
            data = obj;
        }
    }


}

