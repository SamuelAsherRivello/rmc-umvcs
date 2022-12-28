using System.Collections.Generic;
using RMC.Core.Architectures.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Model.Data.Types;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model.Data.Types;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BouncyBallModel : BaseModel
	{
		public MainConfigData MainConfigData { get { return ConfigData as MainConfigData; } }
		public StateMachine StateMachine { get { return _stateMachine; } }
		private StateMachine _stateMachine = new StateMachine();

		public void InitializeStateMachine(BouncyBallController bouncyBallController)
		{
			List<IState> states = new List<IState>();
			states.Add(new FallingState(bouncyBallController));
			states.Add(new RisingState(bouncyBallController));
			_stateMachine.States = states;
		}
	}
}