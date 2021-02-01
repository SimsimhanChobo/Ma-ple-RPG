using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSkinChange : MonoBehaviour
{
    public bool PlayerSkinAutoChange = true;

    public Texture2D Skin;

    public bool Sprite = false;

    Texture2D SkinTemp = null;

    public bool Size64x32 = false;

    [ContextMenu("Skin Reload")]
    public void SkinReload(bool Reload)
    {
        if (Sprite || (!Sprite && !GamePlay.EditorPlay))
            if (Skin != null && PlayerSkinAutoChange && !Reload && Skin != SkinTemp)
            {
                if ((Skin.width == 64 && Skin.height == 32) || (Skin.width == 64 && Skin.height == 64))
                {
                    SkinChange("Head Top", 8, 56, 8, 8);
                    SkinChange("Head Left", 0, 48, 8, 8);
                    SkinChange("Head Front", 8, 48, 8, 8);
                    SkinChange("Head Right", 16, 48, 8, 8);
                    SkinChange("Head Back", 24, 48, 8, 8);
                    SkinChange("Head Bottom", 16, 56, 8, 8);
                    SkinChange("Headwear Top", 40, 56, 8, 8);
                    SkinChange("Headwear Left", 32, 48, 8, 8);
                    SkinChange("Headwear Front", 40, 48, 8, 8);
                    SkinChange("Headwear Right", 48, 48, 8, 8);
                    SkinChange("Headwear Back", 56, 48, 8, 8);
                    SkinChange("Headwear Bottom", 48, 56, 8, 8);

                    SkinChange("Body Top", 20, 44, 8, 4);
                    SkinChange("Body Left", 16, 32, 4, 12);
                    SkinChange("Body Front", 20, 32, 8, 12);
                    SkinChange("Body Right", 28, 32, 4, 12);
                    SkinChange("Body Back", 32, 32, 8, 12);
                    SkinChange("Body Bottom", 28, 44, 8, 4);
                    SkinChange("Bodywear Top", 20, 28, 8, 4);
                    SkinChange("Bodywear Left", 16, 16, 4, 12);
                    SkinChange("Bodywear Front", 20, 16, 8, 12);
                    SkinChange("Bodywear Right", 28, 16, 4, 12);
                    SkinChange("Bodywear Back", 32, 16, 8, 12);
                    SkinChange("Bodywear Bottom", 28, 28, 8, 4);

                    if (!Size64x32)
                    {
                        SkinChange("Left Arm Top", 36, 12, 4, 4);
                        SkinChange("Left Arm Left", 32, 0, 4, 12);
                        SkinChange("Left Arm Front", 36, 0, 4, 12);
                        SkinChange("Left Arm Right", 40, 0, 4, 12);
                        SkinChange("Left Arm Back", 44, 0, 4, 12);
                        SkinChange("Left Arm Bottom", 40, 12, 4, 4);
                        SkinChange("Left Armwear Top", 52, 12, 4, 4);
                        SkinChange("Left Armwear Left", 48, 0, 4, 12);
                        SkinChange("Left Armwear Front", 52, 0, 4, 12);
                        SkinChange("Left Armwear Right", 56, 0, 4, 12);
                        SkinChange("Left Armwear Back", 60, 0, 4, 12);
                        SkinChange("Left Armwear Bottom", 56, 12, 4, 4);

                        SkinChange("Left Leg Top", 20, 12, 4, 4);
                        SkinChange("Left Leg Left", 16, 0, 4, 12);
                        SkinChange("Left Leg Front", 20, 0, 4, 12);
                        SkinChange("Left Leg Right", 24, 0, 4, 12);
                        SkinChange("Left Leg Back", 28, 0, 4, 12);
                        SkinChange("Left Leg Bottom", 24, 12, 4, 4);
                        SkinChange("Left Legwear Top", 4, 12, 4, 4);
                        SkinChange("Left Legwear Left", 0, 0, 4, 12);
                        SkinChange("Left Legwear Front", 4, 0, 4, 12);
                        SkinChange("Left Legwear Right", 8, 0, 4, 12);
                        SkinChange("Left Legwear Back", 12, 0, 4, 12);
                        SkinChange("Left Legwear Bottom", 8, 12, 4, 4);
                    }
                    else
                    {
                        SkinChange("Left Arm Top", 44, 44, 4, 4);
                        SkinChange("Left Arm Left", 40, 32, 4, 12);
                        SkinChange("Left Arm Front", 44, 32, 4, 12);
                        SkinChange("Left Arm Right", 48, 32, 4, 12);
                        SkinChange("Left Arm Back", 52, 32, 4, 12);
                        SkinChange("Left Arm Bottom", 48, 44, 4, 4);
                        SkinChange("Left Armwear Top", 44, 28, 4, 4);
                        SkinChange("Left Armwear Left", 40, 16, 4, 12);
                        SkinChange("Left Armwear Front", 44, 16, 4, 12);
                        SkinChange("Left Armwear Right", 48, 16, 4, 12);
                        SkinChange("Left Armwear Back", 52, 16, 4, 12);
                        SkinChange("Left Armwear Bottom", 48, 28, 4, 4);

                        SkinChange("Left Leg Top", 4, 44, 4, 4);
                        SkinChange("Left Leg Left", 0, 32, 4, 12);
                        SkinChange("Left Leg Front", 4, 32, 4, 12);
                        SkinChange("Left Leg Right", 8, 32, 4, 12);
                        SkinChange("Left Leg Back", 12, 32, 4, 12);
                        SkinChange("Left Leg Bottom", 8, 44, 4, 4);
                        SkinChange("Left Legwear Top", 4, 28, 4, 4);
                        SkinChange("Left Legwear Left", 0, 16, 4, 12);
                        SkinChange("Left Legwear Front", 4, 16, 4, 12);
                        SkinChange("Left Legwear Right", 8, 16, 4, 12);
                        SkinChange("Left Legwear Back", 12, 16, 4, 12);
                        SkinChange("Left Legwear Bottom", 8, 28, 4, 4);
                    }

                    SkinChange("Right Arm Top", 44, 44, 4, 4);
                    SkinChange("Right Arm Left", 40, 32, 4, 12);
                    SkinChange("Right Arm Front", 44, 32, 4, 12);
                    SkinChange("Right Arm Right", 48, 32, 4, 12);
                    SkinChange("Right Arm Back", 52, 32, 4, 12);
                    SkinChange("Right Arm Bottom", 48, 44, 4, 4);
                    SkinChange("Right Armwear Top", 44, 28, 4, 4);
                    SkinChange("Right Armwear Left", 40, 16, 4, 12);
                    SkinChange("Right Armwear Front", 44, 16, 4, 12);
                    SkinChange("Right Armwear Right", 48, 16, 4, 12);
                    SkinChange("Right Armwear Back", 52, 16, 4, 12);
                    SkinChange("Right Armwear Bottom", 48, 28, 4, 4);

                    SkinChange("Right Leg Top", 4, 44, 4, 4);
                    SkinChange("Right Leg Left", 0, 32, 4, 12);
                    SkinChange("Right Leg Front", 4, 32, 4, 12);
                    SkinChange("Right Leg Right", 8, 32, 4, 12);
                    SkinChange("Right Leg Back", 12, 32, 4, 12);
                    SkinChange("Right Leg Bottom", 8, 44, 4, 4);
                    SkinChange("Right Legwear Top", 4, 28, 4, 4);
                    SkinChange("Right Legwear Left", 0, 16, 4, 12);
                    SkinChange("Right Legwear Front", 4, 16, 4, 12);
                    SkinChange("Right Legwear Right", 8, 16, 4, 12);
                    SkinChange("Right Legwear Back", 12, 16, 4, 12);
                    SkinChange("Right Legwear Bottom", 8, 28, 4, 4);
                }

                SkinTemp = Skin;
            }
            else if (Reload)
            {
                SkinChange("Head Top", 8, 56, 8, 8);
                SkinChange("Head Left", 0, 48, 8, 8);
                SkinChange("Head Front", 8, 48, 8, 8);
                SkinChange("Head Right", 16, 48, 8, 8);
                SkinChange("Head Back", 24, 48, 8, 8);
                SkinChange("Head Bottom", 16, 56, 8, 8);
                SkinChange("Headwear Top", 40, 56, 8, 8);
                SkinChange("Headwear Left", 32, 48, 8, 8);
                SkinChange("Headwear Front", 40, 48, 8, 8);
                SkinChange("Headwear Right", 48, 48, 8, 8);
                SkinChange("Headwear Back", 56, 48, 8, 8);
                SkinChange("Headwear Bottom", 48, 56, 8, 8);

                SkinChange("Body Top", 20, 44, 8, 4);
                SkinChange("Body Left", 16, 32, 4, 12);
                SkinChange("Body Front", 20, 32, 8, 12);
                SkinChange("Body Right", 28, 32, 4, 12);
                SkinChange("Body Back", 32, 32, 8, 12);
                SkinChange("Body Bottom", 28, 44, 8, 4);
                SkinChange("Bodywear Top", 20, 28, 8, 4);
                SkinChange("Bodywear Left", 16, 16, 4, 12);
                SkinChange("Bodywear Front", 20, 16, 8, 12);
                SkinChange("Bodywear Right", 28, 16, 4, 12);
                SkinChange("Bodywear Back", 32, 16, 8, 12);
                SkinChange("Bodywear Bottom", 28, 28, 8, 4);

                if (!Size64x32)
                {
                    SkinChange("Left Arm Top", 36, 12, 4, 4);
                    SkinChange("Left Arm Left", 32, 0, 4, 12);
                    SkinChange("Left Arm Front", 36, 0, 4, 12);
                    SkinChange("Left Arm Right", 40, 0, 4, 12);
                    SkinChange("Left Arm Back", 44, 0, 4, 12);
                    SkinChange("Left Arm Bottom", 40, 12, 4, 4);
                    SkinChange("Left Armwear Top", 52, 12, 4, 4);
                    SkinChange("Left Armwear Left", 48, 0, 4, 12);
                    SkinChange("Left Armwear Front", 52, 0, 4, 12);
                    SkinChange("Left Armwear Right", 56, 0, 4, 12);
                    SkinChange("Left Armwear Back", 60, 0, 4, 12);
                    SkinChange("Left Armwear Bottom", 56, 12, 4, 4);

                    SkinChange("Left Leg Top", 20, 12, 4, 4);
                    SkinChange("Left Leg Left", 16, 0, 4, 12);
                    SkinChange("Left Leg Front", 20, 0, 4, 12);
                    SkinChange("Left Leg Right", 24, 0, 4, 12);
                    SkinChange("Left Leg Back", 28, 0, 4, 12);
                    SkinChange("Left Leg Bottom", 24, 12, 4, 4);
                    SkinChange("Left Legwear Top", 4, 12, 4, 4);
                    SkinChange("Left Legwear Left", 0, 0, 4, 12);
                    SkinChange("Left Legwear Front", 4, 0, 4, 12);
                    SkinChange("Left Legwear Right", 8, 0, 4, 12);
                    SkinChange("Left Legwear Back", 12, 0, 4, 12);
                    SkinChange("Left Legwear Bottom", 8, 12, 4, 4);
                }
                else
                {
                    SkinChange("Left Arm Top", 44, 44, 4, 4);
                    SkinChange("Left Arm Left", 40, 32, 4, 12);
                    SkinChange("Left Arm Front", 44, 32, 4, 12);
                    SkinChange("Left Arm Right", 48, 32, 4, 12);
                    SkinChange("Left Arm Back", 52, 32, 4, 12);
                    SkinChange("Left Arm Bottom", 48, 44, 4, 4);
                    SkinChange("Left Armwear Top", 44, 28, 4, 4);
                    SkinChange("Left Armwear Left", 40, 16, 4, 12);
                    SkinChange("Left Armwear Front", 44, 16, 4, 12);
                    SkinChange("Left Armwear Right", 48, 16, 4, 12);
                    SkinChange("Left Armwear Back", 52, 16, 4, 12);
                    SkinChange("Left Armwear Bottom", 48, 28, 4, 4);

                    SkinChange("Left Leg Top", 4, 44, 4, 4);
                    SkinChange("Left Leg Left", 0, 32, 4, 12);
                    SkinChange("Left Leg Front", 4, 32, 4, 12);
                    SkinChange("Left Leg Right", 8, 32, 4, 12);
                    SkinChange("Left Leg Back", 12, 32, 4, 12);
                    SkinChange("Left Leg Bottom", 8, 44, 4, 4);
                    SkinChange("Left Legwear Top", 4, 28, 4, 4);
                    SkinChange("Left Legwear Left", 0, 16, 4, 12);
                    SkinChange("Left Legwear Front", 4, 16, 4, 12);
                    SkinChange("Left Legwear Right", 8, 16, 4, 12);
                    SkinChange("Left Legwear Back", 12, 16, 4, 12);
                    SkinChange("Left Legwear Bottom", 8, 28, 4, 4);
                }

                SkinChange("Right Arm Top", 44, 44, 4, 4);
                SkinChange("Right Arm Left", 40, 32, 4, 12);
                SkinChange("Right Arm Front", 44, 32, 4, 12);
                SkinChange("Right Arm Right", 48, 32, 4, 12);
                SkinChange("Right Arm Back", 52, 32, 4, 12);
                SkinChange("Right Arm Bottom", 48, 44, 4, 4);
                SkinChange("Right Armwear Top", 44, 28, 4, 4);
                SkinChange("Right Armwear Left", 40, 16, 4, 12);
                SkinChange("Right Armwear Front", 44, 16, 4, 12);
                SkinChange("Right Armwear Right", 48, 16, 4, 12);
                SkinChange("Right Armwear Back", 52, 16, 4, 12);
                SkinChange("Right Armwear Bottom", 48, 28, 4, 4);

                SkinChange("Right Leg Top", 4, 44, 4, 4);
                SkinChange("Right Leg Left", 0, 32, 4, 12);
                SkinChange("Right Leg Front", 4, 32, 4, 12);
                SkinChange("Right Leg Right", 8, 32, 4, 12);
                SkinChange("Right Leg Back", 12, 32, 4, 12);
                SkinChange("Right Leg Bottom", 8, 44, 4, 4);
                SkinChange("Right Legwear Top", 4, 28, 4, 4);
                SkinChange("Right Legwear Left", 0, 16, 4, 12);
                SkinChange("Right Legwear Front", 4, 16, 4, 12);
                SkinChange("Right Legwear Right", 8, 16, 4, 12);
                SkinChange("Right Legwear Back", 12, 16, 4, 12);
                SkinChange("Right Legwear Bottom", 8, 28, 4, 4);
            }
    }

    void Start()
    {
        if (Sprite)
            SkinReload(true);
        else if (!Sprite && !GamePlay.EditorPlay)
            SkinReload(true);
    }

    void Update()
    {
        if (GamePlay.EditorPlay && Sprite)
            SkinReload(false);
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

                    Sprite Sprite = Sprite.Create(Skin, new Rect(x, y, w, h), Pivot, 16);

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

                    meshRenderer.material.mainTexture = Skin;

                    Vector3[] vertices = new Vector3[] { new Vector3(w / 16 * -0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * 0.5f, 0), new Vector3(w / 16 * 0.5f, h / 16 * -0.5f, 0), new Vector3(w / 16 * -0.5f, h / 16 * -0.5f, 0) };


                    int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

                    Mesh mesh = new Mesh();
                    Vector2[] uvs = new Vector2[] { ConvertPixelsToUVCoordinates(x, y + h, Skin.width, Skin.height), ConvertPixelsToUVCoordinates(x + w, y + h, Skin.width, Skin.height), ConvertPixelsToUVCoordinates(x + w, y, Skin.width, Skin.height), ConvertPixelsToUVCoordinates(x, y, Skin.width, Skin.height) };

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
