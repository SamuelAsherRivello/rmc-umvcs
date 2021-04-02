//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace RMC.DesignPatterns.Singleton
{
	public abstract class SingletonMonoBehaviour : MonoBehaviour
	{

	}

	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// GOALS: Easily allow a Singleton to be added to hierarchy at runtime with full MonoBehavior access and predictable lifecycle.
	/// Usage:
	///
	/// </summary>
	public abstract class SingletonMonoBehaviour<T> : SingletonMonoBehaviour where T : MonoBehaviour
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		//	GETTER / SETTER
		/// <summary>
		/// Do not call this from another scope within OnDestroy(). Instead use IsInstantiated()
		/// </summary>
		private static T _Instance; //Harmless 'suggestion' appears here in some code-editors. Known issue.
		public static T Instance
		{

			//NOTE: Its recommended to wrap any calls to this getter with a IsInstanced() to prevent undesired instantiation. Optional.
			get
			{
				if (!IsInstantiated())
				{
					Instantiate();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
			
		}


				
		/// <summary>
		/// 
		/// NOTE: Calling this will NEVER instantiate a new instance. That is useful and safe to call in any destructors / OnDestroy()
		/// 
		/// </summary>
		/// <returns><c>true</c> if is instantiated; otherwise, <c>false</c>.</returns>
		public static bool IsInstantiated()
		{
			return _Instance != null;
		}
		
		
		// 	PUBLIC

		public delegate void OnInstantiateCompletedDelegate (T instance);
		public static OnInstantiateCompletedDelegate OnInstantiateCompleted;

		public delegate void OnDestroyingDelegate (T instance);
		public static OnDestroyingDelegate OnDestroying;
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	

		
		/// <summary>
		/// Instantiate this instance. 
		/// 	1. Attempts to find an existing GameObject that matches (There will be 0 or 1 at any time)
		/// 	2. Creates GameObject with name of subclass
		/// 	3. Persists by default (optional)
		/// 	4. Predictable life-cycle.
		/// 
		/// </summary>
		public static T Instantiate ()
		{
			
			if (!IsInstantiated())
			{
				T t  = GameObject.FindObjectOfType<T>();
                GameObject go = null;
                if (t != null)
                {
                    go = t.gameObject;
                }

				if (go == null)
				{
					go 			= new GameObject ();
					_Instance 	= go.AddComponent<T>();
				}
				else
				{
					_Instance = go.GetComponent<T>();
				}
				
				go.name 		= _Instance.GetType().Name;
				DontDestroyOnLoad (go);

				if (OnInstantiateCompleted != null)
				{
					OnInstantiateCompleted (_Instance);
				}
			}
			return _Instance;
		}

		virtual protected void Awake()
		{
			Instantiate();
		}

		/// <summary>
		/// Destroys all memory/references associated with the instance
		/// </summary>
		public static void Destroy()
		{
			
			if (IsInstantiated())
			{
				if (OnDestroying != null)
				{
					OnDestroying (_Instance);
				}

				// NOTE: Use 'DestroyImmediate'. At runtime its less important, but occasionally editor classes will call Destroy();
				DestroyImmediate (_Instance.gameObject);

				_Instance = null;
			}
		}
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------

		//	PUBLIC


		
		//	PRIVATE
		protected virtual void OnDestroy ()
		{
			//override as needed
		}

		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}

