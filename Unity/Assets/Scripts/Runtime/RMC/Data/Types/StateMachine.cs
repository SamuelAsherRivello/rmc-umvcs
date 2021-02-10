using System;
using System.Collections.Generic;
using UnityEngine;

namespace RMC.Data.Types
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class StateMachine 
	{
		public List<IState> States
		{
			get
			{
				return _states;
			}
			set
			{
				_states = value;

				if (_states != null)
				{
					foreach (IState state in _states)
					{
						state.InitializeState();
					}
				}
			}
		}

		public Type CurrentStateType
		{
			get
			{
				return _currentStateType;
			}
			set
			{
				if (_currentState != null)
				{
					_currentState.ExitState();
				}
				_currentStateType = value;
				_currentState = GetStateByType(_currentStateType);

				if (_currentState != null)
				{
					_currentState.EnterState();
				}
			}
		}

		public IState CurrentState
		{
			get
			{
				return _currentState;
			}
		}

		private Type _currentStateType;



		private IState _currentState;
		private List<IState> _states;

		public StateMachine()
		{

		}

		public StateMachine (List<IState> states)
		{
			States = states;
		}

		public void UpdateStates()
		{
			if (_currentState == null)
			{
				return;
			}

			Type nextStateType = _currentState.UpdateState();

			if (nextStateType != null)
			{
				CurrentStateType = nextStateType;
			}
		}

		public void DestroyStates ()
		{
			foreach (IState state in _states)
			{
				state.DestroyState();
			}
			_states.Clear();
		}

		public bool HasState<T>()
		{
			return GetStateByType(typeof(T)) != null;
		}

		private IState GetStateByType(Type currentStateType)
		{
			foreach (IState state in _states)
			{
				if (state.GetType() == currentStateType)
				{
					return state;
				}
			}
			return null;
		}
	}
}
