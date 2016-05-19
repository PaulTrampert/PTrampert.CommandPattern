using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PTrampert.CommandPattern.Test
{
    [TestFixture]
    public class CommandRegistryTests
    {
        private CommandRegistry Registry { get; set; }
        [SetUp]
        public void Setup()
        {
            Registry = new CommandRegistry();
        }

        [Test]
        public void CanRegisterCommandHandlers()
        {
            Registry.Register(() => new FakeCommandHandler());
            Assert.That(Registry.GetCommandHandler(typeof(FakeCommand)), Is.AssignableTo<FakeCommandHandler>());
        }

        [Test]
        public void CanRetrieveStronglyTypedCommandHandlers()
        {
            Registry.Register(() => new FakeCommandHandler());
            Assert.That(Registry.GetCommandHandler<FakeCommand, int>(), Is.AssignableTo<FakeCommandHandler>());
        }

        [Test]
        public void RegistryBuiltHandlersCanHandleCommands()
        {
            Registry.Register(() => new FakeCommandHandler());
            var command = new FakeCommand();
            var result = Registry.ExecuteCommand<FakeCommand, int>(command);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task RegistryBuiltHandlersCanHandleCommandsAsync()
        {
            Registry.Register(() => new FakeCommandHandler());
            var command = new FakeCommand();
            var result = await Registry.ExecuteCommandAsync<FakeCommand, int>(command);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
