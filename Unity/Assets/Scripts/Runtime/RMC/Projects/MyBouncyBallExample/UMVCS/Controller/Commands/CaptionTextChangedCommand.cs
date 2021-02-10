
using RMC.Commands;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands
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

