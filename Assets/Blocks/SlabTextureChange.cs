using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class SlabTextureChange : MonoBehaviour
{
    public bool SlabTextureAutoChange = true;

    public Texture2D Texture;

    public bool Top = false;
    public bool Bottom = false;
    public bool Left = false;
    public bool Right = false;

    public bool Sprite = false;

    bool TopTemp = false;
    bool BottomTemp = false;
    bool LeftTemp = false;
    bool RightTemp = false;

    Texture2D TextureTemp = null;

    public void TextureReload(bool Reload)
    {
        if (Sprite || (!Sprite && !GamePlay.EditorPlay))
            if (SlabTextureAutoChange && !Reload && ((Texture != TextureTemp && Texture != null) || Top != TopTemp || Bottom != BottomTemp || Left != LeftTemp || Right != RightTemp))
            {
                if (Texture.width == 16 && Texture.height == 16)
                {
                    if (Top != TopTemp)
                    {
                        Top = true;
                        Bottom = false;
                        Left = false;
                        Right = false;
                    }
                    else if (Bottom != BottomTemp)
                    {
                        Top = false;
                        Bottom = true;
                        Left = false;
                        Right = false;
                    }
                    else if (Left != LeftTemp)
                    {
                        Top = false;
                        Bottom = false;
                        Left = true;
                        Right = false;
                    }
                    else if (Right != RightTemp)
                    {
                        Top = false;
                        Bottom = false;
                        Left = false;
                        Right = true;
                    }

                    if (Top)
                    {
                        SkinChange("Left", 0, 8, 16, 8);
                        SkinChange("Front", 0, 8, 16, 8);
                        SkinChange("Right", 0, 8, 16, 8);
                        SkinChange("Back", 0, 8, 16, 8);
                        SkinChange("Top", 0, 0, 16, 16);
                        SkinChange("Bottom", 0, 0, 16, 16);

                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(-0.5f, 0, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(0.5f, 0, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                            else if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 0.25f, 0);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, -0.25f, 0);
                        }

                        transform.localPosition = new Vector3(0, 0.25f, 0);
                    }
                    else if (Bottom)
                    {
                        SkinChange("Left", 0, 0, 16, 8);
                        SkinChange("Front", 0, 0, 16, 8);
                        SkinChange("Right", 0, 0, 16, 8);
                        SkinChange("Back", 0, 8, 16, 8);
                        SkinChange("Top", 0, 0, 16, 16);
                        SkinChange("Bottom", 0, 0, 16, 16);

                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(-0.5f, 0, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(0.5f, 0, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                            else if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 0.25f, 0);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, -0.25f, 0);
                        }

                        transform.localPosition = new Vector3(0, -0.25f, 0);
                    }
                    else if (Left)
                    {
                        SkinChange("Left", 0, 0, 16, 16);
                        SkinChange("Front", 0, 0, 8, 16);
                        SkinChange("Right", 0, 0, 16, 16);
                        SkinChange("Back", 0, 0, 8, 16);
                        SkinChange("Top", 0, 0, 8, 16);
                        SkinChange("Bottom", 0, 0, 8, 16);

                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(-0.25f, 0, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(0.25f, 0, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                            else if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 0.5f, 0);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, -0.5f, 0);
                        }

                        transform.localPosition = new Vector3(-0.25f, 0, 0);
                    }
                    else if (Right)
                    {
                        SkinChange("Left", 0, 0, 16, 16);
                        SkinChange("Front", 8, 0, 8, 16);
                        SkinChange("Right", 0, 0, 16, 16);
                        SkinChange("Back", 8, 0, 8, 16);
                        SkinChange("Top", 8, 0, 8, 16);
                        SkinChange("Bottom", 8, 0, 8, 16);

                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(-0.25f, 0, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(0.25f, 0, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                            else if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 0.5f, 0);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, -0.5f, 0);
                        }

                        transform.localPosition = new Vector3(0.25f, 0, 0);
                    }
                }

                TextureTemp = Texture;

                TopTemp = Top;
                BottomTemp = Bottom;
                LeftTemp = Left;
                RightTemp = Right;
            }
            else if (Reload)
            {
                if (Top)
                {
                    SkinChange("Left", 0, 8, 16, 8);
                    SkinChange("Front", 0, 8, 16, 8);
                    SkinChange("Right", 0, 8, 16, 8);
                    SkinChange("Back", 0, 8, 16, 8);
                    SkinChange("Top", 0, 0, 16, 16);
                    SkinChange("Bottom", 0, 0, 16, 16);

                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(-0.5f, 0, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(0.5f, 0, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                        else if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 0.25f, 0);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, -0.25f, 0);
                    }

                    transform.localPosition = new Vector3(0, 0.25f, 0);
                }
                else if (Bottom)
                {
                    SkinChange("Left", 0, 0, 16, 8);
                    SkinChange("Front", 0, 0, 16, 8);
                    SkinChange("Right", 0, 0, 16, 8);
                    SkinChange("Back", 0, 8, 16, 8);
                    SkinChange("Top", 0, 0, 16, 16);
                    SkinChange("Bottom", 0, 0, 16, 16);

                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(-0.5f, 0, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(0.5f, 0, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                        else if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 0.25f, 0);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, -0.25f, 0);
                    }

                    transform.localPosition = new Vector3(0, -0.25f, 0);
                }
                else if (Left)
                {
                    SkinChange("Left", 0, 0, 16, 16);
                    SkinChange("Front", 0, 0, 8, 16);
                    SkinChange("Right", 0, 0, 16, 16);
                    SkinChange("Back", 0, 0, 8, 16);
                    SkinChange("Top", 0, 0, 8, 16);
                    SkinChange("Bottom", 0, 0, 8, 16);

                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(-0.25f, 0, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(0.25f, 0, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                        else if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 0.5f, 0);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, -0.5f, 0);
                    }

                    transform.localPosition = new Vector3(-0.25f, 0, 0);
                }
                else if (Right)
                {
                    SkinChange("Left", 0, 0, 16, 16);
                    SkinChange("Front", 8, 0, 8, 16);
                    SkinChange("Right", 0, 0, 16, 16);
                    SkinChange("Back", 8, 0, 8, 16);
                    SkinChange("Top", 8, 0, 8, 16);
                    SkinChange("Bottom", 8, 0, 8, 16);

                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(-0.25f, 0, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0, -0.5f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(0.25f, 0, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0, 0.5f);
                        else if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 0.5f, 0);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, -0.5f, 0);
                    }

                    transform.localPosition = new Vector3(0.25f, 0, 0);
                }
            }

        if (Sprite)
            transform.localPosition = Vector3.zero;
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
        if (GamePlay.EditorPlay && Sprite)
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
                if (Object.name == ObjectName)
                {
                    SpriteRenderer SpriteRenderer = Object.GetComponent<SpriteRenderer>();

                    Sprite Sprite = Sprite.Create(Texture, new Rect(x, y, w, h), Pivot, 16);

                    SpriteRenderer.sprite = Sprite;

                    return;
                }
            }
        }
        else
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform Object = allChildren[i];
                if (Object.name == ObjectName)
                {
                    MeshFilter meshFilter = Object.GetComponent<MeshFilter>();
                    MeshRenderer meshRenderer = Object.GetComponent<MeshRenderer>();

                    meshRenderer.material.mainTexture = Texture;

                    Vector3[] vertices = new Vector3[] { new Vector3(w / 16 * -0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * -0.5f, 0), new Vector3(w / 16 * -0.5f, h / 16 * -0.5f, 0) };


                    int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

                    Mesh mesh = new Mesh();
                    Vector2[] uvs = new Vector2[] { ConvertPixelsToUVCoordinates(x, y + h, Texture.width, Texture.height), ConvertPixelsToUVCoordinates(x + w, y + h, Texture.width, Texture.height), ConvertPixelsToUVCoordinates(x + w, y, Texture.width, Texture.height), ConvertPixelsToUVCoordinates(x, y, Texture.width, Texture.height) };

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
