//--------------------------------------
//  Imports
//--------------------------------------

using System;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace RMC.DesignPatterns.Singleton
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
	/// This loads at most one <see cref="SingletonMonoBehaviour{T}"/>
	/// per type <see cref="{T}"/> per scene.
	/// </summary>
	public class SingletonMonoBehaviourLoader : MonoBehaviour
	{
		[SerializeField] private SingletonMonoBehaviour _singletonMonoBehaviour = null;
		[SerializeField] private Transform _parentTransform;
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		protected void Awake()
		{
			Instantiate();
		}
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		private void Instantiate()
		{
			Type type = _singletonMonoBehaviour.GetType();
			var instance = GameObject.FindObjectOfType(type);

			if (instance == null)
			{
				SingletonMonoBehaviour singletonMonoBehaviour = Instantiate(_singletonMonoBehaviour, _parentTransform);
			}
		}

		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}

