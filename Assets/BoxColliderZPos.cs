using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderZPos : MonoBehaviour
{
    void Start() => BlockReload();

    public void BlockReload()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        if (transform.position.z != 0)
            boxCollider2D.enabled = false;
    }

}
