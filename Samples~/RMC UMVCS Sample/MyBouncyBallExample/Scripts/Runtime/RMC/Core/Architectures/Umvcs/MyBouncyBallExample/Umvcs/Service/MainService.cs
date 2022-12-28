using System.Threading.Tasks;
using RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Controller.Events;
using RMC.Core.Architectures.Umvcs.Service;
using UnityEngine;

#pragma warning disable CS4014
namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Service
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainService : BaseService
	{
		public LoadCompletedEvent OnLoadCompleted = new LoadCompletedEvent();

		public void Load ()
		{
			LoadAsync();
		}

		private async Task LoadAsync()
		{
			var textAsset = Resources.Load<TextAsset>("MainService");
			
			//simulate loading
			await Task.Delay(100);
			
			if (textAsset == null)
			{
				Debug.Log("LoadCoroutine() failed.");
			}
			else
			{
				
				OnLoadCompleted.Invoke(textAsset.ToString());
			}
		}
	}
}