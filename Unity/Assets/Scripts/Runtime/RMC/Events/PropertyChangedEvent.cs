using UnityEngine.Events;

namespace RMC.Events
{
	/// <summary>
	/// Holds the before and after value during a property chagnge
	/// </summary>
	public abstract class PropertyChangedEvent<T> : UnityEvent<T,T>, IEvent
	{
	}
}