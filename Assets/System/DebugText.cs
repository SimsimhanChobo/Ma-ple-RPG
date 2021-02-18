using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Text Text = null;

    public static bool DebugActive = false;

    float tempTimer;
    float tempFPS;
    int tempFPS2;
    float Timer;

    int FPS;
    int FPS2;

    void Update()
    {
        tempTimer += Time.unscaledDeltaTime;
        tempFPS += Time.timeScale;
        tempFPS2++;
        if (tempTimer >= 1)
        {
            FPS = (int)Mathf.Round(tempFPS);
            tempFPS = 0;
            FPS2 = tempFPS2;
            tempFPS2 = 0;
            tempTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (DebugActive)
            {
                DebugActive = false;
                Text.text = null;
            }
            else
                DebugActive = true;
        }

        Timer += Time.unscaledDeltaTime;
        if (DebugActive)
        {
            if (Timer >= 0.1f)
            {
                Timer = 0;

                if (Time.deltaTime != 0)
                    Text.text = "Delta Time : " + Time.deltaTime + "\nUnscaled Delta Time : " + Time.unscaledDeltaTime + "\n\nDelta Time FPS : " + Mathf.Round(1 / Time.deltaTime) + "\nUnscaled Delta Time FPS : " + Mathf.Round(1 / Time.unscaledDeltaTime) + "\n\nDelta Time × 60 : " + (60 * Time.deltaTime) + "\nUnscaled Delta Time × 60 : " + (60 * (60 * Time.unscaledDeltaTime)) + "\n\nFPS : " + FPS + "\nUnscaled FPS : " + FPS2;
                else
                    Text.text = "Delta Time : " + Time.deltaTime + "\nUnscaled Delta Time : " + Time.unscaledDeltaTime + "\n\nDelta Time FPS : Pause" + "\nUnscaled Delta Time FPS : " + Mathf.Round(1 / Time.unscaledDeltaTime) + "\n\nDelta Time × 60 : " + (60 * Time.deltaTime) + "\nUnscaled Delta Time × 60 : " + (60 * (60 * Time.unscaledDeltaTime)) + "\n\nFPS : Pause" + "\nUnscaled FPS : " + FPS2;

                Text.text += "\n\nGame Time: " + GameManager.GameTime;
                Text.text += "\nGame Speed : " + GameManager.GameSpeed;
                Text.text += "\nTimer : " + GameManager.Timer;
                Text.text += "\nBPM : " + GameManager.BPM;
                Text.text += "\nCurrentBeat : " + GameManager.CurrentBeat;
                Text.text += "\nStart Delay : " + GameManager.StartDelay;
                Text.text += "\nPitch : " + GameManager.Pitch;
                Text.text += "\nCamera X 고정 : " + GameManager.CameraX고정;
                Text.text += "\nCamera Y 고정 : " + GameManager.CameraY고정;
                Text.text += "\nMain Menu : " + GameManager.MainMenu;
                Text.text += "\nMap : " + GameManager.Map;
                Text.text += "\n\nPlayer Max HP : " + GameManager.PlayerMaxHP;
                Text.text += "\nPlayer HP : " + GameManager.PlayerHP;
                Text.text += "\nPlayer Max HG : " + GameManager.PlayerMaxHG;
                Text.text += "\nPlayer HG : " + GameManager.PlayerHG;
                Text.text += "\nPlayer Max AV : " + GameManager.PlayerMaxAV;
                Text.text += "\nPlayer AV : " + GameManager.PlayerAV;
                Text.text += "\nPlayer Max XP : " + GameManager.PlayerMaxXP;
                Text.text += "\nPlayer XP : " + GameManager.PlayerXP;
                Text.text += "\nPlayer Level : " + GameManager.PlayerLevel;
                Text.text += "\n난 돈이 좋아 : " + GameManager.PlayerGold;
                Text.text += "\n\nPlayer Jump Power : " + GameManager.PlayerJumpPower;
                Text.text += "\nPlayer Speed : " + GameManager.PlayerMaxSpeed;
                Text.text += "\n\nPlayer X : " + GameManager.PlayerX;
                Text.text += "\nPlayer Y : " + GameManager.PlayerY;
                Text.text += "\nPlayer Z : " + GameManager.PlayerZ;
                Text.text += "\n\nPlayer Inv Cannes : " + GameManager.PlayerInvCannes;
                Text.text += "\nPlayer Inv Item : " + GameManager.PlayerInvItem;
                Text.text += "\nPlayer Inv Max Line : " + GameManager.PlayerInvMaxLine;
                Text.text += "\nPlayer Inv Line : " + GameManager.PlayerInvLine;
                Text.text += "\nPlayer Inv : ";

                int i = 0;
                while (i < GameManager.PlayerInv.Count - 1)
                {
                    Text.text += GameManager.PlayerInv[i] + ", ";
                    i++;
                }
                if (GameManager.PlayerInv.Count != 0)
                    Text.text += GameManager.PlayerInv[GameManager.PlayerInv.Count - 1];
                else
                    Text.text += "null";
            }
        }
        else
            Text.text = null;
    }

    public void DebugToggle()
    {
        if (DebugActive)
            DebugActive = false;
        else
            DebugActive = true;
    }
}
