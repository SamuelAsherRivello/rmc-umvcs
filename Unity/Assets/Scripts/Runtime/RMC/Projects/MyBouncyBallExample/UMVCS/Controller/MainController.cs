using RMC.Architectures.UMVCS.Controller;
using RMC.Data.Types;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Service;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainController : BaseController<MainModel, MainView, MainService>
	{
		private MainModel _mainModel { get { return BaseModel as MainModel; } }
		private MainView _mainView { get { return BaseView as MainView; } }
		private MainService _mainService { get { return BaseService as MainService; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<BouncedCommand>(
				CommandManager_OnBounced);
			Context.CommandManager.AddCommandListener<RestartApplicationCommand>(
				CommandManager_OnRestartApplication);

			_mainModel.BounceCount.OnChanged.AddListener(MainModel_OnBounceCountChanged);
			_mainModel.CaptionText.OnChanged.AddListener(MainModel_OnCaptionTextChanged);
			_mainService.OnLoadCompleted.AddListener(MainService_OnLoadCompleted);

			RestartApplication();
		}



		private void RestartApplication()
		{
			if (_mainModel.BouncyBallView != null)
			{
				Destroy(_mainModel.BouncyBallView.gameObject);
			}

			_mainModel.BouncyBallView = Instantiate(_mainView.BouncyBallViewPrefab) as BouncyBallView;
			_mainModel.BouncyBallView.transform.SetParent(_mainView.BouncyBallParent);
			_mainModel.BouncyBallView.transform.position =
				_mainModel.MainConfigData.InitialBouncyBallPosition;

			_mainModel.BounceCount.Value = 0;

			_mainService.OnLoadCompleted.AddListener(MainService_OnLoadCompleted);
			_mainService.Load();
		}

		private void CommandManager_OnRestartApplication(RestartApplicationCommand e)
		{
			RestartApplication();
		}

		private void MainService_OnLoadCompleted(string text)
		{
			_mainModel.CaptionText.Value = text;
		}

		private void MainModel_OnCaptionTextChanged(Observable obs)
		{
			ObservableString observable = obs as ObservableString;

			Context.CommandManager.InvokeCommand(
				new CaptionTextChangedCommand(observable.PreviousValue, observable.Value));
		}

		private void MainModel_OnBounceCountChanged(Observable obs)
		{
			ObservableInt observable = obs as ObservableInt;
			int bounceCountMax = _mainModel.MainConfigData.BounceCountMax;

			// Reset the count here, this is a contrived example
			// of a Controller mitigating changes to a Model
			if (observable.Value > bounceCountMax)
			{
				Debug.Log($"bounceCountMax of {bounceCountMax} reached. Reset count.");
				_mainModel.BounceCount.Value = 0;
				return;
			}

			Context.CommandManager.InvokeCommand(
				new BounceCountChangedCommand(observable.PreviousValue, observable.Value));
		}

		private void CommandManager_OnBounced(BouncedCommand e)
		{
			_mainModel.BounceCount.Value = _mainModel.BounceCount.Value + 1;

			Context.CommandManager.InvokeCommand(new PlayAudioClipCommand(MyBouncyBallExampleConstants.AudioIndexBounce));
		}
	}
}