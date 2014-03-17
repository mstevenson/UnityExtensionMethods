using UnityEngine;
using System.Collections;

public static class MeshExtensions
{
	/// <summary>
	/// Clone a given mesh and return a reference to it.
	/// </summary>
	public static Mesh CopyMesh (this Mesh mesh)
	{
		Mesh newMesh = new Mesh();
		newMesh.vertices = mesh.vertices;
		newMesh.triangles = mesh.triangles;
		newMesh.uv = mesh.uv;
		newMesh.normals = mesh.normals;
		newMesh.colors = mesh.colors;
		newMesh.tangents = mesh.tangents;
		return newMesh;
	}
}
