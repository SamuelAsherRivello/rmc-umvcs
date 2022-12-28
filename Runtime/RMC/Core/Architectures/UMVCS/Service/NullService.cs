using RMC.Core.Architectures.Umvcs.Context;

namespace RMC.Core.Architectures.Umvcs.Service
{
	/// <summary>
	/// This is a null instance used (temporarily or permanently) 
	/// when no service is needed.
	/// </summary>
	public class NullService : BaseService, INullableActor
	{
	}
}