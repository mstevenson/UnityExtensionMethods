using UnityEngine;
using System.Collections;

public static class Texture2DExtensions
{
	/// <summary>
	/// Draw a GUI texture
	/// </summary>
	public static void DrawGUI (this Texture2D tex, float xOffset, float yOffset)
	{
		GUI.DrawTexture (new Rect (xOffset, yOffset, tex.width, tex.height), tex);
	}
	
	
	/// <summary>
	/// Create a basic material from this texture. Any materials created with this
	/// method from the same texture will be shared and can be batched.
	/// </summary>
	public static Material CreateSharedMaterial (this Texture2D texture, string shader)
	{
		Shader targetShader = Shader.Find (shader);
		Material[] mats = Object.FindObjectsOfType (typeof(Material)) as Material[];
		// Return existing material
		foreach (var mat in mats) {
			if (mat.shader != targetShader)
				continue;
			if (mat.mainTexture == null)
				continue;
			if (mat.mainTexture == texture)
				return mat;
		}
		// Create new material
		Material newMat = new Material (targetShader);
		newMat.mainTexture = texture;
		return newMat;
	}
}
