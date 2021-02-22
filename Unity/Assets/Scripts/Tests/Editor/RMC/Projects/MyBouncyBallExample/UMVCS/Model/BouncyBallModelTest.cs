using NUnit.Framework;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{

	/// <summary>
	/// Test the public API of the <see cref="BouncyBallModelTest"/>.
	/// </summary>
	public class BouncyBallModelTest
	{
		private GameObject parentGameObject = null;

		[TearDown]
		public void OnTearDown()
		{
			if (parentGameObject != null)
			{
				GameObject.DestroyImmediate(parentGameObject, false);
			}
		}

		[Test]
		public void StateCount_IsZero_BeforeInitializeStateMachine()
		{
			// Arrange
			parentGameObject = new GameObject("ParentGameObject");
			BouncyBallModel bouncyBallModel = parentGameObject.AddComponent<BouncyBallModel>();

			// Act
			int stateCount = bouncyBallModel.StateMachine.States.Count;

			// Assert
			Assert.That(stateCount, Is.EqualTo(0));

		}

		[Test]
		public void StateCount_Is2_AfterInitializeStateMachine()
		{
			// Arrange
			parentGameObject = new GameObject("ParentGameObject");
			BouncyBallController bouncyBallController = parentGameObject.AddComponent<BouncyBallController>();
			BouncyBallModel bouncyBallModel = parentGameObject.AddComponent<BouncyBallModel>();

			// Act
			bouncyBallModel.InitializeStateMachine(bouncyBallController);
			int stateCount = bouncyBallModel.StateMachine.States.Count;

			// Assert
			Assert.That(stateCount, Is.EqualTo(2));

		}
	}
}
