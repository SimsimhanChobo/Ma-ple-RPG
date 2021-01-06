using UnityEngine;
using UnityEngine.UI;

public class 대화창TextEffect : MonoBehaviour
{
    public string targetMsg;
    public float Speed;
    public GameObject 대화창화살표;
    public Text msgText;
    int index = 0;
    public static bool isAnim = false;
    public GameManager manager;

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

            if (Input.GetKeyDown(KeyCode.RightShift) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                msgText.text = targetMsg;
                CancelInvoke();
                EffectEnd();
            }

            if (Input.GetKey(KeyCode.C) && NpcEventManager.b && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                msgText.text = targetMsg;

            if (GameManager.CKey && NpcEventManager.b)
                msgText.text = targetMsg;

            if (Input.GetKey(KeyCode.C) && !NpcEventManager.b && !ChattingManager.ChattingActive && !InvManager.InventoryShow && !InvManager.InventoryShow)
            {
                GameObject scanNPC = Player.scanNPC;
                NpcData npcData = scanNPC.GetComponent<NpcData>();

                if (npcData.NpcTalk.Count < manager.talkIndex - 1)
                    targetMsg = npcData.NpcTalk[manager.talkIndex - 1];
                msgText.text = targetMsg;
            }

            if (GameManager.CKey && !NpcEventManager.b)
            {
                GameObject scanNPC = Player.scanNPC;
                NpcData npcData = scanNPC.GetComponent<NpcData>();

                targetMsg = npcData.NpcTalk[manager.talkIndex - 1];
                msgText.text = targetMsg;
            }
        }
    }
}
