using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), ExecuteInEditMode]
public class BlockMeshFilter : MonoBehaviour
{
    [HideInInspector]
    public Texture2D DefaultBlockImage;
    List<Texture2D> defaultBlockImage;

    List<Vector3> Vertices = new List<Vector3>();
    List<int> Triangles = new List<int>();

    static Rect[] RectTemp;
    static List<Vector2> UVTemp = new List<Vector2>();
    Vector2[] UV;

    MeshFilter meshFilter;
    BoxCollider boxCollider;
    public string BlockTextureName;

    [HideInInspector]
    public Texture2D BlockTexture;
    public Vector3 BlockPos;
    public Vector3 BlockSize = Vector3.one;
    public Vector2 UVPos;

    public bool LeftHidden = false;
    public bool FrontHidden = false;
    public bool RightHidden = false;
    public bool BackHidden = false;
    public bool TopHidden = false;
    public bool BottomHidden = false;

    Vector3 tempBlockPos;
    Vector3 tempBlockSize = Vector3.one;
    Vector2 tempUVPos;
    string tempBlockTextureName;
    bool tempLeftHidden;
    bool tempFrontHidden;
    bool tempRightHidden;
    bool tempBackHidden;
    bool tempTopHidden;
    bool tempBottomHidden;

    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {
            new Vector3(-0.5f, -0.5f, -0.5f), //Front Left Bottom
            new Vector3(0.5f, -0.5f, -0.5f), //Front Right Bottom
            new Vector3(0.5f, 0.5f, -0.5f), //Front Right Top
            new Vector3(-0.5f, 0.5f, -0.5f), //Front Left Top
            new Vector3(-0.5f, -0.5f, 0.5f), //Left Left Bottom
            new Vector3(0.5f, -0.5f, 0.5f), //Right Right Bottom
            new Vector3(0.5f, 0.5f, 0.5f), //Right Right Top
            new Vector3(-0.5f, 0.5f, 0.5f) //Left Left Top
    };

    public static readonly int[,] voxelTris = new int[6, 6]
    {
            {0, 3, 1, 1, 3, 2}, //Front
            {5, 6, 4, 4, 6, 7}, //Back
            {3, 7, 2, 2, 7, 6}, //Top
            {1, 5, 0, 0, 5, 4}, //Bottom
            {4, 7, 0, 0, 7, 3}, //Left
            {1, 2, 5, 5, 2, 6} //Right
    };

    public static readonly Vector2[] voxelUvs = new Vector2[6]
    {
            new Vector2(-0.5f, -0.5f),
            new Vector2(-0.5f, 0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(-0.5f, 0.5f),
            new Vector2(0.5f, 0.5f),
    };

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        boxCollider = GetComponent<BoxCollider>();
        meshFilter.mesh = BlockMeshCreate(out BlockTexture);

        Texture2D texture = ResourceManager.ResourceSearch<Texture2D>(ResourceManager.BlockTexturePath + BlockTextureName);
        if (texture != null)
        {
            List<Texture2D> Texture = new List<Texture2D> { texture, texture, texture, texture, texture, texture };
            meshFilter.mesh = BlockMeshCreate(BlockPos, BlockSize, Texture, out BlockTexture);
            meshFilter.sharedMesh.name = BlockTextureName;
            BlockTexture.name = BlockTextureName;
        }
        else
        {
            DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
            List<Texture2D> Texture = new List<Texture2D> { DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage };
            meshFilter.mesh = BlockMeshCreate(BlockPos, BlockSize, Texture, out BlockTexture);
            meshFilter.sharedMesh.name = DefaultBlockImage.name;
            BlockTexture.name = DefaultBlockImage.name;
        }
    }

    void Update()
    {
        if (!Application.isPlaying && (tempBlockPos != BlockPos || tempBlockSize != BlockSize || tempUVPos != UVPos || tempLeftHidden != LeftHidden || tempFrontHidden != FrontHidden || tempRightHidden != RightHidden || tempBackHidden != BackHidden || tempTopHidden != TopHidden || tempBottomHidden != BottomHidden || tempBlockTextureName != BlockTextureName))
        {
            Texture2D texture = ResourceManager.ResourceSearch<Texture2D>(ResourceManager.BlockTexturePath + BlockTextureName);
            if (texture != null)
            {
                List<Texture2D> Texture = new List<Texture2D> { texture, texture, texture, texture, texture, texture };
                meshFilter.mesh = BlockMeshCreate(BlockPos, BlockSize, Texture, out BlockTexture);
                meshFilter.sharedMesh.name = BlockTextureName;
                BlockTexture.name = BlockTextureName;
            }
            else
            {
                DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
                List<Texture2D> Texture = new List<Texture2D> { DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage };
                meshFilter.mesh = BlockMeshCreate(BlockPos, BlockSize, Texture, out BlockTexture);
                meshFilter.sharedMesh.name = DefaultBlockImage.name;
                BlockTexture.name = DefaultBlockImage.name;
            }

            tempBlockPos = BlockPos;
            tempBlockSize = BlockSize;
            tempUVPos = UVPos;
            tempLeftHidden = LeftHidden;
            tempFrontHidden = FrontHidden;
            tempRightHidden = RightHidden;
            tempBackHidden = BackHidden;
            tempTopHidden = TopHidden;
            tempBottomHidden = BottomHidden;
            tempBlockTextureName = BlockTextureName;
        }
    }

