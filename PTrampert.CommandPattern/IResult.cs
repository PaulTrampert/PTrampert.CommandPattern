using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IResult
    {
        TReturn ExecuteOn<TResult, TReturn>(IResultHandler<TResult, TReturn> handler)
            where TResult : IResult;

        Task<TReturn> ExecuteOnAsync<TResult, TReturn>(IAsyncResultHandler<TResult, TReturn> handler) 
            where TResult : IResult;
    }
}