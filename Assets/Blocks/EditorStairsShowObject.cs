using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorStairsShowObject : MonoBehaviour
{
    void Update()
    {
        StairsTextureChange stairsTextureChange = transform.parent.GetComponent<StairsTextureChange>();
        StairsTextureChange stairsTextureChange2 = GetComponent<StairsTextureChange>();

        stairsTextureChange2.Texture = stairsTextureChange.Texture;
        stairsTextureChange2.TopLeft = stairsTextureChange.TopLeft;
        stairsTextureChange2.TopRight = stairsTextureChange.TopRight;
        stairsTextureChange2.BottomLeft = stairsTextureChange.BottomLeft;
        stairsTextureChange2.BottomRight = stairsTextureChange.BottomRight;
    }
}
