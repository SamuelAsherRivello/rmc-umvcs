using NUnit.Framework;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{

	public class BouncyBallModelTest
	{
		[Test]
		public void stateCount_IsZero_BeforeBlah()
		{
			// Arrange
			BouncyBallModel bouncyBallModel = new BouncyBallModel();

			// Act
			int stateCount = bouncyBallModel.StateMachine.States.Count;

			// Assert
			Assert.That(stateCount, Is.EqualTo(0));

		}
	}
}
