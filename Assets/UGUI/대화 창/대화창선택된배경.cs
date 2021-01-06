using UnityEngine;

public class 대화창선택된배경 : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform 대화창선택지Text;
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(대화창선택지Text.sizeDelta.x * 0.25f + 42, rectTransform.sizeDelta.y);

        rectTransform.pivot = new Vector2(0.5f, 1 - NpcEventManager.선택지수);

        Vector2 target = new Vector2(rectTransform.localPosition.x, -56 * GameManager.EventSelection);

        if ((GameManager.Graphic == 0 && GameManager.TalkAni == 0) || GameManager.TalkAni == 1)
            rectTransform.localPosition = Vector2.Lerp(rectTransform.localPosition, target, 0.15f * 60 * Time.deltaTime);
        else
            rectTransform.localPosition = target;
    }
}
