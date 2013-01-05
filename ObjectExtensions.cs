using UnityEngine;
using System.Collections;

public static class ObjectExtensions {
	
	public static T FindObjectOfType<T> (this UnityEngine.Object obj)
		where T : UnityEngine.Object
	{
		return (UnityEngine.Object.FindObjectOfType (typeof(T)) as T);
	}
	
	public static T[] FindObjectsOfType<T> (this UnityEngine.Object obj)
		where T : UnityEngine.Object
	{
		return (UnityEngine.Object.FindObjectsOfType (typeof(T)) as T[]);
	}
}
