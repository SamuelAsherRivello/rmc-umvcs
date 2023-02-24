using System.Collections;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Events;
using RMC.Core.Architectures.Umvcs.View;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.View
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

		/// <summary>
		/// Called on game start and on <see cref="RestartApplicationCommand"/>
		/// </summary>
		public void ResetBouncyBall(Vector3 position, bool willFade, float fadeDuration)
		{
			transform.position = position;
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;

			if (willFade)
			{
				_rigidbody.isKinematic = true;
				StartCoroutine(WaitBeforeDropping_Coroutine(fadeDuration));
			}
		}

		/// <summary>
		/// Wait before falling.
		/// </summary>
		/// <returns></returns>
		private IEnumerator WaitBeforeDropping_Coroutine(float fadeDuration)
		{
			yield return new WaitForSeconds(fadeDuration);
			_rigidbody.isKinematic = false;
		}
	}
}