using NUnit.Framework;
namespace RMC.Managers
{
	public class TestCommand : Commands.Command { }
	public class OtherTestCommand : Commands.Command { }

	public class CommandManagerTest
	{
		[Test]
		public void InvokeCommand_ListenerCalled_WhenListened()
		{
			// Arrange
			CommandManager commandManager = new CommandManager();
			TestCommand testCommand = new TestCommand();
			bool wasListenerCalled = false;

			// Act
			commandManager.AddCommandListener<TestCommand>( command =>
			{
				wasListenerCalled = true;
			});
			commandManager.InvokeCommand(testCommand);

			// Assert
			Assert.That(wasListenerCalled, Is.True);

		}

		[Test]
		public void InvokeCommand_ListenerNotCalled_WhenNotListened()
		{
			// Arrange
			CommandManager commandManager = new CommandManager();
			TestCommand testCommand = new TestCommand();
			bool wasListenerCalled = false;

			// Act
			commandManager.AddCommandListener<OtherTestCommand>(command =>
			{
				wasListenerCalled = true;
			});
			commandManager.InvokeCommand(testCommand);

			// Assert
			Assert.That(wasListenerCalled, Is.False);

		}

	}
}
