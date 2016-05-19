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
    public class CommandRegistry : ICommandRegistry
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

        public object ExecuteCommand(object command)
        {
            var handler = GetCommandHandler(command.GetType());
            return handler.Handle(command);
        }

        public async Task<object> ExecuteCommandAsync(object command)
        {
            var handler = GetCommandHandler(command.GetType());
            return await handler.HandleAsync(command);
        }

        public TResult ExecuteCommand<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            var handler = GetCommandHandler<TCommand, TResult>();
            return handler.Handle(command);
        } 

        public async Task<TResult> ExecuteCommandAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            var handler = GetCommandHandler<TCommand, TResult>();
            return await handler.HandleAsync(command);
        }

        public ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>() 
            where TCommand : ICommand<TResult>
        {
            return (ICommandHandler<TCommand, TResult>) GetCommandHandler(typeof(TCommand));
        }

        public ICommandHandler GetCommandHandler(Type commandType)
        {
            return Registry[commandType]();
        }

        public Func<ICommandHandler> this[Type type] => Registry[type];
    }
}
