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
	
}
