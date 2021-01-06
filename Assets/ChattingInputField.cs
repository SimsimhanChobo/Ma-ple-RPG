using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChattingInputField : MonoBehaviour
{
    public InputField inputField;
    public RectTransform rectTransform;

    void Update()
    {
        if (!inputField.isFocused && ChattingManager.ChattingActive)
            inputField.ActivateInputField();

        if (!inputField.isFocused)
        {
            inputField.selectionColor = new Color(1, 1, 1, 0);
            StartCoroutine("end_text");
        }

        if (!ChattingManager.ChattingActive)
            inputField.text = "";

        if (PhoneControllerHide.phoneControllerHide)
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, new Vector2((Screen.width - 10) * (1 / GameManager.GUISize) * 4, 120), 0.125f * (Time.deltaTime * 60));
        else
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, new Vector2((Screen.width - 10 - (256 * (Screen.width / 1280f))) * (1 / GameManager.GUISize) * 4, 120), 0.125f * (Time.deltaTime * 60));
    }

    IEnumerator end_text()
    {
        yield return null;
        inputField.MoveTextEnd(false);
        inputField.selectionColor = new Color(1, 1, 1, 0.5f);
    }
}
