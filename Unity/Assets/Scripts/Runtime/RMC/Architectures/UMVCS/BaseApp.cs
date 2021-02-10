using RMC.Managers;
using UnityEngine;

namespace RMC.Architectures.UMVCS
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseApp : MonoBehaviour 
	{
		public static BaseApp Instance { get { return _instance; } }
		public Context Context { get { return _context; } }
		
		private static BaseApp _instance = null;
		private Context _context = null;

		protected void Awake()
		{
			_instance = this;
			_context = new Context();
		}
	}

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseApp<T> : BaseApp where T : BaseApp
	{
	}
}