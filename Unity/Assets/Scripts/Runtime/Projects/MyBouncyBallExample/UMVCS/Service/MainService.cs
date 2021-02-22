using RMC.Architectures.UMVCS.Service;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Service
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainService : BaseService
	{
		public LoadCompletedEvent OnLoadCompleted = new LoadCompletedEvent();

		public void Load ()
		{
			string url = Path.Combine(Application.streamingAssetsPath, "MainServiceDestination.txt");

			StartCoroutine(LoadCoroutine(url));
		}

		private IEnumerator LoadCoroutine(string uri)
		{
			UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
			yield return unityWebRequest.SendWebRequest();

			if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
			{
				Debug.Log("Error While Sending: " + unityWebRequest.error);
			}
			else
			{
				OnLoadCompleted.Invoke(unityWebRequest.downloadHandler.text);
			}
		}
	}
}