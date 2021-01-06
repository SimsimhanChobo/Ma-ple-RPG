using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorPlayerShowObject : MonoBehaviour
{
    void Update()
    {
        PlayerSkinChange playerSkinChange = transform.parent.GetComponent<PlayerSkinChange>();
        PlayerSkinChange playerSkinChange2 = GetComponent<PlayerSkinChange>();

        playerSkinChange2.Skin = playerSkinChange.Skin;
    }
}
