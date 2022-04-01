using System;
using UnityEngine;

public static class Vector2Extentions
{
	public static float GetAngle(this Vector2 vector)
	{
		return Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
	}
}
