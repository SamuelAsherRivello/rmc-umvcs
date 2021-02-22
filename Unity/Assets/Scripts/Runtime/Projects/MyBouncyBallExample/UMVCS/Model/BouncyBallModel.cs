using RMC.Architectures.UMVCS.Model;
using RMC.Data.Types;
using RMC.Projects.MyBouncyBallExample.Data.Types;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller;
using System.Collections.Generic;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
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