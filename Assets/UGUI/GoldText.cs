using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    public static float PlayerGoldDisplay = 0;
    public Text Text;

    void Start()
    {
        PlayerGoldDisplay = GameManager.PlayerGold;
    }

    void Update()
    {
        PlayerGoldDisplay = Mathf.Lerp(PlayerGoldDisplay, GameManager.PlayerGold, 0.05f);

        Text.text = Mathf.Round(PlayerGoldDisplay).ToString();
    }
}
