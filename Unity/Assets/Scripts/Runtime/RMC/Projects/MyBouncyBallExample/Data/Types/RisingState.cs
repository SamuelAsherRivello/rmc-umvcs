
using RMC.Data.Types;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller;
using System;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.Data.Types
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class RisingState : BaseState
	{
		private BouncyBallController _bouncyBallController;

		public RisingState(BouncyBallController bouncyBallController)
		{
			_bouncyBallController = bouncyBallController;
		}

		public override void DestroyState()
		{
		}

		public override void EnterState()
		{
			_bouncyBallController.PlayAudioClip(MyBouncyBallExampleConstants.AudioIndexRising);
		}

		public override void ExitState()
		{
		}

		public override void InitializeState()
		{
		}

		public override Type UpdateState()
		{
			if (_bouncyBallController.BouncyBallView.Rigidbody.velocity.y < 0)
			{
				return typeof(FallingState);
			}

			//Return null means "Do not change state"
			return null;
		}
	}
}
