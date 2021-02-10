using UnityEngine;

namespace RMC.Attributes
{
	/// <summary>
	/// Allows already [SerializField] fields to be non-editable in the inspector.
	/// This is useful to see values for debugging, but not permit (or purposefully support) changing values via inspector
	/// Reference: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
	/// </summary>
	public class ReadOnlyAttribute : PropertyAttribute
	{
	}
}