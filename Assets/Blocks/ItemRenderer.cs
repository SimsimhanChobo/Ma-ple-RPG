using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), ExecuteInEditMode]
public class ItemRenderer : MonoBehaviour
{
    ItemMeshFilter itemMeshFilter;
    MeshRenderer meshRenderer;

    [HideInInspector]
    public Material BlockMaterial;

    public Color color = Color.white;

    void Awake()
    {
        itemMeshFilter = GetComponent<ItemMeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        meshRenderer.sharedMaterial = new Material(Resources.Load<Material>(meshRenderer.sharedMaterial.name));

        if (itemMeshFilter != null)
        {
            meshRenderer.sharedMaterial.mainTexture = itemMeshFilter.ItemTexture;
            meshRenderer.sharedMaterial.color = color;
        }
        else
            itemMeshFilter = GetComponent<ItemMeshFilter>();
    }

    void LateUpdate()
    {
        if (!Application.isPlaying)
        {
            if (itemMeshFilter != null)
            {
                meshRenderer.sharedMaterial.mainTexture = itemMeshFilter.ItemTexture;
                meshRenderer.sharedMaterial.color = color;
            }
            else
                itemMeshFilter = GetComponent<ItemMeshFilter>();
        }
    }
}
