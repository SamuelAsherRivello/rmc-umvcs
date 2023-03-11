using RMC.Core.Architectures.Umvcs.Context;

namespace RMC.Core.Architectures.Umvcs.Model
{
	/// <summary>
	/// This is a null instance used (temporarily or permanently) 
	/// when no model is needed.
	/// </summary>
	public class NullModel : BaseModel, INullableActor
	{
	}
}