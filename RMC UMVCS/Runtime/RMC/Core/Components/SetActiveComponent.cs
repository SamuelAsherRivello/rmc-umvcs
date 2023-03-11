using UnityEngine;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace RMC.Core.Components
{

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
	/// Description: Add this to a component so it begins active or not active. Good for debugging or production
	/// 
	/// NOTE: This doesn't permanently disable these objects because other 
	/// 		systems can still re-enable the gameobjects/scripts of course.
	/// 
	/// </summary>
	public class SetActiveComponent : MonoBehaviour 
	{


		//--------------------------------------
		//  Properties
		//--------------------------------------

		// 	PUBLIC

		/// <summary>
		/// What property to set
		/// NOTE: The '1' allows us to scale later.
		/// </summary>
		[SerializeField]
		private bool _willBeActiveOnAwake = true;


		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------

		/// <summary>
		/// This component is initialized
		/// </summary>
		protected void Awake () 
		{

			gameObject.SetActive (_willBeActiveOnAwake);
			enabled = _willBeActiveOnAwake;

		}


		/// <summary>
		/// All components on GameObject are initialized
		/// </summary>
		protected void Start () 
		{

		}

		//--------------------------------------
		// 	Methods
		//--------------------------------------


		// 	PUBLIC


		//	PRIVATE


		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------


	}
}
