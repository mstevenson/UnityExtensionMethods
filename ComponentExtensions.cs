using UnityEngine;
using System.Collections;
using System.Linq;

public static class ComponentExtensions {
	
	public static T NearestTo<T> (this IEnumerable<T> components, Vector3 position)
		where T : Component
	{
		float dist = Mathf.Infinity;
		T target = null;
		foreach (var c in components) {
			float newDist = Vector3.SqrMagnitude (position - c.transform.position);
			if (newDist < dist) {
				dist = newDist;
				target = c;
			}
		}
		return target;
	}
	
	public static T FarthestFrom<T> (this IEnumerable<T> components, Vector3 position)
		where T : Component
	{
		float dist = 0;
		T target = null;
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
