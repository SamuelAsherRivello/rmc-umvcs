using UnityEngine;

namespace RMC.Templates
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class TemplateComponent : MonoBehaviour
	{
		public string SamplePublicText { get { return _samplePublicText; } set { _samplePublicText = value; } }

		[SerializeField]
		private string _samplePublicText;

		protected void Start()
		{

		}

		protected void Update()
		{

		}

		public string SamplePublicMethod(string message)
		{
			return message;
		}

		public void Target_OnEventOccurred(string message)
		{

		}
	}
}