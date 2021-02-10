using System;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.Data.Types
{
	// Creating concrete subclass of generic is required for Serializing 
	// to Unity Inspector.
	// Add more subclasses as needed.
	[Serializable]
	public class ObservableInt : Observable<int>
	{
		public ObservableInt() { }
		public ObservableInt(int value) : base(value) { }
	}

	[Serializable]
	public class ObservableFloat : Observable<float>
	{
		public ObservableFloat() { }
		public ObservableFloat(float value) : base(value) { }
	}

	[Serializable]
	public class ObservableString : Observable<string>
	{
		public ObservableString() { }
		public ObservableString(string value) : base(value) { }
	}

	[Serializable]
	public class ObservableChangedEvent : UnityEvent<Observable> {}

	[Serializable]
	public class ObservableOnValidateEvent : UnityEvent<Observable> { }

	[Serializable]
	public abstract class Observable 
	{
		protected abstract void InvokeOnValidate();
		protected abstract void InvokeOnChanged();
	}

	/// <summary>
	/// Wraps a value in order to allow observing its value change
	/// </summary>
	/// <example>>
	///   var obs = new Observable<int>(123);
	///   obs.OnChanged += (o, oldVal, newVal) => Log("changed from " + oldVal + " to " + newVal);
	///   obs.Value = 456; // dispatches OnChanged
	/// </example>
	/// <author>Jackson Dunstan, http://JacksonDunstan.com/articles/3547</author>
	/// <license>MIT</license>
	[Serializable]
	public class Observable<T> : Observable, IEquatable<Observable<T>>
	{
		//Called by PropertyDrawer
		[SerializeField]
		private T _value;

		[HideInInspector]
		private T _previousValue;

		public Observable() {}

		public Observable(T value)
		{
			_value = value;
		}

		public ObservableChangedEvent OnChanged = new ObservableChangedEvent();
		public ObservableOnValidateEvent OnValidate = new ObservableOnValidateEvent();

		public T Value
		{
			get { return _value; }
			set
			{
				var oldValue = _value;
				if (!oldValue.Equals(value))
				{
					_value = value;
					PreviousValue = oldValue;
					InvokeOnChanged();
				}
			}
		}

		public T PreviousValue
		{
			get
			{
				return _previousValue;
			}
			private set
			{
				_previousValue = value;
			}
		}

		public static implicit operator Observable<T>(T observable)
		{
			return new Observable<T>(observable);
		}

		public static explicit operator T(Observable<T> observable)
		{
			return observable._value;
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public bool Equals(Observable<T> other)
		{
			return other._value.Equals(_value);
		}

		public override bool Equals(object other)
		{
			return other != null
				&& other is Observable<T>
				&& ((Observable<T>)other)._value.Equals(_value);
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		/// <summary>
		/// NOTE: This is also called from the <see cref="ObservablePropertyDrawer"/>.
		/// </summary>
		protected override void InvokeOnValidate()
		{
			OnValidate.Invoke(this);
		}

		/// <summary>
		/// NOTE: This is also called from the <see cref="ObservablePropertyDrawer"/>.
		/// </summary>
		protected override void InvokeOnChanged()
		{
			OnChanged.Invoke(this);
		}
	}
}
