namespace sp.jui.Commons
{
    public interface IBindable<in T> 
    {
        void Bind(T item);
    }
}