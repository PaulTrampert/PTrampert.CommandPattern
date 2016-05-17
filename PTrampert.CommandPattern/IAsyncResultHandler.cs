using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IAsyncResultHandler<TResult, TReturn>
        where TResult : IResult
    {
    }
}