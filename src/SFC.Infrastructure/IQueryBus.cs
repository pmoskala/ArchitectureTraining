namespace SFC.Infrastructure
{
    public interface IQueryBus
    {
        TQueryResponse Query<TQueryResponse, TQueryRequest>(TQueryRequest request);
    }
}