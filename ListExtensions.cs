using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ListExtensions
{

	/// <summary>
	/// Move an item from one index to another
	/// </summary>
	public static void Move<T> (this List<T> list, int oldIndex, int newIndex)
	{
		T item = list[oldIndex];
		list.RemoveAt (oldIndex);
		if (newIndex > oldIndex)
			newIndex--;
		list.Insert (newIndex, item);
	}
	
	
	/// <summary>
	/// Move an item from one index to another
	/// </summary>
	public static void Move<T> (this List<T> list, T item, int newIndex)
	{
		int oldIndex = list.IndexOf (item);
		list.RemoveAt (oldIndex);
		if (newIndex > oldIndex)
			newIndex--;
		list.Insert (newIndex, item);
	}
	
}
