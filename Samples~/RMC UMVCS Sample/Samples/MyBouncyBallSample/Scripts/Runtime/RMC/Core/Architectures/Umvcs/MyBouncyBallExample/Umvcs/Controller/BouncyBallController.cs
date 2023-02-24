using RMC.Core.Architectures.Umvcs.Controller;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model.Data.Types;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.View;
using RMC.Core.Architectures.Umvcs.Service;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller
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