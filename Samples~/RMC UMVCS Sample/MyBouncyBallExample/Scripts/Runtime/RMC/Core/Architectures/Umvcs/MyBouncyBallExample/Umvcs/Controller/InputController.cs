using RMC.Core.Architectures.Umvcs.Controller;
using RMC.Core.Architectures.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Commands;
using RMC.Core.Architectures.Umvcs.Service;
using RMC.Core.Architectures.Umvcs.View;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class InputController : BaseController<NullModel, NullView, NullService>
	{
		protected void Update()
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				Context.CommandManager.InvokeCommand(new RestartApplicationCommand());
			}
		}
	}
}