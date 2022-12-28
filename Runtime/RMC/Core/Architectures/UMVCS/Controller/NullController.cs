using RMC.Core.Architectures.Umvcs.Context;

namespace RMC.Core.Architectures.Umvcs.Controller
{
	/// <summary>
	/// This is a null instance used (temporarily or permanently) 
	/// when no controller is needed.
	/// </summary>
	public class NullController : BaseController, INullableActor
	{
	}
}