using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcEventManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject scanNPC;
    public static bool b;
    public bool bb;
    public int NpcTalkAddInt = 0;
    public Text 대화창선택지Text;
    public RectTransform 대화창선택된배경;
    public GameObject 대화창선택지;
    public static int 선택지수 = 0;

    public List<string> messageRestore = new List<string>();

    public GameObject 운터의숙소문Left;
    public GameObject 운터의숙소문Right;
    public static bool 숙소자기 = false;
    public bool 무료숙소자기 = false;
    public float 숙소자기f = 1;
    public bool 숙소자기b = false;
    public Image BlackImage;
    public GameObject blackImage;

    public bool TalkEventEnd = false;

    void Update()
    {
        if (!GameManager.isAction && scanNPC != null)
        {
            MessageReset(true);

            대화창선택지.SetActive(false);

            reset();
        }

        if (Player.scanNPC != null)
        {
            scanNPC = Player.scanNPC;
            NpcData npcData = scanNPC.GetComponent<NpcData>();

            if (GameManager.isAction)
            {
                TalkEventEnd = false;

                if (npcData.NpcID == 2 && manager.talkIndex == 1 && npcData.NpcMap == GameManager.Map)
                {
                    운터의숙소문Left.transform.localEulerAngles = new Vector3(0, -90, 0);
                    운터의숙소문Right.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else if (npcData.NpcID == 2 && manager.talkIndex == 3 && npcData.NpcMap == GameManager.Map)
                {
                    Select("네\n아니요\n?", 3);

                    SelectMove();

                    if (GameManager.EventSelection == 0)
                    {
                        MessageReset(false);

                        if (GameManager.PlayerGold >= 100)
                        {
                            Message("잘자!");
                            숙소자기 = true;
                        }
                        else
                        {
                            Message("으음..");
                            Message("돈이 없는것 같은데?");
                            숙소자기 = false;
                        }
                    }
                    else if (GameManager.EventSelection == 1)
                    {
                        MessageReset(false);

                        Message("필요하면 나중에 다시 왔으면 좋갰어!");
                        숙소자기 = false;
                    }
                    else if (GameManager.EventSelection == 2)
                    {
                        MessageReset(false);

                        Message("어...");
                        Message("그니까");
                        Message("음...");
                        Message("(내가 뭘 해야할까...?)");
                        Message("(그렇지!)");
                        Message("알갰어 무료로 해달라는거지?");
                        숙소자기 = false;
                    }
                }
                else if (npcData.NpcID == 2 && manager.talkIndex == 9 && npcData.NpcMap == GameManager.Map)
                {
                    Select("그렇지 그쯤은 돼야지\n?", 2);

                    SelectMove();

                    if (GameManager.EventSelection == 0)
                    {
                        MessageReset(false);

                        Message("어...");
                        Message("그니까");
                        Message("음...");
                        Message("(내가 뭘 해야할까...?)");
                        Message("(그렇지!)");
                        Message("알갰어 무료로 해달라는거지?");
                        Message("(역시 무료였구만)");
                        Message("잘자!");
                        숙소자기 = true;
                        무료숙소자기 = true;
                    }
                    else if (GameManager.EventSelection == 1)
                    {
                        MessageReset(false);

                        Message("어...");
                        Message("그니까");
                        Message("음...");
                        Message("(내가 뭘 해야할까...?)");
                        Message("(그렇지!)");
                        Message("알갰어 무료로 해달라는거지?");
                        Message("(이게 아니였나...)");
                        숙소자기 = false;
                        무료숙소자기 = false;
                    }
                }
                else reset();
            }
            else
            {
                if (!TalkEventEnd && npcData.NpcID == 2 && npcData.NpcMap == GameManager.Map)
                {
                    운터의숙소문Left.transform.localEulerAngles = new Vector3(0, 0, 0);
                    운터의숙소문Right.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                
                if (!TalkEventEnd && 숙소자기)
                {
                    GameManager.일시정지 = true;
                    if (!숙소자기b)
                    {
                        blackImage.SetActive(true);
                        숙소자기f += 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed);
                        BlackImage.color = new Color(0, 0, 0, 숙소자기f);
                    }
                    else
                    {
                        숙소자기f -= 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed);
                        BlackImage.color = new Color(0, 0, 0, 숙소자기f);
                    }

                    if (숙소자기f >= 2 && !숙소자기b)
                    {
                        숙소자기f = 1;
                        숙소자기b = true;
                        GameManager.PlayerHP = GameManager.PlayerMaxHP;
                        GameManager.PlayerHG += GameManager.PlayerMaxHG / 100 * 30;
                        if (!무료숙소자기)
                            GameManager.PlayerGold -= 100;
                    }
                }

                if (숙소자기b && 숙소자기f <= 0)
                {
                    무료숙소자기 = false;

                    GameManager.일시정지 = false;

                    blackImage.SetActive(false);

                    숙소자기 = false;
                    숙소자기b = false;
                    숙소자기f = 0;

                    TalkEventEnd = true;
                }
            }
                
        }
    }

    void SelectMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            GameManager.EventSelection--;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            GameManager.EventSelection++;

        if (GameManager.UpKey)
        {
            if (!bb)
                GameManager.EventSelection--;

            bb = true;
        }

        if (GameManager.DownKey)
        {
            if (!bb)
            {
                GameManager.EventSelection++;
            }

            bb = true;
        }

        if (!GameManager.UpKey && !GameManager.DownKey)
            bb = false;

        if (GameManager.EventSelection < 0)
            GameManager.EventSelection = 선택지수 - 1;

        if (GameManager.EventSelection > 선택지수 - 1)
            GameManager.EventSelection = 0;
    }

    void MessageReset(bool b)
    {
        if (!b)
            scanNPC = Player.scanNPC;
        NpcData npcData = scanNPC.GetComponent<NpcData>();

        if (scanNPC != null && NpcTalkAddInt != 0)
        {
            for (int i = 0; i < NpcTalkAddInt; i++)
                npcData.NpcTalk.RemoveAt(npcData.NpcTalk.Count - 1);
        }
        NpcTalkAddInt = 0;
    }

    void reset()
    {
        b = true;
        대화창선택지.SetActive(false);
    }

    void Message(string message)
    {
        scanNPC = Player.scanNPC;
        NpcData npcData = scanNPC.GetComponent<NpcData>();

        npcData.NpcTalk.Add(message);
        NpcTalkAddInt++;
    }

    void Select(string SelectString, int SelectCount)
    {

        if (b)
        {
            b = false;

            GameManager.EventSelection = 0;
            대화창선택지Text.text = SelectString;
            선택지수 = SelectCount;
            대화창선택지.SetActive(true);
        }
    }
}
