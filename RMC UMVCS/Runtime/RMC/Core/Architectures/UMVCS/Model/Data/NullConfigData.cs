using RMC.Core.Architectures.Umvcs.Context;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Model.Data
{
	[CreateAssetMenu(fileName = "NullConfigData",
	menuName = UMVCSConstants.CreateAssetMenuPath + "NullConfigData",
	order = UMVCSConstants.CreateAssetMenuOrder)]

	/// <summary>
	/// This is a null instance used (temporarily or permanently) 
	/// when no ConfigData is needed.
	/// </summary>
	public class NullConfigData : BaseConfigData
	{
	}
}