using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        IResult Handle(TCommand command);

        Task<IResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler
    {
        IResult Handle(object command);

        Task<IResult> HandleAsync(object command);
    }
}
