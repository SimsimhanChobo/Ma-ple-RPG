using UnityEngine;
using UnityEngine.UI;

public class HGTextNum : MonoBehaviour
{
    public Text HG = null;

    void Update()
    {
        HG.text = Mathf.Round(GameManager.PlayerHG).ToString();
    }
}
