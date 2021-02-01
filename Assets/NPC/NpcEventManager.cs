using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcEventManager : MonoBehaviour
{
    public static NpcEventManager npcEventManager;
    public GameManager manager;
    public GameObject scanNPC;
    public static bool b;
    public static bool bb;
    public int NpcTalkAddInt = 0;
    public Text 대화창선택지Text;
    public GameObject 대화창선택지;
    public static int 선택지수 = 0;

    public bool TalkEventEnd = false;

    void Start() => npcEventManager = GetComponent<NpcEventManager>();

    void Update()
    {
        if (!GameManager.isAction && scanNPC != null)
            대화창선택지.SetActive(false);
    }

    public static void SelectEnd() => npcEventManager.대화창선택지.SetActive(false);

    public static void SelectMove()
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
                GameManager.EventSelection++;

            bb = true;
        }

        if (!GameManager.UpKey && !GameManager.DownKey)
            bb = false;

        if (GameManager.EventSelection < 0)
            GameManager.EventSelection = 선택지수 - 1;

        if (GameManager.EventSelection > 선택지수 - 1)
            GameManager.EventSelection = 0;
    }

    public static void Select(string SelectString, int SelectCount)
    {
        GameManager.EventSelection = 0;
        npcEventManager.대화창선택지Text.text = SelectString;
        선택지수 = SelectCount;
        npcEventManager.대화창선택지.SetActive(true);
    }
}