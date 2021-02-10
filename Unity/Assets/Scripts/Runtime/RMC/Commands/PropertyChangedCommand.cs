
namespace RMC.Commands
{
	/// <summary>
	/// Holds the before and after value during a property chagnge
	/// </summary>
	public abstract class PropertyChangedCommand<T> : RMC.Commands.Command
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