using UnityEngine;
using DiscordPresence;

public class DiscordController : MonoBehaviour
{
    void Update()
    {
        if (GameManager.MinecraftGame)
        {
            if (!GameManager.isAction)
            {
                if (GameManager.MainMenu)
                    PresenceManager.UpdatePresence(detail: "Main Menu", state: "Gold: " + GameManager.PlayerGold);
                else if (GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "마플마플 RPG", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "아! 뒤주 아시는구나!", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");
                else if (GameManager.PlayerHP <= 0.001f)
                    PresenceManager.UpdatePresence(detail: "Game Over", state: GameManager.gameoverText);
            }
            else if (GameManager.isAction)
                if (대화창NpcName.NpcName != "" && GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: 대화창NpcName.NpcName + "랑 대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (대화창NpcName.NpcName != "" && GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: 대화창NpcName.NpcName + "랑 대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");
                else if (대화창NpcName.NpcName == "" && GameManager.PlayerHP > 0.001f && !event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map);
                else if (대화창NpcName.NpcName == "" && GameManager.PlayerHP > 0.001f && event_soft_lock.Play)
                    PresenceManager.UpdatePresence(detail: "대화 중...", state: "Gold: " + GameManager.PlayerGold + " Map: " + GameManager.Map + " (뒤주)");

        }
        else if (GameManager.ADOFAIGame)
            PresenceManager.UpdatePresence(detail: "A Dance of Fire and Ice", state: "Map: " + GameManager.ADOFAIMap);
    }
}
