using UnityEngine;
using System.Collections.Generic;

public class CustomMesh : MonoBehaviour {

  private List<Vector3> vertices = new List<Vector3>();
  private List<Vector3> normals = new List<Vector3>();
  private List<Vector2> uvs = new List<Vector2>();
  private List<int> indices = new List<int>();

  void Start()
  {
    constructMesh();
  }

	// Update is called once per frame
	void Update () {
	}

  private void constructMesh()
  {
    
    MeshFilter filter = GetComponent<MeshFilter>();
    if (filter.mesh == null)
    {
      filter.mesh = new Mesh();
    }
    else
    {
      filter.mesh.Clear();
    }
    updateMesh(filter.mesh);
  }

  private void updateMesh(Mesh mesh)
  {
    makePyramid(new Vector3(0.5f, 0, -0.5f), new Vector3(-0.5f, 0, -0.5f), new Vector3(0, 0, 0.5f), new Vector3(0, 1, 0));
    mesh.vertices = vertices.ToArray();
    mesh.normals = normals.ToArray();
    mesh.uv = uvs.ToArray();
    mesh.triangles = indices.ToArray();
    mesh.RecalculateBounds();
  }

  private void makePyramid(Vector3 b1, Vector3 b2, Vector3 b3, Vector3 top)
  {
    //make all 4 faces of the pyramid
    Vector3 topToB1 = b1 - top;
    Vector3 topToB2 = b2 - top;
    Vector3 topToB3 = b3 - top;
    Vector3 b1ToB2 = b2 - b1;
    Vector3 b1ToB3 = b3 - b1;
    //face 1
    Vector3 normal = Vector3.Cross(topToB1, topToB2);
    makeTriangle(b1, b2, top, normal);
    //face 2
    normal = Vector3.Cross(topToB2, topToB3);
    makeTriangle(b2, b3, top, normal);
    //face3
    normal = Vector3.Cross(topToB3, topToB1);
    makeTriangle(b3, b1, top, normal);
    //face4
    normal = Vector3.Cross(b1ToB2, b1ToB3);
    makeTriangle(b1, b2, b3, normal);
  }

  private void makeTriangle(Vector3 b1, Vector3 b2, Vector3 b3, Vector3 normal)
  {

    int[] tmpInd = new int[3];
    Vector3[] tmpVert = new Vector3[3]{b1, b2, b3};
    //add the 3 vertices and normals (and uvs ?)
    for (int i = 0; i < 3; ++i)
    {
      if (!vertices.Contains(tmpVert[i]))
      {
        tmpInd[i] = vertices.Count;
        vertices.Add(tmpVert[i]);
        normals.Add(normal);
        uvs.Add(new Vector2(0, 1));
      }
      else
      {
        tmpInd[i] = vertices.IndexOf(tmpVert[i]);
      }
      indices.Add(tmpInd[i]);
    }
  }

}
