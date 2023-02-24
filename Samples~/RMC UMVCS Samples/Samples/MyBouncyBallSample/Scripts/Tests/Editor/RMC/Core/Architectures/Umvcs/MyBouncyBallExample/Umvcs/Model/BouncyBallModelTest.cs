using UnityEngine;
using NUnit.Framework;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model
{
	[Category("RMC.Projects.MyBouncyBallExample")]
	/// <summary>
	/// Test the public API of the <see cref="BouncyBallModelTest"/>.
	/// </summary>
	public class BouncyBallModelTest
	{
		private GameObject _parentGameObject = null;

		[TearDown]
		public void OnTearDown()
		{
			if (_parentGameObject != null)
			{
				GameObject.DestroyImmediate(_parentGameObject, false);
			}
		}

		[Test]
		public void StateCount_IsZero_BeforeInitializeStateMachine()
		{
			// Arrange
			_parentGameObject = new GameObject("ParentGameObject");
			BouncyBallModel bouncyBallModel = _parentGameObject.AddComponent<BouncyBallModel>();

			// Act
			int stateCount = bouncyBallModel.StateMachine.States.Count;

			// Assert
			Assert.That(stateCount, Is.EqualTo(0));

		}

		[Test]
		public void StateCount_Is2_AfterInitializeStateMachine()
		{
			// Arrange
			_parentGameObject = new GameObject("ParentGameObject");
			BouncyBallController bouncyBallController = _parentGameObject.AddComponent<BouncyBallController>();
			BouncyBallModel bouncyBallModel = _parentGameObject.AddComponent<BouncyBallModel>();

			// Act
			bouncyBallModel.InitializeStateMachine(bouncyBallController);
			int stateCount = bouncyBallModel.StateMachine.States.Count;

			// Assert
			Assert.That(stateCount, Is.EqualTo(2));

		}
	}
}
