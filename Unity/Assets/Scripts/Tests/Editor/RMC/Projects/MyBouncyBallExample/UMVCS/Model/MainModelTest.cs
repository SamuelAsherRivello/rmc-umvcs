using UnityEngine;
using NUnit.Framework;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{
	/// <summary>
	/// Test the public API of the <see cref="MainModel"/>.
	/// </summary>
	[Category("RMC.Projects.MyBouncyBallExample")]
	public class MainModelTest
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
		public void BounceCount_IsZero_BeforeSetter()
		{
			// Arrange
			_parentGameObject = new GameObject("ParentGameObject");
			MainModel mainModel = _parentGameObject.AddComponent<MainModel>();

			// Act
			int bounceCount = mainModel.BounceCount.Value;

			// Assert
			Assert.That(bounceCount, Is.EqualTo(0));

		}
	}
}
