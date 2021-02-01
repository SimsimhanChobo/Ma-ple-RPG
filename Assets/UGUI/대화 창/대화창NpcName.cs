using UnityEngine;
using UnityEngine.UI;

public class 대화창NpcName : MonoBehaviour
{
    public Text text;
    public GameObject scanNPC;
    public Image image;
    public GameManager manager;
    public int i = 0;
    public static string NpcName = "";

    RectTransform rectTransform;
    public RectTransform 대화창NpcNameText;
    void Update()
    {
        text.text = NpcName;

        if (GameManager.isAction)
        {
            image.color = new Color(1, 1, 1, 1);
            text.color = new Color(0, 0, 0, 1);
        }
        else
        {
            image.color = new Color(1, 1, 1, 0);
            text.color = new Color(0, 0, 0, 0);
            i = 0;
        }

        if (text.text == "")
        {
            image.color = new Color(1, 1, 1, 0);
            text.color = new Color(0, 0, 0, 0);
        }

        rectTransform = GetComponentInChildren<RectTransform>();
        rectTransform.sizeDelta = new Vector2(대화창NpcNameText.sizeDelta.x * 0.25f + 45, rectTransform.sizeDelta.y);
    }
}
