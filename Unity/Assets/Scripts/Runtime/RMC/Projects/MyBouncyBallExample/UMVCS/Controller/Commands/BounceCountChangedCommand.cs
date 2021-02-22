
using RMC.Commands;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BounceCountChangedCommand : PropertyChangedCommand<int>
	{
		public BounceCountChangedCommand(int previousValue, int currentValue) : 
			base(previousValue, currentValue) 
		{
		}
	}
}

