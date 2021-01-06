using UnityEngine;

public class DebugModeLog : MonoBehaviour
{
    public GameObject DebugLog;
    public static GameObject debugLog;
    public GameObject Prefab;
    public static GameObject prefab;
    public DebugLogClone DebugLogClone;
    public static DebugLogClone debugLogClone;
    public static object DebugLogMessage = "";

    public static bool GameStart = false;

    void Awake()
    {
        debugLog = DebugLog;
        prefab = Prefab;
        debugLogClone = DebugLogClone;
        debugLogClone.cloneCount = 0;
        DebugLogClone.cloneCount2 = 0;
        debugLogClone.Timer = 0;
        debugLogClone.i = 1;
    }

    public static void debugModeLog(object debugLogMessage)
    {
        if (debugLog != null)
        {
            DebugLogMessage = debugLogMessage;

            debugLogClone.CloneCount();
            Instantiate(prefab, new Vector2(Screen.width, Screen.height + 52), Quaternion.identity, debugLog.transform);
        }
    }
    void OnApplicationQuit()
    {
        debugLogClone.cloneCount = -2;
        debugLogClone.Timer = 0;
        debugLogClone.i = 1;
    }
}
