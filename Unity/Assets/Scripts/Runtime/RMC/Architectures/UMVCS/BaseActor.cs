using UnityEngine;

namespace RMC.Architectures.UMVCS
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseActor : MonoBehaviour
	{
		protected bool IsInitialized { get { return _isInitialized; } }
		private bool _isInitialized = false;

		public virtual void Initialize()
		{
			if (!_isInitialized)
			{
				_isInitialized = true;
			}
		}

		protected virtual void UnInitialize()
		{
			if (_isInitialized)
			{
				_isInitialized = false;
			}
		}

		protected void Awake ()
		{
			Initialize();
		}

		protected void OnDestroy()
		{
			UnInitialize();
		}
	}
}