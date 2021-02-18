using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderZPos : MonoBehaviour
{
    void Awake() => BlockReload();

    public void BlockReload()
    {
        BoxCollider2D[] boxCollider2D = GetComponents<BoxCollider2D>();
        if (transform.position.z != 0)
            for (int i = 0; i < boxCollider2D.Length; i++)
                boxCollider2D[i].enabled = false;
    }

}
