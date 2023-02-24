using RMC.Core.Architectures.Umvcs.Controller.Commands;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class CaptionTextChangedCommand : PropertyChangedCommand<string>
	{
		public CaptionTextChangedCommand(string previousValue, string currentValue) : 
			base(previousValue, currentValue) { }
	}
}

