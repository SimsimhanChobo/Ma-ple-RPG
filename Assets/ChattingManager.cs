using UnityEngine;
using UnityEngine.UI;

public class ChattingManager : MonoBehaviour
{
    public static bool ChattingActive = false;
    public GameObject ChattingCanvas;
    public RectTransform Content;

    public InputField inputField;

    public Text _ChattingText;
    static Text ChattingText;

    void Update()
    {
        if (!ChattingCanvas.activeSelf)
            ChattingActive = false;

        ChattingText = _ChattingText;

        if (Input.GetKeyDown(KeyCode.T) && !ChattingActive && !InvManager.InventoryShow && !GameManager.isAction)
            ChattingActive = true;
        else if (Input.GetKeyDown(KeyCode.Slash) && !ChattingActive && !InvManager.InventoryShow && !GameManager.isAction)
        {
            ChattingActive = true;
            inputField.text = "/";
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ChattingActive && !InvManager.InventoryShow && !GameManager.isAction)
        {
            ChattingCanvas.SetActive(false);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && ChattingActive && !InvManager.InventoryShow && !GameManager.isAction)
        {
            Chatting(inputField.text);
            ChattingActive = false;
        }

        if (!ChattingActive)
        {
            ChattingCanvas.SetActive(false);
            Content.localPosition = new Vector2(0, 1620);
        }
        else
            ChattingCanvas.SetActive(true);
    }

    public static void Chatting(string Message)
    {
        if (Message != "")
        {
            for (int i = 0; i <= Message.Length; i++)
            {
                if (Message[0].ToString() != " ")
                    break;

                Message = Message.Substring(1);
            }

            if (Message != "")
            {
                if (Message[0].ToString() == "/")
                {
                    CommandManager.Command(Message);
                    ChattingActive = false;
                    return;
                }

                ChattingText.text += "\n<MinedApple> " + Message;
            }
        }
    }

    public static void Message(string Message) => ChattingText.text += "\n" + Message;
}
