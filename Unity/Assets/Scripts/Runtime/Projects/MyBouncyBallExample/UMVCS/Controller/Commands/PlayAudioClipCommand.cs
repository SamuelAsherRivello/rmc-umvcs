
using RMC.Commands;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands
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

