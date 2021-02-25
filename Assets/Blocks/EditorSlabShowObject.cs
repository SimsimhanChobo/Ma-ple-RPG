using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSlabShowObject : MonoBehaviour
{
    void Update()
    {
        SlabTextureChange slabTextureChange = transform.parent.GetComponent<SlabTextureChange>();
        SlabTextureChange slabTextureChange2 = GetComponent<SlabTextureChange>();

        slabTextureChange2.Texture = slabTextureChange.Texture;
        slabTextureChange2.Top = slabTextureChange.Top;
        slabTextureChange2.Left = slabTextureChange.Left;
        slabTextureChange2.Right = slabTextureChange.Right;
        slabTextureChange2.Bottom = slabTextureChange.Bottom;
    }
}
