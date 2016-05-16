using System;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern.Test
{
    public class FakeCommandHandler : CommandHandlerBase<FakeCommand>
    {
        public override IResult Handle(FakeCommand command)
        {
            return new SuccessResult<bool>();
        }

        public override async Task<IResult> HandleAsync(FakeCommand command)
        {
            return await Task.FromResult(new SuccessResult<bool>());
        }
    }
}