using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using System;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class UIController : BaseController<NullModel, UIView, NullService>
	{
		private UIView _uiView { get { return BaseView as UIView; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<BounceCountChangedCommand>(
				CommandManager_OnBounceCountChanged);

			Context.CommandManager.AddCommandListener<CaptionTextChangedCommand>(
				CommandManager_OnCaptionTextChanged);

			SetBounceCountText(0);
			SetCaptionText("");
		}

		private void SetBounceCountText(int count)
		{
			int bounceCountMax = Context.ModelLocator.
				GetModel<MainModel>().MainConfigData.BounceCountMax;

			_uiView.BounceCountText.text = string.Format("BounceCount: {0:00}/{1:00}", count, bounceCountMax);
		}

		private void SetCaptionText(string text)
		{
			_uiView.CaptionText.text = text;
		}

		private void CommandManager_OnBounceCountChanged(BounceCountChangedCommand e)
		{
			SetBounceCountText(e.CurrentValue);
		}

		private void CommandManager_OnCaptionTextChanged(CaptionTextChangedCommand e)
		{
			SetCaptionText(e.CurrentValue);
		}
	}
}