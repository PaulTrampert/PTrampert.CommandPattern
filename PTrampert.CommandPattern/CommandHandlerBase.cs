using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
    {
        public IResult Handle(object command)
        {
            return Handle((TCommand) command);
        }

        public Task<IResult> HandleAsync(object command)
        {
            return HandleAsync((TCommand) command);
        }

        public abstract IResult Handle(TCommand command);
        public abstract Task<IResult> HandleAsync(TCommand command);
    }
}
