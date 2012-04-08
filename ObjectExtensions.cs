using UnityEngine;
using System.Collections;

public static class ObjectExtensions {
	
	public static T FindObjectOfType<T> (this UnityEngine.Object obj)
		where T : UnityEngine.Object
	{
		return (UnityEngine.Object.FindObjectOfType(typeof(T)) as T);
	}
	
}
