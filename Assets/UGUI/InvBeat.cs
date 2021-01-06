using UnityEngine;

public class InvBeat : MonoBehaviour
{
    public RectTransform MainCameraSize;

    public float NextBeat = 0f;
    void Update()
    {
        if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
        {
            Vector3 target = new Vector2(0, 22f - MainCameraSize.sizeDelta.y * 0.5f * (1f / GameManager.GUISize));
            transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));
        }
        else
        {
            Vector3 target = new Vector2(0, 22f - MainCameraSize.sizeDelta.y * 0.5f * (1f / GameManager.GUISize));
            transform.localPosition = target;
        }

        if (GameManager.Pitch > 0)
        {
            if (NextBeat < GameManager.CurrentBeat)
            {
                NextBeat += 1;
                if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                    transform.localPosition = new Vector2(0, (22f + 3f) - MainCameraSize.sizeDelta.y * 0.5f * (1f / GameManager.GUISize));
            }
        }

        if (GameManager.Pitch < 0)
        {
            if (NextBeat > GameManager.CurrentBeat)
            {
                NextBeat -= 1;
                if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                    transform.localPosition = new Vector2(0, (22f + 3f) - MainCameraSize.sizeDelta.y * 0.5f * (1f / GameManager.GUISize));
            }
        }
    }
}
