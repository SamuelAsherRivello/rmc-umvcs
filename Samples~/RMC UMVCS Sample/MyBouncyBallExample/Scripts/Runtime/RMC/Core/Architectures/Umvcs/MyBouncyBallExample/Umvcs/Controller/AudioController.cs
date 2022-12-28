using RMC.Core.Architectures.Umvcs.Controller;
using RMC.Core.Architectures.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.View;
using RMC.Core.Architectures.Umvcs.Service;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller
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