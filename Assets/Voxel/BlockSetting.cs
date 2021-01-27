using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSetting : MonoBehaviour
{
    public BlockType blockType;

    BlockType blockTypeTemp;

    public Texture2D Texture;

    public Texture2D SideTop;
    public Texture2D SideBottom;
    public Texture2D Side;

    public Texture2D Side2Top;
    public Texture2D Side2Bottom;
    public Texture2D Side2Front;
    public Texture2D Side2;

    public Texture2D Side3Top;
    public Texture2D Side3Bottom;
    public Texture2D Side3Front;
    public Texture2D Side3Back;
    public Texture2D Side3;

    public Texture2D _Left;
    public Texture2D _Front;
    public Texture2D _Right;
    public Texture2D _Back;
    public Texture2D _Top;
    public Texture2D _Bottom;

    public Texture2D Left;
    public Texture2D Front;
    public Texture2D Right;
    public Texture2D Back;
    public Texture2D Top;
    public Texture2D Bottom;

    Texture2D LeftTemp;
    Texture2D FrontTemp;
    Texture2D RightTemp;
    Texture2D BackTemp;
    Texture2D TopTemp;
    Texture2D BottomTemp;

    readonly List<Texture2D> BlockTexture = new List<Texture2D>();

    public static bool TextureReload;

    Material material;
    MeshFilter meshFilter;

    readonly List<Vector3> vertices = new List<Vector3>();
    readonly List<int> triangles = new List<int>();
    Vector2[] uvs;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        meshFilter = GetComponent<MeshFilter>();

        StartCoroutine(BlockRefresh(false));
    }

    [ContextMenu("Block Refresh")]
    public IEnumerator BlockRefresh(bool Reload)
    {
        yield return new WaitUntil(() => Vector2.Distance(transform.position, MainCamera.Camera.transform.position) <= 25);

        if (!Reload)
        {
            if (blockType == BlockType.Normal && Texture != null)
            {
                Left = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
                Front = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
                Right = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
                Back = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
                Top = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
                Bottom = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Texture.name);
            }
            else if (blockType == BlockType.SideTopBottom)
            {
                if (Side != null)
                {
                    Left = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side.name);
                    Front = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side.name);
                    Right = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side.name);
                    Back = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side.name);
                }
                if (SideTop != null)
                    Top = ResourceManager.ResourceLoad("Minecraft Block Texture/" + SideTop.name);
                if (SideBottom != null)
                    Bottom = ResourceManager.ResourceLoad("Minecraft Block Texture/" + SideBottom.name);
            }
            else if (blockType == BlockType.SideTopBottomFront)
            {
                if (Side2 != null)
                    Left = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2.name);
                if (Side2Front != null)
                    Front = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2Front.name);
                if (Side2 != null)
                {
                    Right = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2.name);
                    Back = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2.name);
                }
                if (Side2Top != null)
                    Top = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2Top.name);
                if (Side2Bottom != null)
                    Bottom = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side2Bottom.name);
            }
            else if (blockType == BlockType.SideTopBottomFrontBack)
            {
                if (Side3 != null)
                    Left = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3.name);
                if (Side3Front != null)
                    Front = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3Front.name);
                if (Side3 != null)
                    Right = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3.name);
                if (Side3Back != null)
                    Back = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3Back.name);
                if (Side3Top != null)
                    Top = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3Top.name);
                if (Side3Bottom != null)
                    Bottom = ResourceManager.ResourceLoad("Minecraft Block Texture/" + Side3Bottom.name);
            }
            else if (blockType == BlockType.MultipleTextures)
            {
                if (_Left != null)
                    Left = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Left.name);
                if (_Front != null)
                    Front = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Front.name);
                if (_Right != null)
                    Right = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Right.name);
                if (_Back != null)
                    Back = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Back.name);
                if (_Top != null)
                    Top = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Top.name);
                if (_Bottom != null)
                    Bottom = ResourceManager.ResourceLoad("Minecraft Block Texture/" + _Bottom.name);
            }
        }

        if (Left != LeftTemp || Front != FrontTemp || Right != RightTemp || Back != BackTemp || Top != TopTemp || Bottom != BottomTemp)
        {
            if (Left != null && Front != null && Right != null && Back != null && Top != null && Bottom != null)
                if (Left.width != 16 && Left.height != 16 && Front.width != 16 && Front.height != 16 && Right.width != 16 && Right.height != 16 && Back.width != 16 && Back.height != 16 && Top.width != 16 && Top.height != 16 && Bottom.width != 16 && Bottom.height != 16)
                    yield return null;

            blockTypeTemp = blockType;

            LeftTemp = Left;
            FrontTemp = Front;
            RightTemp = Right;
            BackTemp = Back;
            TopTemp = Top;
            BottomTemp = Bottom;

            BlockTexture.Clear();
            vertices.Clear();
            triangles.Clear();

            if (Front != null)
                BlockTexture.Add(Front);
            else
                BlockTexture.Add(ResourceManager.Null);
            if (Back != null)
                BlockTexture.Add(Back);
            else
                BlockTexture.Add(ResourceManager.Null);
            if (Top != null)
                BlockTexture.Add(Top);
            else
                BlockTexture.Add(ResourceManager.Null);
            if (Bottom != null)
                BlockTexture.Add(Bottom);
            else
                BlockTexture.Add(ResourceManager.Null);
            if (Left != null)
                BlockTexture.Add(Left);
            else
                BlockTexture.Add(ResourceManager.Null);
            if (Right != null)
                BlockTexture.Add(Right);
            else
                BlockTexture.Add(ResourceManager.Null);


            material.mainTexture = ResourceManager.GetBlockTextures(BlockTexture, out uvs);
            material.mainTexture.filterMode = FilterMode.Point;

            int vertexIndex = 0;

            for (int p = 0; p < 6; p++)
            {
                for (int i = 0; i < 6; i++)
                {
                    int triangleIndex = VoxelData.voxelTris[p, i];
                    vertices.Add(VoxelData.voxelVerts[triangleIndex]);
                    triangles.Add(vertexIndex);

                    vertexIndex++;
                }
            }

            Mesh mesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray(),
                uv = uvs
            };

            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
        }
    }
}

public enum BlockType
{
    Normal,
    SideTopBottom,
    SideTopBottomFront,
    SideTopBottomFrontBack,
    MultipleTextures
}
