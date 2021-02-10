using NUnit.Framework;
using RMC.Data.Types;
using UnityEngine;

namespace RMC.Data.Types
{
	public class ObservableTest
	{
		[Test]
		public void Constructor_Value_EqualsParameter(
			[Values (-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt(value);

			// Act

			// Assert
			Assert.That(observable.Value, Is.EqualTo(value));

		}

		[Test]
		public void SetValue_Value_EqualsParameter(
			[Values(-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt();
			observable.Value = value;

			// Act

			// Assert
			Assert.That(observable.Value, Is.EqualTo(value));
		}

		[Test]
		public void SetValue_PreviousValue_EqualsParameter(
			[Values(-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt();

			// Act
			observable.Value = value - 1; //We call twice to set both (prev and value)
			observable.Value = value;

			// Assert
			Assert.That(observable.PreviousValue, Is.EqualTo(value - 1));
		}

		[Test]
		public void OnChanged_Invoked_WhenValueChanges(
			[Values(-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt();
			bool isOnChangedCalled = false;

			// Act
			observable.Value = value + 1;
			observable.OnChanged.AddListener ( obs =>
			{
				isOnChangedCalled = true;
			});
			observable.Value = value;

			// Assert
			Assert.That(isOnChangedCalled, Is.True);
		}

		[Test]
		public void OnChanged_NotInvoked_WhenValueDoesNotChange(
			[Values(-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt();
			bool isOnChangedCalled = false;

			// Act
			observable.Value = value;
			observable.OnChanged.AddListener(obs =>
			{
				isOnChangedCalled = true;
			});
			observable.Value = value;

			// Assert
			Assert.That(isOnChangedCalled, Is.False);
		}

		[Test]
		public void OnChanged_EventState_EqualsState(
			[Values(-1, 0, 1)] int value
			)
		{
			// Arrange
			ObservableInt observable = new ObservableInt();
			int previousValue = int.MinValue;
			int currentValue = int.MinValue; 

			// Act
			observable.Value = value - 1;
			observable.OnChanged.AddListener(obs =>
			{
				ObservableInt observable2 = obs as ObservableInt;
				previousValue = observable2.PreviousValue;
				currentValue = observable2.Value;
			});
			observable.Value = value;

			// Assert
			Assert.That(observable.PreviousValue, Is.EqualTo(previousValue));
			Assert.That(observable.Value, Is.EqualTo(currentValue));
		}

		
	}
}
