using NUnit.Framework;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{
	/// <summary>
	/// Test the public API of the <see cref="MainModel"/>.
	/// </summary>
	public class MainModelTest
	{
		[Test]
		public void BounceCount_IsZero_BeforeSetter()
		{
			// Arrange
			MainModel mainModel = new MainModel();

			// Act
			int bounceCount = mainModel.BounceCount.Value;

			// Assert
			Assert.That(bounceCount, Is.EqualTo(0));

		}
	}
}
