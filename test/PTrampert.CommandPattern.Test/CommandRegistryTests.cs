using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PTrampert.CommandPattern.Test
{
    public class CommandRegistryTests
    {
        private CommandRegistry Registry { get; set; }
        public CommandRegistryTests()
        {
            Registry = new CommandRegistry();
        }

        [Fact]
        public void CanRegisterCommandHandlers()
        {
            Registry.Register(() => new FakeCommandHandler());
            Assert.IsAssignableFrom<FakeCommandHandler>(Registry.GetCommandHandler(typeof(FakeCommand)));
        }

        [Fact]
        public void CanRetrieveStronglyTypedCommandHandlers()
        {
            Registry.Register(() => new FakeCommandHandler());
            Assert.IsAssignableFrom<FakeCommandHandler>(Registry.GetCommandHandler<FakeCommand, int>());
        }

        [Fact]
        public void RegistryBuiltHandlersCanHandleCommands()
        {
            Registry.Register(() => new FakeCommandHandler());
            var command = new FakeCommand();
            var result = Registry.ExecuteCommand<FakeCommand, int>(command);
            Assert.Equal(result, 1);
        }

        [Fact]
        public async Task RegistryBuiltHandlersCanHandleCommandsAsync()
        {
            Registry.Register(() => new FakeCommandHandler());
            var command = new FakeCommand();
            var result = await Registry.ExecuteCommandAsync<FakeCommand, int>(command);
            Assert.Equal(result, 2);
        }
    }
}
