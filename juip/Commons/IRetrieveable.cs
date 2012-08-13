namespace juipp.Commons
{
    public interface IRetrieveable<in TD>
    {
        void Update(TD item);
    }
}