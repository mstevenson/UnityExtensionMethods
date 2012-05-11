using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
	/// <summary>
	/// Apply a transformation resembling a parenting relationship without setting up an actual parenting hierarchy.
	/// </summary>
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
		while (current.parent) {
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
	
	public static void SetScaleX (this Transform trans, float value)
	{
		trans.localScale = new Vector3 (value, trans.localScale.y, trans.localScale.z);
	}
	
	public static void SetScaleY (this Transform trans, float value)
	{
		trans.localScale = new Vector3 (trans.localScale.x, value, trans.localScale.z);
	}
	
	public static void SetScaleZ (this Transform trans, float value)
	{
		trans.localScale = new Vector3 (trans.localScale.x, trans.localScale.y, value);
	}
	
	public static void SetPositionX (this Transform trans, float value)
	{
		trans.position = new Vector3 (value, trans.position.y, trans.position.z);
	}
	
	public static void SetPositionY (this Transform trans, float value)
	{
		trans.position = new Vector3 (trans.position.x, value, trans.position.z);
	}
	
	public static void SetPositionZ (this Transform trans, float value)
	{
		trans.position = new Vector3 (trans.position.x, trans.position.y, value);
	}
	
	public static void SnapTo (this Transform self, Transform target)
	{
		self.position = target.position;
		self.rotation = target.rotation;
	}
	
	public static void SnapTo (this Transform self, GameObject target)
	{
		self.position = target.transform.position;
		self.rotation = target.transform.rotation;
	}
	
	public static void ParentTo (this Transform self, Transform parent)
	{
		self.parent = parent;
	}
	
	public static void ParentTo (this Transform self, GameObject parent)
	{
		self.parent = parent.transform;
	}
	
	/// <summary>
	/// Sets the transform to be a child of the given transform, and modifies its position and rotation to match its new parent.
	/// <seealso cref="SoftParent"/>
	/// </summary>
	public static void SnapAndParent (this Transform child, Transform parent)
	{
		transform.parent = parent;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
	
}
