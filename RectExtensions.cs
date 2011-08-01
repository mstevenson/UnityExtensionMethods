using UnityEngine;

public static class RectExtensions
{
	public static Rect Scale (this Rect rect, float scale)
	{
		return new Rect (rect.x * scale, rect.y * scale, rect.width * scale, rect.height * scale);
	}
}