    public static Texture2D GetBlockTextures(List<Texture2D> BlockTexture, out Vector2[] Uvs)
    {
        Texture2D background = new Texture2D(48, 96);
        RectTemp = background.PackTextures(BlockTexture.ToArray(), 0, 8192);
        background.filterMode = FilterMode.Point;
        background.filterMode = FilterMode.Point;
        UVTemp.Clear();

        //for (int i = 0; i < BlockTexture.Count; i++)
        //Debug.Log("BlockTexture " + BlockTexture[i]);

        for (int i = 0; i < 6; i++)
        {
            UVTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y));
            UVTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y + RectTemp[i].height));
            UVTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y));
            UVTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y));
            UVTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y + RectTemp[i].height));
            UVTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y + RectTemp[i].height));
            //Debug.Log("RectTemp " + RectTemp[i]);
        }

        //for (int i = 0; i < 6 * 6; i++)
        //Debug.Log("UvsTemp " + UvsTemp[i]);

        Uvs = UVTemp.ToArray();

        return background;
    }

    public Mesh BlockMeshCreate(List<Texture2D> texture2D, out Texture2D MaterialBlockTexture)
    {
        return blockMeshCreate(Vector3.zero, Vector3.one, texture2D, out MaterialBlockTexture);
    }

    public Mesh BlockMeshCreate(out Texture2D MaterialBlockTexture)
    {
        DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
        defaultBlockImage = new List<Texture2D>() { DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage };

        return blockMeshCreate(Vector3.zero, Vector3.one, defaultBlockImage, out MaterialBlockTexture);
    }

    public Mesh BlockMeshCreate(Vector3 BlockPos, Vector3 BlockSize, List<Texture2D> texture2D, out Texture2D MaterialBlockTexture)
    {
        return blockMeshCreate(BlockPos, BlockSize, texture2D, out MaterialBlockTexture);
    }

    public Mesh BlockMeshCreate(Vector3 BlockPos, Vector3 BlockSize, out Texture2D MaterialBlockTexture)
    {
        DefaultBlockImage = Resources.Load<Texture2D>("Default Block Image");
        defaultBlockImage = new List<Texture2D>() { DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage, DefaultBlockImage };

        return blockMeshCreate(BlockPos, BlockSize, defaultBlockImage, out MaterialBlockTexture);
    }

    Mesh blockMeshCreate(Vector3 BlockPos, Vector3 BlockSize, List<Texture2D> BlockTexture, out Texture2D MaterialBlockTexture)
    {
        Vertices.Clear();

        int vertexIndex = 0;

        for (int p = 0; p < 6; p++)
        {
            for (int i = 0; i < 6; i++)
            {
                int triangleIndex = voxelTris[p, i];
                Vertices.Add(voxelVerts[triangleIndex]);
                Triangles.Add(vertexIndex);

                vertexIndex++;
            }
        }

        MaterialBlockTexture = GetBlockTextures(BlockTexture, out UV);

        //boxCollider.enabled = false;
        int ii = 0;
        /*bool Front = Physics.BoxCast(transform.position - (-transform.forward * 0.01f) + BlockPos, BlockSize, -transform.forward, transform.rotation, 0.2f, LayerMask.GetMask("Block"));
        bool Back = Physics.BoxCast(transform.position - (transform.forward * 0.01f) + BlockPos, BlockSize, transform.forward, transform.rotation, 0.1f, LayerMask.GetMask("Block"));

        bool Up = Physics.BoxCast(transform.position - (transform.up * 0.01f) + BlockPos, BlockSize, transform.up, transform.rotation, 0.1f, LayerMask.GetMask("Block"));
        bool Down = Physics.BoxCast(transform.position - (-transform.up * 0.01f) + BlockPos, BlockSize, -transform.up, transform.rotation, 0.2f, LayerMask.GetMask("Block"));

        bool Left = Physics.BoxCast(transform.position - (-transform.right * 0.01f) + BlockPos, BlockSize, -transform.right, transform.rotation, 0.2f, LayerMask.GetMask("Block"));
        bool Right = Physics.BoxCast(transform.position - (transform.right * 0.01f) + BlockPos, BlockSize, transform.right, transform.rotation, 0.1f, LayerMask.GetMask("Block"));*/

        for (int p = 0; p < 6; p++)
        {
            for (int i = 0; i < 6; i++)
            {
                Vertices[ii] = new Vector3(Vertices[ii].x * BlockSize.x, Vertices[ii].y * BlockSize.y, Vertices[ii].z * BlockSize.z);
                if (p == 0 || p == 1)
                    UV[ii] = new Vector2(UV[ii].x * BlockSize.x, UV[ii].y * BlockSize.y);
                else if (p == 2 || p == 3)
                    UV[ii] = new Vector2(UV[ii].x * BlockSize.x, UV[ii].y * BlockSize.z);
                else if (p == 4 || p == 5)
                    UV[ii] = new Vector2(UV[ii].x * BlockSize.z, UV[ii].y * BlockSize.y);

                Vertices[ii] += BlockPos;
                UV[ii] += UVPos;

                if (p == 0 && FrontHidden)
                    Vertices[ii] = new Vector2(0, 0);
                if (p == 1 && BackHidden)
                    Vertices[ii] = new Vector2(0, 0);
                if (p == 2 && TopHidden)
                    Vertices[ii] = new Vector2(0, 0);
                if (p == 3 && BottomHidden)
                    Vertices[ii] = new Vector2(0, 0);
                if (p == 4 && LeftHidden)
                    Vertices[ii] = new Vector2(0, 0);
                if (p == 5 && RightHidden)
                    Vertices[ii] = new Vector2(0, 0);

                ii++;
            }
        }
        //boxCollider.enabled = true;

        Mesh mesh = new Mesh
        {
            name = "Block Mesh",
            vertices = Vertices.ToArray(),
            triangles = Triangles.ToArray(),
            uv = UV
        };

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }
}
