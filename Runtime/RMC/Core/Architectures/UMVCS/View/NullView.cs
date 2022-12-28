using RMC.Core.Architectures.Umvcs.Context;

namespace RMC.Core.Architectures.Umvcs.View
{
	/// <summary>
	/// This is a null instance used (temporarily or permanently) 
	/// when no view is needed.
	/// </summary>
	public class NullView : BaseView, INullableActor
	{
	}
}