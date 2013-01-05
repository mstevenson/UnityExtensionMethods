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
	
	public static Vector3 WithX (this Vector3 vec, float value)
	{
		return new Vector3 (value, vec.y, vec.z);
	}
	
	public static Vector3 WithY (this Vector3 vec, float value)
	{
		return new Vector3 (vec.x, value, vec.z);
	}
	
	public static Vector3 WithZ (this Vector3 vec, float value)
	{
		return new Vector3 (vec.x, vec.y, value);
	}
	
}
