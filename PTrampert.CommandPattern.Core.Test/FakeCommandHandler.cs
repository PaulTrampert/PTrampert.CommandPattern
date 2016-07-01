using System;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern.Test
{
    public class FakeCommandHandler : CommandHandlerBase<FakeCommand, int>
    {
        public override int Handle(FakeCommand command)
        {
            return 1;
        }

        public override async Task<int> HandleAsync(FakeCommand command)
        {
            return await Task.FromResult(2);
        }
    }
}