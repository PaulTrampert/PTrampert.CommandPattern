using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public class CommandRegistry
    {
        private IDictionary<Type, Func<ICommandHandler>> Registry { get; }

        public CommandRegistry()
        {
            Registry = new ConcurrentDictionary<Type, Func<ICommandHandler>>();
        }

        public void Register<TCommand>(Func<ICommandHandler<TCommand>> builderFunc)
        {
            Registry.Add(typeof(TCommand), builderFunc);
        }

        public ICommandHandler GetCommandHandler(Type commandType)
        {
            return Registry[commandType]();
        }

        public Func<ICommandHandler> this[Type type] => Registry[type];
    }
}
