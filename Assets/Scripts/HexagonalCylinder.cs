using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonalCylinder : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private float height = 2f;
    [SerializeField] private Material material;

    void Start()
    {
        GenerateHexagonalCylinder();
    }

    void GenerateHexagonalCylinder()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "HexagonalCylinder";

        int sides = 6;
        int vertexCount = (sides * 2) + 2; // sides * 2 for top and bottom rings + 2 for centers
        int triangleCount = (sides * 2) + (sides * 2); // top cap + bottom cap + sides

        Vector3[] vertices = new Vector3[sides * 4]; // Double vertices for proper normals on sides
        int[] triangles = new int[triangleCount * 3];
        Vector3[] normals = new Vector3[vertices.Length];
        Vector2[] uv = new Vector2[vertices.Length];

        float angleStep = 360f / sides;
        float halfHeight = height / 2f;

        // Generate vertices
        int vertIndex = 0;

        // Bottom ring vertices (for bottom cap)
        for (int i = 0; i < sides; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            
            vertices[vertIndex] = new Vector3(x, -halfHeight, z);
            normals[vertIndex] = Vector3.down;
            uv[vertIndex] = new Vector2((float)i / sides, 0);
            vertIndex++;
        }

        // Top ring vertices (for top cap)
        for (int i = 0; i < sides; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            
            vertices[vertIndex] = new Vector3(x, halfHeight, z);
            normals[vertIndex] = Vector3.up;
            uv[vertIndex] = new Vector2((float)i / sides, 1);
            vertIndex++;
        }

        // Bottom ring vertices (for sides)
        for (int i = 0; i < sides; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = new Vector3(x, -halfHeight, z);
            
            vertices[vertIndex] = pos;
            normals[vertIndex] = new Vector3(x, 0, z).normalized;
            uv[vertIndex] = new Vector2((float)i / sides, 0);
            vertIndex++;
        }

        // Top ring vertices (for sides)
        for (int i = 0; i < sides; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = new Vector3(x, halfHeight, z);
            
            vertices[vertIndex] = pos;
            normals[vertIndex] = new Vector3(x, 0, z).normalized;
            uv[vertIndex] = new Vector2((float)i / sides, 1);
            vertIndex++;
        }

        // Generate triangles
        int triIndex = 0;

        // Bottom cap triangles
        for (int i = 0; i < sides; i++)
        {
            int next = (i + 1) % sides;
            
            triangles[triIndex++] = i;
            triangles[triIndex++] = next;
            triangles[triIndex++] = (i + 2) % sides;
        }

        // Top cap triangles
        int topOffset = sides;
        for (int i = 0; i < sides; i++)
        {
            int next = (i + 1) % sides;
            
            triangles[triIndex++] = topOffset + i;
            triangles[triIndex++] = topOffset + (i + 2) % sides;
            triangles[triIndex++] = topOffset + next;
        }

        // Side triangles
        int sideBottomOffset = sides * 2;
        int sideTopOffset = sides * 3;
        
        for (int i = 0; i < sides; i++)
        {
            int next = (i + 1) % sides;
            
            // First triangle of quad
            triangles[triIndex++] = sideBottomOffset + i;
            triangles[triIndex++] = sideTopOffset + i;
            triangles[triIndex++] = sideBottomOffset + next;
            
            // Second triangle of quad
            triangles[triIndex++] = sideBottomOffset + next;
            triangles[triIndex++] = sideTopOffset + i;
            triangles[triIndex++] = sideTopOffset + next;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;

        // Apply material if assigned
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (material != null)
        {
            meshRenderer.material = material;
        }
        else
        {
            // Create a default material if none is assigned
            meshRenderer.material = new Material(Shader.Find("Standard"));
            meshRenderer.material.color = Color.cyan;
        }
    }

    // Allow updating in the editor
    void OnValidate()
    {
        if (Application.isPlaying)
        {
            GenerateHexagonalCylinder();
        }
    }
}
