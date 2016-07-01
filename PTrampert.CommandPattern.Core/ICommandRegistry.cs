using System;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface ICommandRegistry
    {
        /// <summary>
        /// Registers a command type to a builder function.
        /// </summary>
        /// <typeparam name="TCommand">The type of command.</typeparam>
        /// <typeparam name="TResult">The type the handler returns.</typeparam>
        /// <param name="builderFunc">Function that will return a command handler.</param>
        void Register<TCommand, TResult>(Func<ICommandHandler<TCommand, TResult>> builderFunc) 
            where TCommand : ICommand<TResult>;

        /// <summary>
        /// Executes a command. The command handler must have been previously registered.
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>The result of the command execution.</returns>
        object ExecuteCommand(object command);

        /// <summary>
        /// Executes a command asynchronously. The command handler must have been previously registered.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The result.</returns>
        Task<object> ExecuteCommandAsync(object command);

        /// <summary>
        /// Executes a command. The command handler must have been previously registered.
        /// </summary>
        /// <typeparam name="TCommand">The command type.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="command">The command to execute.</param>
        /// <returns>The result.</returns>
        TResult ExecuteCommand<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>;

        /// <summary>
        /// Executes a command asynchronously. The command handler must have been previously registered.
        /// </summary>
        /// <typeparam name="TCommand">The command type.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="command">The command to execute.</param>
        /// <returns>The result.</returns>
        Task<TResult> ExecuteCommandAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>;

        /// <summary>
        /// Returns a registered command handler for the given command type.
        /// </summary>
        /// <typeparam name="TCommand">The command type.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <returns>A command handler that can handle the command type and returns the result type.</returns>
        ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>() 
            where TCommand : ICommand<TResult>;

        /// <summary>
        /// Returns a registered command handler for the given command type.
        /// </summary>
        /// <param name="commandType">The command type.</param>
        /// <returns>The handler that handles the given command type.</returns>
        ICommandHandler GetCommandHandler(Type commandType);

    }
}