using RMC.Architectures.UMVCS.Model;
using NUnit.Framework;
using UnityEngine;

namespace RMC.Architectures.UMVCS
{
	public class TestModel : BaseModel { }

	[Category("RMC.Architectures")]
	public class ModelLocatorTest
	{
		private GameObject _parentGameObject = null;
		
		private GameObject _baseAppGameObject = null;
		
		[SetUp]
		public void OnSetUp()
		{
			//The tests depend on the BaseApp existing
			_baseAppGameObject = new GameObject();
			BaseApp baseApp = _baseAppGameObject.AddComponent<BaseApp>();
		}
		
		[TearDown]
		public void OnTearDown()
		{
			if (_baseAppGameObject != null)
			{
				GameObject.DestroyImmediate(_baseAppGameObject.gameObject, false);
			}
			
			//The tests may need a parent GO to attach testable scripts onto
			if (_parentGameObject != null)
			{
				GameObject.DestroyImmediate(_parentGameObject, false);
			}
		}
		
		[Test]
		public void TestModel_ThrowsNoException_WhenCreated()
		{
			// Arrange
			ModelLocator modelLocator = new ModelLocator();
			_parentGameObject = new GameObject();

			// Act
			TestModel testModel = _parentGameObject.AddComponent<TestModel>();

			// Assert
			Assert.That(testModel, Is.Not.Null);

		}
		
		[Test]
		public void GetModel_ValueSameAs_AddModel()
		{
			// Arrange
			ModelLocator modelLocator = new ModelLocator();
			_parentGameObject = new GameObject();
			TestModel testModel = _parentGameObject.AddComponent<TestModel>();

			// Act
			modelLocator.AddModel(testModel);
			TestModel foundTestModel = modelLocator.GetModel<TestModel>();

			// Assert
			Assert.That(foundTestModel, Is.SameAs(testModel));

		}
	}
}
