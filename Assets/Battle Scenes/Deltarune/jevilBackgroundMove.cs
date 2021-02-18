using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jevilBackgroundMove : MonoBehaviour
{
    public bool Clone = false;

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition += new Vector3(-1.25f * 60 * Time.deltaTime, 0);

        if (Clone && rectTransform.localPosition.x <= 0)
            rectTransform.localPosition = new Vector2(960, 0);
        else if (!Clone && rectTransform.localPosition.x <= -960)
            rectTransform.localPosition = new Vector2(0, 0);
    }
}
