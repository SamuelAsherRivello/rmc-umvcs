using RMC.Core.Architectures.Umvcs.View;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.View
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainView : BaseView
	{
		public Transform BouncyBallParent { get { return _bouncyBallParent; } }
		public BouncyBallView BouncyBallViewPrefab { get { return _bouncyBallViewPrefab; } }

		[SerializeField]
		private Transform _bouncyBallParent = null;

		[SerializeField]
		private BouncyBallView _bouncyBallViewPrefab = null;

	}
}