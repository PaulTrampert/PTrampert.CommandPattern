using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IAsyncResultHandler<T>
    {
        Task<T> SuccessAsync<TResultData>(SuccessResult<TResultData> successResult);

        Task<T> FailureAsync<TResultData>(FailedResult<TResultData> failedResult);
    }
}