using System;
using RMC.Core.Architectures.Umvcs.Model.Data.Types;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model.Data.Types
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
			//Sound Commented Out - Too noisy for now
			//_bouncyBallController.PlayAudioClip(MyBouncyBallExampleConstants.AudioIndexRising);
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
