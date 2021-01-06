using UnityEngine;
using UnityEngine.UI;

public class ChattingTextCut : MonoBehaviour
{
    Text text;

    void Awake() => text = GetComponent<Text>();

    void Update()
    {
        while (text.text.Length > 3150)
            text.text = text.text.Substring(1);
    }
}
