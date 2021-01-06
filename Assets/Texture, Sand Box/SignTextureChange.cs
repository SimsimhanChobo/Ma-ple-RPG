using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class SignTextureChange : MonoBehaviour
{
    public bool SignTextureAutoChange = true;
    public bool Wall = false;

    public Texture2D Texture = null;

    public bool Sprite = false;

    Texture2D TextureTemp = null;
    bool WallTemp = false;

    public void TextureReload(bool Reload)
    {
        if (Sprite || (!Sprite && !GamePlay.EditorPlay))
            if (Texture != null && SignTextureAutoChange && !Reload && (Texture != TextureTemp || Wall != WallTemp))
            {
                //Texture = ResourceManager.ResourceLoad("Minecraft Sign Texture/" + Texture.name);

                if (Texture.width == 64 && Texture.height == 32 && !Wall)
                {
                    if (Wall != WallTemp)
                    {
                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 1.083333f, 0);
                            else if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(0.5f, 0.8333333f, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0.8333333f, -0.041665f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(-0.5f, 0.8333333f, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0.8333333f, 0.041665f);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, 0.58334f, 0);
                        }
                    }

                    SkinChange("Top", 2, 30, 24, 2);
                    SkinChange("Bottom", 26, 30, 24, 2);
                    SkinChange("Left", 26, 18, 2, 12);
                    SkinChange("Right", 0, 18, 2, 12);
                    SkinChange("Front", 2, 18, 24, 12);
                    SkinChange("Back", 28, 18, 24, 12);
                    SkinChange("Bottom Top", 2, 16, 2, 2);
                    SkinChange("Bottom Bottom", 4, 16, 2, 2);
                    SkinChange("Bottom Left", 4, 2, 2, 14);
                    SkinChange("Bottom Front", 2, 2, 2, 14);
                    SkinChange("Bottom Right", 0, 2, 2, 14);
                    SkinChange("Bottom Back", 6, 2, 2, 14);
                }
                else if (Texture.width == 64 && Texture.height == 32 && Wall)
                {
                    if (Wall != WallTemp)
                    {
                        Transform[] allChildren = GetComponentsInChildren<Transform>();
                        for (int i = 0; i < allChildren.Length; i++)
                        {
                            Transform Object = allChildren[i];
                            if (Object.name == "Top")
                                Object.transform.localPosition = new Vector3(0, 0.75f, 0);
                            else if (Object.name == "Left")
                                Object.transform.localPosition = new Vector3(1.5f, 0.5f, 0);
                            else if (Object.name == "Front")
                                Object.transform.localPosition = new Vector3(0, 0.5f, -0.041665f);
                            else if (Object.name == "Right")
                                Object.transform.localPosition = new Vector3(-0.5f, 0.5f, 0);
                            else if (Object.name == "Back")
                                Object.transform.localPosition = new Vector3(0, 0.5f, 0.041665f);
                            else if (Object.name == "Bottom")
                                Object.transform.localPosition = new Vector3(0, 0.2500067f, 0);
                        }
                    }

                    SkinChange("Top", 2, 30, 24, 2);
                    SkinChange("Bottom", 26, 30, 24, 2);
                    SkinChange("Left", 26, 18, 2, 12);
                    SkinChange("Right", 0, 18, 2, 12);
                    SkinChange("Front", 2, 18, 24, 12);
                    SkinChange("Back", 28, 18, 24, 12);
                    SkinChange("Bottom Top", 0, 0, 0, 0);
                    SkinChange("Bottom Bottom", 0, 0, 0, 0);
                    SkinChange("Bottom Left", 0, 0, 0, 0);
                    SkinChange("Bottom Front", 0, 0, 0, 0);
                    SkinChange("Bottom Right", 0, 0, 0, 0);
                    SkinChange("Bottom Back", 0, 0, 0, 0);
                }

                TextureTemp = Texture;
                WallTemp = Wall;
            }
            else if (Reload)
            {
                if (!Wall)
                {
                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 1.083333f, 0);
                        else if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(0.5f, 0.8333333f, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0.8333333f, -0.041665f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(-0.5f, 0.8333333f, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0.8333333f, 0.041665f);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, 0.58334f, 0);
                    }

                    SkinChange("Top", 2, 30, 24, 2);
                    SkinChange("Bottom", 26, 30, 24, 2);
                    SkinChange("Left", 26, 18, 2, 12);
                    SkinChange("Right", 0, 18, 2, 12);
                    SkinChange("Front", 2, 18, 24, 12);
                    SkinChange("Back", 28, 18, 24, 12);
                    SkinChange("Bottom Top", 2, 16, 2, 2);
                    SkinChange("Bottom Bottom", 4, 16, 2, 2);
                    SkinChange("Bottom Left", 4, 2, 2, 14);
                    SkinChange("Bottom Front", 2, 2, 2, 14);
                    SkinChange("Bottom Right", 0, 2, 2, 14);
                    SkinChange("Bottom Back", 6, 2, 2, 14);
                }
                else if (Wall)
                {
                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform Object = allChildren[i];
                        if (Object.name == "Top")
                            Object.transform.localPosition = new Vector3(0, 0.75f, 0);
                        else if (Object.name == "Left")
                            Object.transform.localPosition = new Vector3(1.5f, 0.5f, 0);
                        else if (Object.name == "Front")
                            Object.transform.localPosition = new Vector3(0, 0.5f, -0.041665f);
                        else if (Object.name == "Right")
                            Object.transform.localPosition = new Vector3(-0.5f, 0.5f, 0);
                        else if (Object.name == "Back")
                            Object.transform.localPosition = new Vector3(0, 0.5f, 0.041665f);
                        else if (Object.name == "Bottom")
                            Object.transform.localPosition = new Vector3(0, 0.2500067f, 0);
                    }

                    SkinChange("Top", 2, 30, 24, 2);
                    SkinChange("Bottom", 26, 30, 24, 2);
                    SkinChange("Left", 26, 18, 2, 12);
                    SkinChange("Right", 0, 18, 2, 12);
                    SkinChange("Front", 2, 18, 24, 12);
                    SkinChange("Back", 28, 18, 24, 12);
                    SkinChange("Bottom Top", 0, 0, 0, 0);
                    SkinChange("Bottom Bottom", 0, 0, 0, 0);
                    SkinChange("Bottom Left", 0, 0, 0, 0);
                    SkinChange("Bottom Front", 0, 0, 0, 0);
                    SkinChange("Bottom Right", 0, 0, 0, 0);
                    SkinChange("Bottom Back", 0, 0, 0, 0);
                }
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
    /// Auto Texture Change
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
    /// Auto Texture Change
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

                    Sprite Sprite = Sprite.Create(Texture, new Rect(x, y, w, h), Pivot, 24);

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

                    Vector3[] vertices = new Vector3[] { new Vector3(w / 24 * -0.5f, h / 24 * 0.5f, 0), new Vector3(w / 24 * 0.5f, h / 24 * 0.5f, 0), new Vector3(w / 24 * 0.5f, h / 24 * -0.5f, 0), new Vector3(w / 24 * -0.5f, h / 24 * -0.5f, 0) };


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
