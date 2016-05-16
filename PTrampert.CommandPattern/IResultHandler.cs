using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IResultHandler<T>
    {
        T Success<TResultData>(SuccessResult<TResultData> successResult);

        T Failure<TResultData>(FailedResult<TResultData> failedResult);
    }
}