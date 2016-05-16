using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PTrampert.CommandPattern.Test
{
    [TestFixture]
    public class ResultTests : IResultHandler<int>, IAsyncResultHandler<int>
    {
        [Test]
        public void SuccessResultCallsSuccessOnItsHandler()
        {
            var result = new SuccessResult<int>();
            Assert.That(result.ExecuteOn(this), Is.EqualTo(1));
        }

        [Test]
        public void FailureCallsFailure()
        {
            var result = new FailedResult<int>();
            Assert.That(result.ExecuteOn(this), Is.EqualTo(0));
        }

        [Test]
        public async Task SuccessAsyncCallsSuccessAsync()
        {
            var result = new SuccessResult<int>();
            Assert.That(await result.ExecuteOnAsync(this), Is.EqualTo(2));
        }

        [Test]
        public async Task FailureAsyncCallsFailureAsync()
        {
            var result = new FailedResult<int>();
            Assert.That(await result.ExecuteOnAsync(this), Is.EqualTo(3));
        }

        public int Success<TResultData>(SuccessResult<TResultData> successResult)
        {
            return 1;
        }

        public int Failure<TResultData>(FailedResult<TResultData> failedResult)
        {
            return 0;
        }

        public Task<int> SuccessAsync<TResultData>(SuccessResult<TResultData> successResult)
        {
            return Task.FromResult(2);
        }

        public Task<int> FailureAsync<TResultData>(FailedResult<TResultData> failedResult)
        {
            return Task.FromResult(3);
        }
    }
}
