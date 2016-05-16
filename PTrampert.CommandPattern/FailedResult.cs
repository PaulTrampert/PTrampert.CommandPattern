using System;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public class FailedResult<TResultData> : IResult
    {
        public TResultData Data { get; set; }

        public Exception Exception { get; set; }

        public FailedResult(TResultData data = default(TResultData), Exception exception = null)
        {
            Data = data;
            Exception = exception;
        }

        public T ExecuteOn<T>(IResultHandler<T> handler)
        {
            return handler.Failure(this);
        }

        public async Task<T> ExecuteOnAsync<T>(IAsyncResultHandler<T> handler)
        {
            return await handler.FailureAsync(this);
        }
    }
}