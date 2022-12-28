using RMC.Core.Architectures.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Model.Data.Types;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.View;
using RMC.Core.Attributes;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainModel : BaseModel
	{
		public MainConfigData MainConfigData { get { return ConfigData as MainConfigData; } }

		/// <summary>
		/// Using Observable<T> is optional. It includes a built-in 
		/// event notification upon change and is useful.
		/// </summary>
		// Want to the the OnChanged in the inspector? Use this [ObservableShowAllChildren]
		[Observable (IsEditable = false)]
		[SerializeField]
		public ObservableInt BounceCount = new ObservableInt();

		/// <summary>
		/// Using Observable<T> is optional. It includes a built-in 
		/// event notification upon change and is useful.
		/// </summary>
		// Want to the the OnChanged in the inspector? Use this [ObservableShowAllChildren]
		[Observable (IsEditable = false)]
		[SerializeField]
		public ObservableString CaptionText = new ObservableString();

		public BouncyBallView BouncyBallView { get { return _bouncyBallView; } set { _bouncyBallView = value; } }

		[ReadOnly]
		[SerializeField]
		private BouncyBallView _bouncyBallView = null;

		public override void Initialize()
		{
			if (!IsInitialized)
			{
				BounceCount.OnValidate.AddListener(BounceCount_OnValidate);
			}
			base.Initialize();
		}

		private void BounceCount_OnValidate(Observable obs)
		{
			ObservableInt observable = obs as ObservableInt;

			// Optional, if you want to correct the values 
			//observable.Value = Mathf.Clamp(observable.Value, 0, 10);
		}
	}
}