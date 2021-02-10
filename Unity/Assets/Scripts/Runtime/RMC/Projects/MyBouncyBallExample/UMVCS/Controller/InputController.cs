using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using RMC.Architectures.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class InputController : BaseController<NullModel, NullView, NullService>
	{
		protected void Update()
		{
			if (Input.GetKey (KeyCode.Space))
			{
				Context.CommandManager.InvokeCommand(new RestartApplicationCommand());
			}
		}
	}
}