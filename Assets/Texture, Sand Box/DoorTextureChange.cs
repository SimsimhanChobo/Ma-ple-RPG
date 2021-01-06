using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class DoorTextureChange : MonoBehaviour
{
    public bool DoorTextureAutoChange = true;

    public Texture2D Top;
    public Texture2D Bottom;

    public bool Sprite;

    Texture2D TopTemp = null;
    Texture2D BottomTemp = null;

    public void TextureReload(bool Reload)
    {
        if (Sprite || (!Sprite && !GamePlay.EditorPlay))
            if (DoorTextureAutoChange && !Reload && ((Top != TopTemp && Top != null) || (Bottom != BottomTemp && Bottom != null)))
            {
                if (Top.width == 16 && Top.height == 16 && Top != TopTemp)
                {
                    SkinChange("Top", 0, 0, 16, 16);
                    SkinChange("Top Left", 13, 0, 3, 16);
                    SkinChange("Top Right", 0, 0, 3, 16);
                    SkinChange("Back Top", 0, 0, 16, 16);
                }
                else if (Bottom.width == 16 && Bottom.height == 16 && Bottom != BottomTemp)
                {
                    SkinChange("Bottom", 0, 0, 16, 16);
                    SkinChange("Top Top", 13, 0, 3, 16);
                    SkinChange("Bottom Bottom", 13, 0, 3, 16);
                    SkinChange("Bottom Left", 13, 0, 3, 16);
                    SkinChange("Bottom Right", 0, 0, 3, 16);
                    SkinChange("Bottom Back", 0, 0, 3, 16);
                }

                TopTemp = Top;
                BottomTemp = Bottom;
            }
            else if (Reload)
            {
                SkinChange("Top", 0, 0, 16, 16);
                SkinChange("Top Left", 13, 0, 3, 16);
                SkinChange("Top Right", 0, 0, 3, 16);
                SkinChange("Back Top", 0, 0, 16, 16);
                SkinChange("Bottom", 0, 0, 16, 16);
                SkinChange("Top Top", 13, 0, 3, 16);
                SkinChange("Bottom Bottom", 13, 0, 3, 16);
                SkinChange("Bottom Left", 13, 0, 3, 16);
                SkinChange("Bottom Right", 0, 0, 3, 16);
                SkinChange("Bottom Back", 0, 0, 3, 16);
            }
    }

    void Start()
    {
        if (Sprite)
            TextureReload(true);
        else if (!Sprite && !GamePlay.EditorPlay)
            TextureReload(true);
    }

    void Update()
    {
        if (GamePlay.EditorPlay)
            TextureReload(false);
    }

    /// <summary>
    /// Auto Skin Change
    /// </summary>
    /// <param name="ObjectName">
    /// Object name to be replaced
    /// </param>
    /// <param name="x">
    /// Pos X
    /// </param>
    /// <param name="y">
    /// Pos Y
    /// </param>
    /// <param name="w">
    /// Size W
    /// </param>
    /// <param name="h">
    /// Size H
    /// </param>
    public void SkinChange(string ObjectName, float x, float y, float w, float h) => skinChange(ObjectName, x, y, w, h, new Vector2(0.5f, 0.5f));

    /// <summary>
    /// Auto Skin Change
    /// </summary>
    /// <param name="ObjectName">
    /// Object name to be replaced
    /// </param>
    /// <param name="x">
    /// Pos X
    /// </param>
    /// <param name="y">
    /// Pos Y
    /// </param>
    /// <param name="w">
    /// Size W
    /// </param>
    /// <param name="h">
    /// Size H
    /// </param>
    /// <param name="Pivot">
    /// Pitvot
    /// </param>
    public void SkinChange(string ObjectName, float x, float y, float w, float h, Vector2 Pivot) => skinChange(ObjectName, x, y, w, h, Pivot);

    void skinChange(string ObjectName, float x, float y, float w, float h, Vector2 Pivot)
    {
        if (Sprite)
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform Object = allChildren[i];
                if (Object.name == ObjectName && (ObjectName == "Top" || ObjectName == "Top Left" || ObjectName == "Top Right" || ObjectName == "Back Top"))
                {
                    SpriteRenderer SpriteRenderer = Object.GetComponent<SpriteRenderer>();

                    Sprite Sprite = Sprite.Create(Top, new Rect(x, y, w, h), Pivot, 16);

                    SpriteRenderer.sprite = Sprite;
                }
                else if (Object.name == ObjectName && (ObjectName == "Bottom" || ObjectName == "Top Top" || ObjectName == "Bottom Bottom" || ObjectName == "Bottom Left" || ObjectName == "Bottom Right" || ObjectName == "Back Bottom"))
                {
                    SpriteRenderer SpriteRenderer = Object.GetComponent<SpriteRenderer>();

                    Sprite Sprite = Sprite.Create(Bottom, new Rect(x, y, w, h), Pivot, 16);

                    SpriteRenderer.sprite = Sprite;
                }
            }
        }
        else
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform Object = allChildren[i];
                if (Object.name == ObjectName && (ObjectName == "Top" || ObjectName == "Top Left" || ObjectName == "Top Right" || ObjectName == "Back Top"))
                {
                    MeshFilter meshFilter = Object.GetComponent<MeshFilter>();
                    MeshRenderer meshRenderer = Object.GetComponent<MeshRenderer>();

                    meshRenderer.material.mainTexture = Top;

                    Vector3[] vertices = new Vector3[] { new Vector3(w / 16 * -0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * -0.5f, 0), new Vector3(w / 16 * -0.5f, h / 16 * -0.5f, 0) };


                    int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

                    Mesh mesh = new Mesh();
                    Vector2[] uvs = new Vector2[] { ConvertPixelsToUVCoordinates(x, y + h, Top.width, Top.height), ConvertPixelsToUVCoordinates(x + w, y + h, Top.width, Top.height), ConvertPixelsToUVCoordinates(x + w, y, Top.width, Top.height), ConvertPixelsToUVCoordinates(x, y, Top.width, Top.height) };

                    mesh.vertices = vertices;
                    mesh.triangles = triangles;
                    mesh.uv = uvs;
                    mesh.RecalculateBounds();
                    mesh.RecalculateNormals();
                    mesh.Optimize();

                    meshFilter.mesh = mesh;

                    return;
                }
                else if (Object.name == ObjectName && (ObjectName == "Bottom" || ObjectName == "Top Top" || ObjectName == "Bottom Bottom" || ObjectName == "Bottom Left" || ObjectName == "Bottom Right" || ObjectName == "Back Bottom"))
                {
                    MeshFilter meshFilter = Object.GetComponent<MeshFilter>();
                    MeshRenderer meshRenderer = Object.GetComponent<MeshRenderer>();

                    meshRenderer.material.mainTexture = Bottom;

                    Vector3[] vertices = new Vector3[] { new Vector3(w / 8 * -0.25f, h / 8 * 0.25f, 0), new Vector3(w / 8 * 0.25f, h / 8 * 0.25f, 0), new Vector3(w / 8 * 0.25f, h / 8 * -0.25f, 0), new Vector3(w / 8 * -0.25f, h / 8 * -0.25f, 0) };


                    int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

                    Mesh mesh = new Mesh();
                    Vector2[] uvs = new Vector2[] { ConvertPixelsToUVCoordinates(x, y + h, Bottom.width, Bottom.height), ConvertPixelsToUVCoordinates(x + w, y + h, Bottom.width, Bottom.height), ConvertPixelsToUVCoordinates(x + w, y, Bottom.width, Bottom.height), ConvertPixelsToUVCoordinates(x, y, Bottom.width, Bottom.height) };

                    mesh.vertices = vertices;
                    mesh.triangles = triangles;
                    mesh.uv = uvs;
                    mesh.RecalculateBounds();
                    mesh.RecalculateNormals();
                    mesh.Optimize();

                    meshFilter.mesh = mesh;

                    return;
                }
            }
        }
    }

    Vector2 ConvertPixelsToUVCoordinates(float x, float y, float textureWidth, float textureHeight)
    {
        return new Vector2(x / textureWidth, y / textureHeight);
    }
}
