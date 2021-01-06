using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    string PlayerInvItemTemp;

    void Update() =>
        ItemIcon();

    void ItemIcon()
    {
        //아이템 표시
        if (PlayerInvItemTemp != GameManager.PlayerInvItem)
        {
            TextureChange(Resources.Load<Texture2D>("Minecraft Item Texture/" + GameManager.PlayerInvItem));
            PlayerInvItemTemp = GameManager.PlayerInvItem;
        }
    }

    void TextureChange(Texture2D Texture)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (Texture != null)
        {
            meshRenderer.material.mainTexture = Texture;

            Vector3[] vertices = new Vector3[] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) };

            int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

            Mesh mesh = new Mesh();
            Vector2[] uvs = new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) };

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.Optimize();

            meshFilter.mesh = mesh;
        }
        else
            meshFilter.mesh = null;
    }
}
