using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public GameObject _TalkPrefab;
    static GameObject TalkPrefab;

    static GameObject talkManager;

    static string temp;

    void OnEnable()
    {
        TalkPrefab = _TalkPrefab;
        talkManager = gameObject;
    }

    public static void Message(Text text, string Message) => message(text, Message, 0.075f, false);
    public static void Message(Text text, string Message, float Time) => message(text, Message, Time, false);
    public static void Message(Text text, string Message, bool CanBeSkipped) => message(text, Message, 0.075f, CanBeSkipped);
    public static void Message(Text text, string Message, float Time, bool CanBeSkipped) => message(text, Message, Time, CanBeSkipped);

    static void message(Text text, string Message, float Time, bool CanBeSkipped)
    {
        Transform[] allChildren = talkManager.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allChildren.Length; i++)
            if (temp == Message || allChildren[i].name == Message)
                return;


        temp = Message;

        GameObject TalkMessageAni = Instantiate(TalkPrefab, talkManager.transform);
        TalkMessageAni.name = Message;
        
        MessageAni messageAni = TalkMessageAni.GetComponent<MessageAni>();
        messageAni.text = text;
        messageAni.Message = Message;
        messageAni.time = Time;
        messageAni.CanBeSkipped = CanBeSkipped;
    }
}
