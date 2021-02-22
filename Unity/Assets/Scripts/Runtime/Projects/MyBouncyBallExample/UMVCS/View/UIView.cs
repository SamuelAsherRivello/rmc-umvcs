using RMC.Architectures.UMVCS.View;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class UIView : BaseView
	{
		public Text BounceCountText { get { return _bounceCountText; } }
		public Text CaptionText { get { return _captionText; } }

		[SerializeField]
		private Text _bounceCountText = null;

		[SerializeField]
		private Text _captionText = null;
	}
}