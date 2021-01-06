using UnityEngine;

public class 대화창선택지 : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform 대화창선택지Text;
    void Update() => rectTransform.sizeDelta = new Vector2(대화창선택지Text.sizeDelta.x * 0.25f + 42, 대화창선택지Text.sizeDelta.y * 0.25f + 27.5f); 
}
