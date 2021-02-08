using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public bool MainMenu = false;
    bool event_soft_lock_end = false;
    public LogoBeat LogoBeat;
    public PlayerStateBeat PlayerStateBeat;
    public InvBeat InvBeat;
    public static BeatManager beatManager;

    void Start() => beatManager = GetComponent<BeatManager>();

    void Update()
    {
        if (!GameManager.일시정지)
        {
            if (!event_soft_lock.Play)
            {
                event_soft_lock_end = true;

                if (GameManager.MainMenu && !GameManager.Boss)
                {
                    GameManager.BPM = 128;
                    GameManager.StartDelay = 0.3f;
                }
                else if (GameManager.MainMenu == false && !GameManager.Boss)
                {
                    if (GameManager.Map == 0)
                    {
                        GameManager.BPM = 0;
                        GameManager.StartDelay = 0;
                    }
                }
            }
            else if (event_soft_lock.Play && !GameManager.Boss)
            {
                if (GameManager.CurrentBeat < 2)
                {
                    GameManager.StartDelay = 0f;
                    GameManager.BPM = 90;
                }
                else if (GameManager.CurrentBeat >= 2)
                {
                    if (event_soft_lock_end)
                    {
                        GameManager.StartDelay = 0.03f;
                        GameManager.Timer = 0;
                        GameManager.CurrentBeat = 0;
                        event_soft_lock_end = false;
                        NextBeatRestart();
                    }
                    GameManager.StartDelay = 0f;
                    GameManager.BPM = 180;
                }
            }
        }

        if (GameManager.MainMenu)
        {
            if (!MainMenu && !GameManager.Boss)
                NextBeatRestart();
            MainMenu = true;

        }
        else
            MainMenu = false;

    }

    public void NextBeatRestart()
    {
        LogoBeat.NextBeat = 0;
        PlayerStateBeat.NextBeat = 0;
        InvBeat.NextBeat = 0;
    }
}
