using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text Text;

    void Update()
    {
        if (GameManager.PlayerLevel == 0)
            Text.text = "";
        else
            Text.text = "" + GameManager.PlayerLevel;
    }
}
