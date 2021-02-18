using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jevilBackgroundSpriteRotation : MonoBehaviour
{
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, -1.25f * 60 * Time.deltaTime);
    }
}
