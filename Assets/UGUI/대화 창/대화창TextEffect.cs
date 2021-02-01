using UnityEngine;
using UnityEngine.UI;

public class 대화창TextEffect : MonoBehaviour
{
    public static MonoBehaviour monoBehaviour;
    public static string targetMsg;
    public float Speed;
    public GameObject 대화창화살표;
    public Text msgText;
    public static Text Text;
    int index = 0;
    public static bool isAnim = false;
    public GameManager manager;

    void Start()
    {
        Text = msgText;
        monoBehaviour = this;
    }

    public static void SetText(string text)
    {
        monoBehaviour.CancelInvoke();
        targetMsg = text;
        Text.text = text;
    }

    public void SetMsg(string msg)
    {
        if (isAnim == false)
        {
            targetMsg = msg;
            CancelInvoke();
            EffectStart();
        }
    }

    void EffectStart()
    {
        if (GameManager.TalkAni == 2 || (GameManager.Graphic == 1 && GameManager.TalkAni == 0))
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
            return;
        }

        msgText.text = "";
        index = 0;
        대화창화살표.SetActive(false);

        isAnim = true;

        Invoke("Effecting", 0.06f);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg || index >= targetMsg.Length || GameManager.TalkAni == 2 || (GameManager.Graphic == 1 && GameManager.TalkAni == 0))
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        index++;
        
        Invoke("Effecting", 0.06f);
    }

    public void EffectEnd()
    {
        isAnim = false;
        index = 0;
        대화창화살표.SetActive(true);
    }

    void Update()
    {
        if (GameManager.isAction)
        {
            if (Input.GetKeyDown(KeyCode.X) && !ChattingManager.ChattingActive && !InvManager.InventoryShow) 
            {
                msgText.text = targetMsg;
                CancelInvoke();
                EffectEnd();
            }

            if (GameManager.XKey)
            {
                GameManager.XKey = false;
                msgText.text = targetMsg;
                CancelInvoke();
                EffectEnd();
            }

            if (Input.GetKey(KeyCode.C) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                msgText.text = targetMsg;

            if (GameManager.CKey)
                msgText.text = targetMsg;
        }
    }
}
