using UnityEngine;
using System.Collections;

public static class MonobehaviourExtensions
{
	public static void AutoSerializeNetworkView<T> (this MonoBehaviour self, BitStream stream, NetworkMessageInfo info)
		where T : MonoBehaviour
	{
		var fields = typeof(T).GetFields ();
		foreach (var f in fields) {
			var val = f.GetValue (self);
			if (val is int) {
				int s = 0;
				if (stream.isWriting) {
					s = (int)val;
					stream.Serialize (ref (int)s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is float) {
				float s = 0;
				if (stream.isWriting) {
					s = (float)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is bool) {
				bool s = false;
				if (stream.isWriting) {
					s = (bool)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is char) {
				char s = ' ';
				if (stream.isWriting) {
					s = (char)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is short) {
				short s = 0;
				if (stream.isWriting) {
					s = (short)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is Quaternion) {
				Quaternion s = Quaternion.identity;
				if (stream.isWriting) {
					s = (Quaternion)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is Vector3) {
				Vector3 s = Vector3.zero;
				if (stream.isWriting) {
					s = (Vector3)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is NetworkPlayer) {
				NetworkPlayer s = new NetworkPlayer ();
				if (stream.isWriting) {
					s = (NetworkPlayer)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			} else if (val is NetworkViewID) {
				NetworkViewID s = new NetworkViewID ();
				if (stream.isWriting) {
					s = (NetworkViewID)val;
					stream.Serialize (ref s);
				} else {
					stream.Serialize (ref s);
					f.SetValue (self, s);
				}
			}
		}
	}
}
