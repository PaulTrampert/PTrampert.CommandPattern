using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IResult
    {
        T ExecuteOn<T>(IResultHandler<T> handler);

        Task<T> ExecuteOnAsync<T>(IAsyncResultHandler<T> handler);
    }
}