
using RMC.Core.Architectures.Umvcs.Controller.Commands;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class PlayAudioClipCommand : Command
	{
		public int AudioClipIndex { get { return _audioClipIndex; } }

		private int _audioClipIndex;

		public PlayAudioClipCommand (int audioClipIndex)
		{
			_audioClipIndex = audioClipIndex;
		}
	}
}

