using UnityEngine;
using System.Collections;

public static class CameraExtensions {

	/// <summary>
	/// Camera extension method for creating a screen point ray that takes into account
	/// a modified camera projection matrix
	/// </summary>
	public static Ray ShiftedScreenPointToRay (this Camera cam, Vector3 position)
	{
		Vector3 nearPoint = cam.ScreenToViewportPoint (position);
		
		Vector3 farPoint = new Vector3 (nearPoint.x, nearPoint.y, -1);
		farPoint.z = -1;
				
		nearPoint = cam.cameraToWorldMatrix * nearPoint;
		farPoint = cam.cameraToWorldMatrix * farPoint;
		
		return new Ray (nearPoint, farPoint);
	}
	
}
