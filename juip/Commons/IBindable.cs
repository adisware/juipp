namespace juip.Commons
{
    public interface IBindable<in T> 
    {
        void Bind(T item);
    }
}