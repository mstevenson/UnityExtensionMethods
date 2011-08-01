using UnityEngine;
using System.Collections;

public static class Vector3Extensions {
	
	/// <summary>
	/// Find the largest component of a Vector3.
	/// </summary>
	public static float LargestComponent (this Vector3 v)
	{
		return v.x > v.y ? (v.x > v.z ? v.x : (v.y > v.z ? v.y : v.z)) : (v.y > v.z ? v.y : (v.x > v.z ? v.x : v.z));
	}
	
}
