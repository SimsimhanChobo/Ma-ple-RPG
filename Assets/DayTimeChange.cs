using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeChange : MonoBehaviour
{
    InputField inputField;

    void Awake() => inputField = GetComponent<InputField>();

    void Start()
    {
        inputField.text = GameManager.DayTimeMinute + "";

        if (GameManager.DayTimeMinute == -1)
            inputField.text = "";
    }

    void Update()
    {
        if (inputField.text == "")
            GameManager.DayTimeMinute = -1;
        else
            GameManager.DayTimeMinute = float.Parse(inputField.text);
    }
}
