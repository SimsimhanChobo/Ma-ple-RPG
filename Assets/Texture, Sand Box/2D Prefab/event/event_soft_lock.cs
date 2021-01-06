using UnityEngine;

public class event_soft_lock : MonoBehaviour
{
    public static bool start = false;
    public static bool Play = false;
    public static bool Stop = false;

    void Start()
    {
        if (Play == true)
        {
            Play = false;
            start = true;
        }
    }

    void Update()
    {
        if (start && !Play)
        {
            start = false;
            Play = true;

            SoundManager.StopAll(SoundType.BGM);
            SoundManager.PlayBGM("MIDI.Slide Start", false, 0.3f, 1, true);

            NINTENDO64Logo.event_soft_lock();

            Invoke("Loop", 2.62f);
        }

        if (GameManager.PlayerHP <= 0.0001f || Stop)
        {
            if (Play)
            {
                Play = false;
                Stop = false;
                GameManager.SoundRestart = true;
                SoundManager.StopBGM("MIDI.Slide Start");
                SoundManager.StopBGM("MIDI.Slide");
                NINTENDO64Logo.Start = false;
                CancelInvoke();
            }
        }
    }

    void Loop() => SoundManager.PlayBGM("MIDI.Slide", true, 0.3f, 1, true);
}
