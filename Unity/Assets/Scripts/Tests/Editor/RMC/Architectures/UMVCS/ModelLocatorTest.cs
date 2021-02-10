using NUnit.Framework;
using RMC.Architectures.UMVCS.Model;

namespace RMC.Architectures.UMVCS
{
	public class TestModel : BaseModel { }

	public class ModelLocatorTest
	{
		[Test]
		public void GetModel_ValueSameAs_AddModel()
		{
			// Arrange
			ModelLocator modelLocator = new ModelLocator();
			TestModel testModel = new TestModel();

			// Act
			modelLocator.AddModel(testModel);
			TestModel foundTestModel = modelLocator.GetModel<TestModel>();

			// Assert
			Assert.That(foundTestModel, Is.SameAs(testModel));

		}
	}
}
