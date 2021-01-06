using UnityEngine;

public class DebugTextBackground : MonoBehaviour
{
    public RectTransform debugText;
    public RectTransform debugTextBackground;

    void Update()
    {
        debugTextBackground.sizeDelta = new Vector2(debugText.sizeDelta.x, debugText.sizeDelta.y);
        if (!DebugText.DebugActive)
            debugTextBackground.sizeDelta = new Vector2(0, 0);
    }
}
