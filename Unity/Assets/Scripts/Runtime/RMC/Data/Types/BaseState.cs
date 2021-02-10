
using System;

namespace RMC.Data.Types
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseState : IState
	{
		public virtual void DestroyState()
		{
		}

		public virtual void EnterState()
		{
		}

		public virtual void ExitState()
		{
		}

		public virtual void InitializeState()
		{
		}

		public virtual Type UpdateState()
		{
			return null;
		}
	}
}
