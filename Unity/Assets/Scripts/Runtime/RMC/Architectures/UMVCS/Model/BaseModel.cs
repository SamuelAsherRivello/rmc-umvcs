using RMC.Architectures.UMVCS.Model.Data;
using UnityEngine;

namespace RMC.Architectures.UMVCS.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseModel : BaseActor
	{
		protected BaseConfigData ConfigData { get { return _configData; } }

		[SerializeField]
		private BaseConfigData _configData = null;

		public override void Initialize()
		{
			if (!IsInitialized)
			{
				BaseApp.Instance.Context.ModelLocator.AddModel(this);
			}
			base.Initialize();
		}

		protected override void UnInitialize()
		{
			if (IsInitialized)
			{
				BaseApp.Instance.Context.ModelLocator.RemoveModel(this);
			}
			base.UnInitialize();
		}
	}
}