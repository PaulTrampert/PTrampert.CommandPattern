using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IResultHandler<out TReturn>
    {
        TReturn Success<TResultData>(SuccessResult<TResultData> successResult);

        TReturn Failure<TResultData>(FailedResult<TResultData> failedResult);
    }
}