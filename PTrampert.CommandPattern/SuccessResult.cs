using System;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public class SuccessResult<TResultData> : IResult
    {
        public TResultData Data { get; set; }
        public T ExecuteOn<T>(IResultHandler<T> handler)
        {
            return handler.Success(this);
        }

        public async Task<T> ExecuteOnAsync<T>(IAsyncResultHandler<T> handler)
        {
            return await handler.SuccessAsync(this);
        }
    }
}