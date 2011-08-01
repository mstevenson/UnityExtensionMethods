using UnityEngine;
using System.Collections;

public static class RayExtensinos
{

	public static Vector3 ClosestPoint (this Ray r, Vector3 position)
	{
		Vector3 point = position - r.origin;
		Vector3 projection = Vector3.Project (point, r.direction);
		return point - projection;
	}
	
}
