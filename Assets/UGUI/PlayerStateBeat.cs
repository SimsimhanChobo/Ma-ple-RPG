using UnityEngine;

public class PlayerStateBeat : MonoBehaviour
{
    public RectTransform MainCameraSize;

    public float NextBeat = 0f;

    public bool b = false;

    void Update()
    {
        if (!GameManager.DeltaruneBattle && !DeltaruneBattleManager.EndAni)
        {
            if (b && (GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
            {
                Vector3 target = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), -90f + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
                transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));
            }
            else
            {
                Vector3 target = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), -90f + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
                transform.localPosition = target;
            }

            if (GameManager.Pitch > 0)
            {
                if (NextBeat < GameManager.CurrentBeat)
                {
                    NextBeat += 1;
                    if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                        transform.localPosition = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), (-90f + 3f) + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
                }
            }

            if (GameManager.Pitch < 0)
            {
                if (NextBeat > GameManager.CurrentBeat)
                {
                    NextBeat -= 1;
                    if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                        transform.localPosition = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), (-90f + 3f) + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
                }
            }
        }
        else if ((!GameManager.DeltaruneBattle && DeltaruneBattleManager.EndAni) || (GameManager.DeltaruneBattle && DeltaruneBattleManager.StartAni))
        {
            Vector3 target = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), -90f + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
            transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));
        }
        else if (GameManager.DeltaruneBattle && !DeltaruneBattleManager.StartAni)
        {
            Vector3 target = new Vector2(98f - MainCameraSize.sizeDelta.x * 0.5f * (1 / GameManager.GUISize), 70f + MainCameraSize.sizeDelta.y * 0.5f * (1 / GameManager.GUISize));
            transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));
        }

        if (!b)
            b = true;
    }
}
