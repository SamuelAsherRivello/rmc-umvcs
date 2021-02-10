using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class AudioController : BaseController<NullModel, AudioView, NullService>
	{
		private AudioView _audioView { get { return BaseView as AudioView; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<PlayAudioClipCommand>(
				CommandManager_OnPlayAudioClip);

		}
		private void CommandManager_OnPlayAudioClip(PlayAudioClipCommand e)
		{
			_audioView.PlayAudioClip(e.AudioClipIndex);
		}
	}
}