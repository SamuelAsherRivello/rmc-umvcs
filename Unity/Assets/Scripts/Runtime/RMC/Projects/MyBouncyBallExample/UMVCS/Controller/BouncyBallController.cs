using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using System;
using RMC.Data.Types;
using System.Collections.Generic;
using RMC.Projects.MyBouncyBallExample.Data.Types;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BouncyBallController : BaseController<BouncyBallModel, BouncyBallView, NullService>
	{
		public BouncyBallView BouncyBallView { get { return BaseView as BouncyBallView; } }
		public BouncyBallModel BouncyBallModel { get { return BaseModel as BouncyBallModel; } }

		protected void Start()
		{
			BouncyBallView.OnBounce.AddListener(BouncyBallView_OnBounce);

			BouncyBallModel.InitializeStateMachine(this);
			BouncyBallModel.StateMachine.CurrentStateType = typeof(FallingState);
		}
		protected void Update()
		{
			BouncyBallModel.StateMachine.UpdateStates();
		}

		private void BouncyBallView_OnBounce()
		{
			Context.CommandManager.InvokeCommand(new BouncedCommand());
		}

		public void PlayAudioClip(int audioClipIndex)
		{
			Context.CommandManager.InvokeCommand(new PlayAudioClipCommand(audioClipIndex));
		}
	}
}