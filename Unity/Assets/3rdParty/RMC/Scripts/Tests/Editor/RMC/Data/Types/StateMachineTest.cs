using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RMC.Data.Types
{
	public class TestState01 : BaseState
	{
		public bool HasCalledDestoyState = false;
		public bool HasCalledEnterState = false;
		public bool HasCalledExitState = false;
		public bool HasCalledInitializeState = false;
		public bool HasCalledUpdateState = false;

		public override void DestroyState()		{ HasCalledDestoyState = true; }
		public override void EnterState()		{ HasCalledEnterState = true; }
		public override void ExitState()		{ HasCalledExitState = true; }
		public override void InitializeState()	{ HasCalledInitializeState = true; }
		public override Type UpdateState()		{ HasCalledUpdateState = true;  return null;  }
	}

	public class TestState02 : BaseState
	{
		public override void DestroyState() { }
		public override void EnterState() { }
		public override void ExitState() { }
		public override void InitializeState() { }
		public override Type UpdateState() { return null; }
	}

	public class StateMachineTest
	{
		[Test]
		public void HasState_True_WhenStateExists()
		{
			// Arrange
			StateMachine stateMachine = new StateMachine();
			List<IState> states = new List<IState>();
			states.Add(new TestState01());

			// Act
			stateMachine.States = states;

			// Assert
			Assert.That(stateMachine.HasState<TestState01>(), Is.True);
		}

		[Test]
		public void HasState_False_WhenStateDoesNotExist()
		{
			// Arrange
			StateMachine stateMachine = new StateMachine();
			List<IState> states = new List<IState>();
			states.Add(new TestState01());

			// Act
			stateMachine.States = states;

			// Assert
			Assert.That(stateMachine.HasState<TestState02>(), Is.False);
		}

		[Test]
		public void FullMethodLifecycleCalled_WhenCalled()
		{
			// Arrange
			TestState01 testState01 = new TestState01();
			TestState02 testState02 = new TestState02();


			// Act
			StateMachine stateMachine = new StateMachine(new List<IState> { testState01, testState02 });
			stateMachine.CurrentStateType = typeof(TestState01);
			stateMachine.UpdateStates();
			stateMachine.CurrentStateType = typeof(TestState02);
			stateMachine.DestroyStates();

			// Assert
			Assert.That(testState01.HasCalledInitializeState, Is.True);
			Assert.That(testState01.HasCalledEnterState, Is.True);
			Assert.That(testState01.HasCalledUpdateState, Is.True);
			Assert.That(testState01.HasCalledExitState, Is.True);
			Assert.That(testState01.HasCalledDestoyState, Is.True);
		}

		[Test]
		public void HasCalledInitializeStateTrue_WhenInitializeStateCalled()
		{
			// Arrange
			TestState01 testState01 = new TestState01();
			TestState02 testState02 = new TestState02();

			// Act
			StateMachine stateMachine = new StateMachine(new List<IState> { testState01, testState02 });

			// Assert
			Assert.That(testState01.HasCalledInitializeState, Is.True);
			Assert.That(testState01.HasCalledEnterState, Is.False);
			Assert.That(testState01.HasCalledUpdateState, Is.False);
			Assert.That(testState01.HasCalledExitState, Is.False);
			Assert.That(testState01.HasCalledDestoyState, Is.False);
		}
	}
}
