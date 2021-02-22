using NUnit.Framework;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{

	/// <summary>
	/// Test the public API of the <see cref="MainModel"/>.
	/// </summary>
	public class MainModelTest
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
		public void BounceCount_IsZero_BeforeSetter()
		{
			// Arrange
			parentGameObject = new GameObject("ParentGameObject");
			MainModel mainModel = parentGameObject.AddComponent<MainModel>();

			// Act
			int bounceCount = mainModel.BounceCount.Value;

			// Assert
			Assert.That(bounceCount, Is.EqualTo(0));

		}
	}
}
