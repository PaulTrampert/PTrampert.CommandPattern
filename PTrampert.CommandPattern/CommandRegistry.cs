using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void Register<TCommand, TResult>(Func<ICommandHandler<TCommand, TResult>> builderFunc) 
            where TCommand : ICommand<TResult>
        {
            Registry.Add(typeof(TCommand), builderFunc);
        }

        public ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>(Type commandType) 
            where TCommand : ICommand<TResult>
        {
            return (ICommandHandler<TCommand, TResult>) GetCommandHandler(commandType);
        }

        public ICommandHandler GetCommandHandler(Type commandType)
        {
            return Registry[commandType]();
        }

        public Func<ICommandHandler> this[Type type] => Registry[type];
    }
}
