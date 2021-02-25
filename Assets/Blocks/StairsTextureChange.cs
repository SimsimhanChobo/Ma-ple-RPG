using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class StairsTextureChange : MonoBehaviour
{
    public bool StairsTextureAutoChange = true;

    public Texture2D Texture;

    public bool TopLeft = false;
    public bool TopRight = true;
    public bool BottomLeft = false;
    public bool BottomRight = false;

    [Space(20), HideInInspector]
    public Material MapMaterial;
    [HideInInspector]
    public Material MapXYPlipMaterial;

    bool TopLeftTemp = false;
    bool TopRightTemp = true;
    bool BottomLeftTemp = false;
    bool BottomRightTemp = false;

    Texture2D TextureTemp = null;

    public void TextureReload(bool Reload)
    {
        if (StairsTextureAutoChange && !Reload && ((Texture != TextureTemp && Texture != null) || TopLeft != TopLeftTemp || TopRight != TopRightTemp || BottomLeft != BottomLeftTemp || BottomRight != BottomRightTemp))
        {
            if (TopLeft)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapMaterial;

                        break;
                    }
                }
            }
            else if (TopRight)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapMaterial;

                        break;
                    }
                }
            }
            else if (BottomLeft)
            {
                transform.localEulerAngles = new Vector3(0, 0, 180);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapXYPlipMaterial;

                        break;
                    }
                }
            }
            else if (BottomRight)
            {
                transform.localEulerAngles = new Vector3(0, 180, 180);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapXYPlipMaterial;

                        break;
                    }
                }
            }

            if (Texture.width == 16 && Texture.height == 16 && TopLeft == TopLeftTemp && TopRight == TopRightTemp && BottomLeft == BottomLeftTemp && BottomRight == BottomRightTemp)
            {
                SkinChange("Left", 0, 0, 16, 16);
                SkinChange("Front", 0, 0, 16, 8);
                SkinChange("Front 2", 0, 8, 8, 8);
                SkinChange("Right", 0, 0, 16, 8);
                SkinChange("Right 2", 0, 8, 16, 8);
                SkinChange("Back", 0, 0, 16, 8);
                SkinChange("Back 2", 8, 8, 8, 8);
                SkinChange("Top", 0, 0, 8, 16);
                SkinChange("Top 2", 8, 0, 8, 16);
                SkinChange("Bottom", 0, 0, 16, 16);
            }

            TextureTemp = Texture;

            TopLeftTemp = TopLeft;
            TopRightTemp = TopRight;
            BottomLeftTemp = BottomLeft;
            BottomRightTemp = BottomRight;
        }
        else if (Reload)
        {
            TextureTemp = Texture;

            if (TopLeft)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapMaterial;

                        break;
                    }
                }
            }
            else if (TopRight)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapMaterial;

                        break;
                    }
                }
            }
            else if (BottomLeft)
            {
                transform.localEulerAngles = new Vector3(0, 0, 180);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapXYPlipMaterial;

                        break;
                    }
                }
            }
            else if (BottomRight)
            {
                transform.localEulerAngles = new Vector3(0, 180, 180);
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform Object = allChildren[i];
                    if (Object.name != gameObject.name)
                    {
                        MeshRenderer MeshRenderer = Object.GetComponent<MeshRenderer>();

                        MeshRenderer.sharedMaterial = MapXYPlipMaterial;

                        break;
                    }
                }
            }

            SkinChange("Left", 0, 0, 16, 16);
            SkinChange("Front", 0, 0, 16, 8);
            SkinChange("Front 2", 0, 8, 8, 8);
            SkinChange("Right", 0, 0, 16, 8);
            SkinChange("Right 2", 0, 8, 16, 8);
            SkinChange("Back", 0, 0, 16, 8);
            SkinChange("Back 2", 8, 8, 8, 8);
            SkinChange("Top", 0, 0, 8, 16);
            SkinChange("Top 2", 8, 0, 8, 16);
            SkinChange("Bottom", 0, 0, 16, 16);

            TopLeftTemp = TopLeft;
            TopRightTemp = TopRight;
            BottomLeftTemp = BottomLeft;
            BottomRightTemp = BottomRight;
        }
    }

    void Start() => TextureReload(false);

    void Update()
    {
        if (!Application.isPlaying)
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
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            Transform Object = allChildren[i];
            if (Object.name == ObjectName)
            {
                MeshFilter meshFilter = Object.GetComponent<MeshFilter>();
                MeshRenderer meshRenderer = Object.GetComponent<MeshRenderer>();

                meshRenderer.sharedMaterial = new Material(Resources.Load<Material>("Map Material"));
                meshRenderer.sharedMaterial.mainTexture = Texture;

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

    Vector2 ConvertPixelsToUVCoordinates(float x, float y, float textureWidth, float textureHeight)
    {
        return new Vector2(x / textureWidth, y / textureHeight);
    }
}
