using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IResultHandler<TResult, TReturn>
        where TResult : IResult
    {
    }
}