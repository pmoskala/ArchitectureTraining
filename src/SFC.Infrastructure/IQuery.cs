namespace SFC.Infrastructure
{
  public interface IQuery
  {
    TQueryResponse Query<TQueryResponse, TQueryRequest>(TQueryRequest request);
  }
}