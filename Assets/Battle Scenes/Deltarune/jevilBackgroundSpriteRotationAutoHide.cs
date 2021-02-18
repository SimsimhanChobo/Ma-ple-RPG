using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class jevilBackgroundSpriteRotationAutoHide : MonoBehaviour
{
    public bool Top = false;

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Top)
        {
            if (transform.eulerAngles.y > 87 && transform.eulerAngles.y < 274)
                spriteRenderer.color = new Color(1, 1, 1, 0);
            else
                spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else
        {
            if (transform.eulerAngles.y > 105 && transform.eulerAngles.y < 255)
                spriteRenderer.color = new Color(1, 1, 1, 0);
            else
                spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
