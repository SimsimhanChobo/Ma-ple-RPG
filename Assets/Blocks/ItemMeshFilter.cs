using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), ExecuteInEditMode]
public class ItemMeshFilter : MonoBehaviour
{
    [HideInInspector]
    public Texture2D DefaultBlockImage;

    MeshFilter meshFilter;
    BoxCollider boxCollider;
    public string ItemTextureName;
    public bool CustomPath;

    [HideInInspector]
    public Texture2D ItemTexture;

    string tempItemTextureName;
    bool tempCustomPath;

    public static readonly Vector3[] voxelVerts = new Vector3[]
    {
            new Vector3(-0.5f, -0.5f, -0.5f), 
            new Vector3(-0.5f, 0.5f, -0.5f), 
            new Vector3(0.5f, -0.5f, -0.5f), 
            new Vector3(0.5f, 0.5f, -0.5f), 
            new Vector3(-0.5f, -0.5f, 0.5f), 
            new Vector3(-0.5f, 0.5f, 0.5f), 
            new Vector3(0.5f, -0.5f, 0.5f), 
            new Vector3(0.5f, 0.5f, 0.5f) 
    };

    public static readonly int[] voxelTris = new int[]
    {
        0,1,2,
        2,1,3,
        4,5,0,
        1,0,5,
        2,3,6,
        7,6,3,
        6,7,4,
        5,4,7,
        1,5,3,
        7,3,5,
        2,6,0,
        4,0,6
    };

    public static readonly Vector2[] voxelUvs = new Vector2[]
    {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
    };

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        boxCollider = GetComponent<BoxCollider>();
        meshFilter.mesh = ItemMeshCreate();

        if (!CustomPath)
            ItemTexture = ResourceManager.ResourceSearch<Texture2D>(ResourceManager.ItemTexturePath + ItemTextureName);
        else
            ItemTexture = ResourceManager.ResourceSearch<Texture2D>(ItemTextureName);

        if (ItemTexture != null)
        {
            meshFilter.mesh = ItemMeshCreate();
            meshFilter.sharedMesh.name = ItemTextureName;
            ItemTexture.name = ItemTextureName;
        }
        else
        {
            DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
            ItemTexture = DefaultBlockImage;
            meshFilter.mesh = ItemMeshCreate();
            meshFilter.sharedMesh.name = DefaultBlockImage.name;
            ItemTexture.name = DefaultBlockImage.name;
        }
    }

    void Update()
    {
        if (!Application.isPlaying && (tempItemTextureName != ItemTextureName || tempCustomPath != CustomPath))
        {
            if (!CustomPath)
                ItemTexture = ResourceManager.ResourceSearch<Texture2D>(ResourceManager.ItemTexturePath + ItemTextureName);
            else
                ItemTexture = ResourceManager.ResourceSearch<Texture2D>(ItemTextureName);

            if (ItemTexture != null)
            {
                meshFilter.mesh = ItemMeshCreate();
                meshFilter.sharedMesh.name = ItemTextureName;
                ItemTexture.name = ItemTextureName;
            }
            else
            {
                DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
                ItemTexture = DefaultBlockImage;
                meshFilter.mesh = ItemMeshCreate();
                meshFilter.sharedMesh.name = DefaultBlockImage.name;
                ItemTexture.name = DefaultBlockImage.name;
            }

            tempItemTextureName = ItemTextureName;
            tempCustomPath = CustomPath;
        }
    }

    public Mesh ItemMeshCreate()
    {
        Mesh mesh = new Mesh
        {
            name = "Block Mesh",
            vertices = voxelVerts,
            triangles = voxelTris,
            uv = voxelUvs
        };

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }
}
