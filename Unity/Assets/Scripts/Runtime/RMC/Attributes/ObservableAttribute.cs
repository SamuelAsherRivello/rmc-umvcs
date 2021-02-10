using UnityEngine;

namespace RMC.Attributes
{
	/// <summary>
	/// By default the <see cref="ObservablePropertyDrawer"/> only shows
	/// SOME of its properties in the inspector. If you want to show ALL,
	/// use this attribute before a <see cref="Observable"/> field.
	/// </summary>
	public class ObservableAttribute : PropertyAttribute
	{
		public bool WillShowAllChildren = false;
		public bool IsEditable = true;

		public ObservableAttribute(bool isEditable = true, bool willShowAllChildren = false)
		{
			isEditable = IsEditable;
			WillShowAllChildren = willShowAllChildren;
		}
	}
}