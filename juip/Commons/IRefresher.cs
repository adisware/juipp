namespace adisware.juipp.Commons
{
    public interface IRefresher<in TD>
    {
        void Refresh(TD item);
    }
}