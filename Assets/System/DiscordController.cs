using UnityEngine;
using DiscordPresence;

public class DiscordController : MonoBehaviour
{
    void Update()
    {
        if (GameManager.MinecraftGame)
        {
            if (!GameManager.isAction && !GameManager.Boss)
            {
                string PlayerHP = "";
                if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 4) == 4)
                    PlayerHP = "HP: ■■■■";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 4) == 3)
                    PlayerHP = "HP: ■■■□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 4) == 2)
                    PlayerHP = "HP: ■■□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 4) == 1)
                    PlayerHP = "HP: ■□□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 4) == 0)
                    PlayerHP = "HP: □□□□";

                if (GameManager.MainMenu)
                    PresenceManager.UpdatePresence(detail: "Main Menu", state: "Gold: " + GameManager.PlayerGold);
                else if (GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: PlayerHP + " HG: " + (int)Mathf.Round(GameManager.PlayerHG) + "/" + (int)Mathf.Round(GameManager.PlayerMaxHG), state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "아! 뒤주 아시는구나!", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");
                else if (GameManager.PlayerHP <= 0.001f)
                    PresenceManager.UpdatePresence(detail: "Game Over", state: GameManager.gameoverText);
            }
            else if (GameManager.isAction && !GameManager.Boss)
            {
                if (대화창NpcName.NpcName != "" && GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: 대화창NpcName.NpcName + "랑 대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (대화창NpcName.NpcName != "" && GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: 대화창NpcName.NpcName + "랑 대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");
                else if (대화창NpcName.NpcName == "" && GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (대화창NpcName.NpcName == "" && GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");
            }
            else if (GameManager.Boss)
            {
                string BossHP = "";
                if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 6)
                    BossHP = "Boss HP: ■■■■■■";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 5)
                    BossHP = "Boss HP: ■■■■■□";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 4)
                    BossHP = "Boss HP: ■■■■□□";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 3)
                    BossHP = "Boss HP: ■■■□□□";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 2)
                    BossHP = "Boss HP: ■■□□□□";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 1)
                    BossHP = "Boss HP: ■□□□□□";
                else if ((int)Mathf.Round(GameManager.BossHP / GameManager.BossMaxHP * 6) == 0)
                    BossHP = "Boss HP: □□□□□□";

                string PlayerHP = "";
                if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 6)
                    PlayerHP = "Player HP: ■■■■■■";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 5)
                    PlayerHP = "Player HP: ■■■■■□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 4)
                    PlayerHP = "Player HP: ■■■■□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 3)
                    PlayerHP = "Player HP: ■■■□□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 2)
                    PlayerHP = "Player HP: ■■□□□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 1)
                    PlayerHP = "Player HP: ■□□□□□";
                else if ((int)Mathf.Round(GameManager.PlayerHP / GameManager.PlayerMaxHP * 6) == 0)
                    PlayerHP = "Player HP: □□□□□□";

                PresenceManager.UpdatePresence(detail: PlayerHP, state: BossHP);
            }

        }
        else if (GameManager.ADOFAIGame)
            PresenceManager.UpdatePresence(detail: "A Dance of Fire and Ice", state: "Map: " + GameManager.ADOFAIMap);
    }
}
