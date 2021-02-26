using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), ExecuteInEditMode]
public class BlockRenderer : MonoBehaviour
{
    BlockMeshFilter blockMeshFilter;
    MeshRenderer meshRenderer;

    [HideInInspector]
    public Material BlockMaterial;

    public Color color = Color.white;

    void Awake()
    {
        blockMeshFilter = GetComponent<BlockMeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        meshRenderer.material = new Material(BlockMaterial);

        if (blockMeshFilter != null)
        {
            meshRenderer.sharedMaterial.mainTexture = blockMeshFilter.BlockTexture;
            meshRenderer.sharedMaterial.color = color;
        }
        else
            blockMeshFilter = GetComponent<BlockMeshFilter>();
    }

    void LateUpdate()
    {
        if (!Application.isPlaying)
        {
            if (blockMeshFilter != null)
            {
                meshRenderer.sharedMaterial.mainTexture = blockMeshFilter.BlockTexture;
                meshRenderer.sharedMaterial.color = color;
            }
            else
                blockMeshFilter = GetComponent<BlockMeshFilter>();
        }
    }
}
