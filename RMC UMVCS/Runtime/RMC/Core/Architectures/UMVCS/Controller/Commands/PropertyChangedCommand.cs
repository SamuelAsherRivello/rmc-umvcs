
namespace RMC.Core.Architectures.Umvcs.Controller.Commands
{
	/// <summary>
	/// Holds the before and after value during a property chagnge
	/// </summary>
	public abstract class PropertyChangedCommand<T> : Command
	{
		public T PreviousValue { get { return _previousValue; } }
		public T CurrentValue { get { return _currentValue; } }

		private T _previousValue;
		private T _currentValue;

		public PropertyChangedCommand(T previousValue, T currentValue)
		{
			_previousValue = previousValue;
			_currentValue = currentValue;
		}
	}
}