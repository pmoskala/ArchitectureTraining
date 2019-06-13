namespace SFC.Infrastructure
{
  public interface IQueryHandler<out TQueryResponse, in TQueryRequest>
  {
    TQueryResponse Handle(TQueryRequest request);
  }
}