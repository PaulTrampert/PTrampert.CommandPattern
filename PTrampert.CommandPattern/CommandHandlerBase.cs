using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public abstract class CommandHandlerBase<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    {
        public object Handle(object command)
        {
            return Handle((TCommand) command);
        }

        public async Task<object> HandleAsync(object command)
        {
            return await HandleAsync((TCommand) command);
        }

        public abstract TResult Handle(TCommand command);
        public abstract Task<TResult> HandleAsync(TCommand command);
    }
}
