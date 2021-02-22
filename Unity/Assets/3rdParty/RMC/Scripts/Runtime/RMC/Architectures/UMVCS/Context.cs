using RMC.Managers;

namespace RMC.Architectures.UMVCS
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class Context  
	{
		public ModelLocator ModelLocator { get { return _modelLocator; } }
		public CommandManager CommandManager { get { return _commandManager; } }

		private ModelLocator _modelLocator = null;
		private CommandManager _commandManager = null;

		public Context()
		{
			_modelLocator = new ModelLocator();
			_commandManager = new CommandManager();
		}
	}
}