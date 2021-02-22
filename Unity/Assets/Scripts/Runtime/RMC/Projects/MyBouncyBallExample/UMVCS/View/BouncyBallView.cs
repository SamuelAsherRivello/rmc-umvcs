using RMC.Architectures.UMVCS.View;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events;
using System;
using System.Collections;
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