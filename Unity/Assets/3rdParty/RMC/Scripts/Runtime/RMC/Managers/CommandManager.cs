using RMC.Commands;
using System;
using System.Collections.Generic;

namespace RMC.Managers
{
	/// <summary>
	/// Available without permission. Write to code@RivelloMultimediaConsulting.com
	/// </summary>
	public class CommandManager
	{
		public void AddCommandListener<T>(CommandDelegate<T> del) where T : Command
		{
			AddCommandListenerImpl(del);
		}

		public void RemoveCommandListener<T>(CommandDelegate<T> del) where T : Command
		{
			RemoveCommandListenerImpl(del);
		}

		public void AddCommandListener<T>()
		{
			throw new NotImplementedException();
		}

		public void InvokeCommand(Command e)
		{
			InvokeCommandImpl(e);
		}
		public delegate void CommandDelegate<T>(T e) where T : Command;
		private delegate void CommandDelegate(Command e);

		private Dictionary<System.Type, CommandDelegate> _commandDelegates = new Dictionary<System.Type, CommandDelegate>();

		private Dictionary<System.Delegate, CommandDelegate> _commandDelegatesLookup = new Dictionary<System.Delegate, CommandDelegate>();

		private void AddCommandListenerImpl<T>(CommandDelegate<T> del) where T : Command
		{

			if (_commandDelegatesLookup.ContainsKey(del))
			{
				return;
			}

			CommandDelegate internalDelegate = (e) => del((T)e);
			_commandDelegatesLookup[del] = internalDelegate;

			CommandDelegate tempDel;
			if (_commandDelegates.TryGetValue(typeof(T), out tempDel))
			{
				_commandDelegates[typeof(T)] = tempDel += internalDelegate;
			}
			else
			{
				_commandDelegates[typeof(T)] = internalDelegate;
			}
		}

		private void RemoveCommandListenerImpl<T>(CommandDelegate<T> del) where T : Command
		{
			CommandDelegate internalDelegate;

			if (_commandDelegatesLookup.TryGetValue(del, out internalDelegate))
			{
				CommandDelegate tempDel;
				if (_commandDelegates.TryGetValue(typeof(T), out tempDel))
				{
					tempDel -= internalDelegate;
					if (tempDel == null)
					{
						_commandDelegates.Remove(typeof(T));
					}
					else
					{
						_commandDelegates[typeof(T)] = tempDel;
					}
				}

				_commandDelegatesLookup.Remove(del);
			}
		}

		public int DelegateLookupCount { get { return _commandDelegatesLookup.Count; } }

		private void InvokeCommandImpl(Command e)
		{
			CommandDelegate del;
			if (_commandDelegates.TryGetValue(e.GetType(), out del))
			{
				del.Invoke(e);
			}
		}
	}
}