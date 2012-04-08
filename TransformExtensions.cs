using UnityEngine;
using System.Collections;

public static class TransformExtensions {
	
	// Apply a transformation resembling a parenting relationship without setting up an actual parenting hierarchy
	public static void SoftParent (this Transform child, Transform parent)
	{
		Vector3 offset = child.position - parent.position;
		Vector3 scale = parent.localScale;
		
		// TRS
		offset.Scale (scale);
		child.position = parent.rotation * offset + parent.position;
		child.rotation = parent.rotation;
		// FIXME need to add the original rotation
		child.localScale.Scale (parent.localScale);
	}
	
	
	public static Transform FindParent (this Transform transform, string name)
	{
		Transform current = transform;
		while (current.parent)
		{
			current = current.parent;
			if (current.name == name)
				return current;
		}
		return null;
	}
	
	
	public static Transform FindSibling (this Transform transform, string name)
	{
		if (transform.parent)
			return transform.parent.Find (name);
		return null;
	}
	
	
	public static Transform FindFromRoot (this Transform transform, string name)
	{
		return transform.root.Find (name);
	}
	
	
	public static T GetComponentInParent<T> (this Transform transform)
		where T : Component
	{
		Transform current = transform;
		while (current.parent) {
			current = current.parent;
			T component = current.GetComponent<T> ();
			if (component != null)
				return component;
		}
		return null;
	}
	
	
	public static void SetX (this Transform trans, float value)
	{
		trans.position = new Vector3 (value, trans.position.y, trans.position.z);
	}
	
	public static void SetY (this Transform trans, float value)
	{
		trans.position = new Vector3 (trans.position.x, value, trans.position.z);
	}
	
	public static void SetZ (this Transform trans, float value)
	{
		trans.position = new Vector3 (trans.position.x, trans.position.y, value);
	}
	
}
