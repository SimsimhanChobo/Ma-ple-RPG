using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSignShowObject : MonoBehaviour
{
    void Update()
    {
        SignTextureChange signTextureChange = transform.parent.GetComponent<SignTextureChange>();
        SignTextureChange signTextureChange2 = GetComponent<SignTextureChange>();

        signTextureChange2.Texture = signTextureChange.Texture;
    }
}
