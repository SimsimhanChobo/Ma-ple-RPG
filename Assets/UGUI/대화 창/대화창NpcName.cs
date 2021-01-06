using UnityEngine;
using UnityEngine.UI;

public class 대화창NpcName : MonoBehaviour
{
    public Text text;
    public GameObject scanNPC;
    public Image image;
    public GameManager manager;
    int i = 0;
    public static string NpcName = "";

    RectTransform rectTransform;
    public RectTransform 대화창NpcNameText;
    void Update()
    {
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

        scanNPC = Player.scanNPC;

        if (scanNPC != null)
        {
            NpcData npcData = scanNPC.GetComponent<NpcData>();

            if (npcData.IntNpcNameChange.Length == 0)
            {
                NpcName = "";
                text.text = "";
                image.color = new Color(1, 1, 1, 0);
                text.color = new Color(0, 0, 0, 0);
                return;
            }
            else if (npcData.IntNpcNameChange.Length < i)
                if (npcData.IntNpcNameChange[i] <= manager.talkIndex - 1 && npcData.NpcNameChange[i] == "")
                {
                    NpcName = "";
                    text.text = "";
                    image.color = new Color(1, 1, 1, 0);
                    text.color = new Color(0, 0, 0, 0);
                    return;
                }    

            if (npcData.IntNpcNameChange[i] <= manager.talkIndex - 1)
            {
                NpcName = npcData.NpcNameChange[i];
                i++;
                if (npcData.IntNpcNameChange.Length <= i)
                    i = npcData.IntNpcNameChange.Length - 1;

            }

            text.text = NpcName;

            if (!GameManager.isAction)
                text.text = npcData.NpcNameChange[0];
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
