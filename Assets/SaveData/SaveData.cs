using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public PlayerData _playerData;
    public PlayerEventData _playerEventData;
    public SettingData _settingData;
    public AdvancementsData _advancementsData;
    public StatisticsData _statisticsData;
    public NpcEventData _npcEventData;

    public static PlayerData playerData;
    public static PlayerEventData playerEventData;
    public static SettingData settingData;
    public static AdvancementsData advancementsData;
    public static StatisticsData statisticsData;
    public static NpcEventData npcEventData;
    
    public static string path;

    void Awake()
    {
        playerData = _playerData;
        playerEventData = _playerEventData;
        settingData = _settingData;
        advancementsData = _advancementsData;
        statisticsData = _statisticsData;
        npcEventData = _npcEventData;
    }

    [ContextMenu("To Json Data")]
    public static void saveData()
    {
        path = Path.Combine(Application.persistentDataPath + "/SaveData");
        Debug.Log("Path: " + path);

        if (!File.Exists(path))
        {
            path = Path.Combine(Application.persistentDataPath + "/SaveData");
            Directory.CreateDirectory(path);
        }

        string jsonData = JsonUtility.ToJson(playerData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/PlayerSaveData.json");
        File.WriteAllText(path, jsonData);

        jsonData = JsonUtility.ToJson(playerEventData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/PlayerEventSaveData.json");
        File.WriteAllText(path, jsonData);

        jsonData = JsonUtility.ToJson(settingData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/SettingSaveData.json");
        File.WriteAllText(path, jsonData);

        jsonData = JsonUtility.ToJson(advancementsData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/AdvancementsSaveData.json");
        File.WriteAllText(path, jsonData);

        jsonData = JsonUtility.ToJson(statisticsData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/StatisticsSaveData.json");
        File.WriteAllText(path, jsonData);

        jsonData = JsonUtility.ToJson(npcEventData, true);
        path = Path.Combine(Application.persistentDataPath + "/SaveData/NpcEventSaveData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public static void loadData()
    {
        path = Path.Combine(Application.persistentDataPath + "/SaveData");
        Debug.Log("Path: " + path);

        if (!File.Exists(path))
            Directory.CreateDirectory(path);

        path = Path.Combine(Application.persistentDataPath + "/SaveData/PlayerSaveData.json");
        if (!File.Exists(path))
            GameManager.gameManager.PlayerDataReset(false);
        else
        {
            string jsonData = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }

        path = Path.Combine(Application.persistentDataPath + "/SaveData/PlayerEventSaveData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            playerEventData = JsonUtility.FromJson<PlayerEventData>(jsonData);
        }

        path = Path.Combine(Application.persistentDataPath + "/SaveData/SettingSaveData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            settingData = JsonUtility.FromJson<SettingData>(jsonData);
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public bool MainMenu;

    public float PlayerX;
    public float PlayerY;
    public float PlayerZ;

    public Vector3 MainCameraPos;

    [Header("플레이어 상태")]
    [Tooltip("플레이어의 상태입니다")]
    public float PlayerMaxHP;
    public float PlayerHP;
    public float PlayerMaxHG;
    public float PlayerHG;
    public float PlayerAS;
    public float Air;

    public int FallDamage;

    [Space(15)]
    public int PlayerLevel;
    public float PlayerMaxXP;
    public float PlayerXP;

    [Space(15)]
    public float PlayerGold;

    [Space(15)]
    public float PlayerSpeed;
    public float PlayerJumpPower;
    public string Chapter;
    public int Map;

    [Space(15)]
    public int GameMode;

    [Header("기타 정보")]
    [Tooltip("기타 정보들 입니다")]
    public string GameOverText;

    [Header("플레이어 인벤토리")]
    [Tooltip("플레이어의 인벤토리와 상태들입니다")]
    public List<string> PlayerInv;
    public int PlayerInvMaxLine;
}

[System.Serializable]
public class PlayerEventData
{
    public bool soft_lock;
}

[System.Serializable]
public class SettingData
{
    public float GUISize;
    public bool Sky;
    public int GameTime;
    public float time;
    public float dataTimeMinute;
    public float MainVolume;
    public int Graphic;
    public int GUIAni;
    public int BlockAni;
    public int CameraAni;
    public int TalkAni;
    public bool Particle;
    public int PlayerLerpMove;
    public bool Game3D;
}

[System.Serializable]
public class AdvancementsData
{
    
}

[System.Serializable]
public class StatisticsData
{

}

public class NpcEventData
{

}
