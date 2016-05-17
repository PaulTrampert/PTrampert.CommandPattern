using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface ICommandHandler<in TCommand, TResult> : ICommandHandler
    {
        TResult Handle(TCommand command);

        Task<TResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler
    {
        object Handle(object command);

        Task<object> HandleAsync(object command);
    }
}
