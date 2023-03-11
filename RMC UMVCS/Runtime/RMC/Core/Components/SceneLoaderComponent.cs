using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMC.Core.Components
{
	/// <summary>
	/// Loads a new <see cref="Scene"/> immediately.
	/// </summary>
	public class SceneLoaderComponent : MonoBehaviour
	{
		[SerializeField] private string _sceneName = "";
		[SerializeField] private LoadSceneMode _loadSceneMode = LoadSceneMode.Additive;

		protected void Start()
		{
			SceneManager.LoadScene(_sceneName, _loadSceneMode);
		}
	}
}