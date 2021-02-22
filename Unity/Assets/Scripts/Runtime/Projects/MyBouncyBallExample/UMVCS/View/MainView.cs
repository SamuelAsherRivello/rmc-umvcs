
using RMC.Architectures.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
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