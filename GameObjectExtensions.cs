using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class GameObjectExtensions {
	
	// From this thread:  http://forum.unity3d.com/threads/101028-How-to-Get-all-components-on-an-object-that-implement-an-interface.
		
	/// <summary>
	/// Returns all monobehaviours (casted to T)
	/// </summary>
	/// <typeparam name="T">interface type</typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T[] GetInterfaces<T> (this GameObject gObj)
	{
		if (!typeof(T).IsInterface)
			throw new System.Exception ("Specified type is not an interface!");
		var mObjs = gObj.GetComponents<MonoBehaviour> ();
		return (from a in mObjs
		        where a.GetType ().GetInterfaces ().Any(k => k == typeof(T))
		        select (T)(object)a
		        ).ToArray();
	}
	
	/// <summary>
	/// Returns the first monobehaviour that is of the interface type (casted to T)
	/// </summary>
	/// <typeparam name="T">Interface type</typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T GetInterface<T> (this GameObject gObj)
	{
		if (!typeof(T).IsInterface)
			throw new System.Exception("Specified type is not an interface!");
		return gObj.GetInterfaces<T> ().FirstOrDefault();
	}
	
	/// <summary>
	/// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T GetInterfaceInChildren<T> (this GameObject gObj)
	{
		if (!typeof (T).IsInterface)
			throw new System.Exception ("Specified type is not an interface!");
		return gObj.GetInterfacesInChildren<T> ().FirstOrDefault ();
	}
	
	/// <summary>
	/// Gets all monobehaviours in children that implement the interface of type T (casted to T)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T[] GetInterfacesInChildren<T> (this GameObject gObj)
	{
		if (!typeof(T).IsInterface)
			throw new System.Exception("Specified type is not an interface!");
		var mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();
		return (from a in mObjs
		        where a.GetType ().GetInterfaces ().Any (k => k == typeof(T))
		        select (T)(object)a
		        ).ToArray();
	}

	/// <summary>
	/// Finds the GameObject within a collection that is nearest to the given point.
	/// </summary>
	public static GameObject NearestTo (this IEnumerable<GameObject> components, Vector3 position)
	{
		float dist = Mathf.Infinity;
		GameObject target = null;
		foreach (var c in components) {
			float newDist = Vector3.SqrMagnitude (position - c.transform.position);
			if (newDist < dist) {
				dist = newDist;
				target = c;
			}
		}
		return target;
	}

	/// <summary>
	/// Finds the GameObject within a collection that is farthest from the given point.
	/// </summary>
	public static GameObject FarthestFrom (this IEnumerable<GameObject> components, Vector3 position)
	{
		float dist = 0;
		GameObject target = null;
		foreach (var c in components) {
			float newDist = Vector3.SqrMagnitude (position - c.transform.position);
			if (newDist > dist) {
				dist = newDist;
				target = c;
			}
		}
		return target;
	}
}
