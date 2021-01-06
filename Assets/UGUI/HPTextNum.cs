using UnityEngine;
using UnityEngine.UI;

public class HPTextNum : MonoBehaviour
{
    public Text HP = null;

    void Update()
    {
        HP.text = Mathf.Round(GameManager.PlayerHP).ToString();
    }
}
