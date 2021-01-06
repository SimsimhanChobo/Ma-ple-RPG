using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAni : MonoBehaviour
{
    public bool CanBeSkipped = false;
    public float time = 0;

    public Text text;

    [TextArea]
    public string Message;

    float Timer = 0;
    int index = 0;

    void Start() => text.text = null;

    void Update()
    {
        Timer += Time.deltaTime;

        if (text.text == Message || Message.Length <= index || (CanBeSkipped && (Input.GetButtonDown("X") || Input.GetButton("C")) && !ChattingManager.ChattingActive && !InvManager.InventoryShow))
        {
            text.text = Message;
            Destroy(gameObject);
            return;
        }

        if (Timer >= time)
        {
            Timer = 0;

            text.text += Message[index];

            index++;
        }
    }
}
