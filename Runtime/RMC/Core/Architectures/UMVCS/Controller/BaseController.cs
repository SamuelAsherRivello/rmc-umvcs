using RMC.Core.Architectures.Umvcs.Context;
using RMC.Core.Architectures.Umvcs.Service;
using RMC.Core.Architectures.Umvcs.View;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Controller
{
	public interface IUMVCSContainer { }

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseController : MonoBehaviour, IUMVCSContainer
	{
	}

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseController<M, V, S> : BaseController where V : BaseView where S : BaseService
	{
		public global::RMC.Core.Architectures.Umvcs.Context.Context Context { get { return BaseApp.Instance.Context; } }

		public M BaseModel { get { return _model; } set { _model = value; } }

		public V BaseView { get { return _view; } set { _view = value; } }

		public S BaseService { get { return _service; } set { _service = value; } }

		//Note: If a childclass chooses to set M = NullModel, it will not appear in Inspector
		//Per the BaseControllerEditor
		[SerializeField]
		private M _model = default(M); //Keep this short naming for inspector

		//Note: If a childclass chooses to set V = NullView, it will not appear in Inspector
		//Per the BaseControllerEditor
		[SerializeField]
		private V _view = null; //Keep this short naming for inspector

		//Note: If a childclass chooses to set S = NullModel, it will not appear in Inspector
		//Per the BaseControllerEditor
		[SerializeField]
		private S _service = null; //Keep this short naming for inspector

	}
}