using UnityEngine;
using UnityEngine.UI;

public class AVTextNum : MonoBehaviour
{
    public Text AV = null;

    void Update() => AV.text = Mathf.Round(GameManager.PlayerAV).ToString();
}
