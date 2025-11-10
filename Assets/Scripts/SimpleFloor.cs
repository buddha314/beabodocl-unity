using UnityEngine;

/// <summary>
/// Creates a simple floor plane for VR environments
/// Attach to an empty GameObject at the scene root
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class SimpleFloor : MonoBehaviour
{
    [SerializeField] private float width = 20f;
    [SerializeField] private float depth = 20f;
    [SerializeField] private Material floorMaterial;

    void Start()
    {
        CreateFloor();
    }

    void CreateFloor()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        
        // Create a simple quad mesh
        Mesh mesh = new Mesh();
        mesh.name = "Floor";

        // Define vertices for a flat plane
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(-width/2, 0, -depth/2),
            new Vector3(width/2, 0, -depth/2),
            new Vector3(-width/2, 0, depth/2),
            new Vector3(width/2, 0, depth/2)
        };

        // Define triangles
        int[] triangles = new int[6]
        {
            0, 2, 1,
            2, 3, 1
        };

        // Define normals (pointing up)
        Vector3[] normals = new Vector3[4]
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up
        };

        // Define UVs
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;

        // Apply material
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (floorMaterial != null)
        {
            meshRenderer.material = floorMaterial;
        }
        else
        {
            // Create default gray material
            meshRenderer.material = new Material(Shader.Find("Standard"));
            meshRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}
