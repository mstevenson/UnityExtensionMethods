using UnityEngine;
using System.Collections;

public static class AudioSourceExtensions
{

	public static void PlayClip (this AudioSource source, AudioClip clip)
	{
		source.clip = clip;
		source.Play ();
	}
	
}
