using RMC.Architectures.UMVCS.View;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{ 
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BouncyBallView : BaseView
	{
		public BouncedEvent OnBounce = new BouncedEvent();

		public Rigidbody Rigidbody { get { return _rigidbody; } }

		[SerializeField]
		private Rigidbody _rigidbody = null;

		protected void OnCollisionEnter (Collision collision)
		{
			OnBounce.Invoke();
		}
	}
}