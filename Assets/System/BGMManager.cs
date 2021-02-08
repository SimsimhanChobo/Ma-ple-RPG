using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public bool MainMenu = false;

    public AudioSource 일시정지Canvas;
    public static float MaxVol = 1;

    public static AudioSource audioSourceNormal;
    public static AudioSource audioSourceBit8;

    public static GameObject gameObject2;
    public BeatManager BeatManager;

    int temp = 0;

    void Update()
    {
        temp += 1;
        if (temp > 30)
        {
            if (!event_soft_lock.Play)
            {
                일시정지Canvas.volume = GameManager.MainVolume;

                if (GameManager.SoundRestart && !GameManager.Boss)
                {
                    SoundManager.StopAll(SoundType.BGM, false);
                    GameManager.SoundRestart = false;

                    GameManager.Timer = 0;
                    GameManager.CurrentBeat = 0;
                    BeatManager.NextBeatRestart();

                    if (GameManager.Map == 0)
                        SoundManager.PlayBGM("Lachesis Dance", true, 0.6f, 1, false, false);
                    //SoundManager.PlayBGM8Bit("battle", "8-Bit.battle 8-Bit", true, 0.25f, 1, true);
                }

                if (GameManager.MainMenu && !GameManager.Boss)
                {
                    if (!MainMenu)
                    {
                        SoundManager.StopAll(SoundType.BGM, false);
                        SoundManager.PlayBGM("Altair", true, 0.3f, 1, true, false);

                        //SoundManager.PlayBGM8Bit("joker", "8-Bit.joker 8-Bit", true, 0.25f, 1, true);
                    }
                    MainMenu = true;
                }
                else
                    MainMenu = false;

                if (audioSourceNormal != null && audioSourceBit8 != null)
                {
                    if (GameManager.일시정지)
                    {
                        audioSourceNormal.pitch = 0;
                        audioSourceBit8.pitch = 0;
                    }
                    else
                    {
                        audioSourceNormal.pitch = GameManager.Pitch * GameManager.GameSpeed;
                        audioSourceBit8.pitch = GameManager.Pitch * GameManager.GameSpeed;
                    }

                    //전투
                    if (GameManager.MyTurn)
                    {
                        if (audioSourceBit8.volume >= MaxVol * GameManager.MainVolume)
                            audioSourceBit8.volume = MaxVol * GameManager.MainVolume;
                        else
                            audioSourceBit8.volume += 0.05f * (MaxVol * GameManager.MainVolume);

                        audioSourceNormal.volume -= 0.025f * (MaxVol * GameManager.MainVolume);
                    }
                    else if (!GameManager.MyTurn)
                    {
                        if (audioSourceNormal.volume >= MaxVol * GameManager.MainVolume)
                            audioSourceNormal.volume = MaxVol * GameManager.MainVolume;
                        else
                            audioSourceNormal.volume += 0.05f * (MaxVol * GameManager.MainVolume);

                        if (audioSourceBit8.volume <= 0.75f * (MaxVol * GameManager.MainVolume))
                            audioSourceBit8.volume = 0.75f * (MaxVol * GameManager.MainVolume);
                        else
                            audioSourceBit8.volume -= 0.025f * (MaxVol * GameManager.MainVolume);
                    }

                    if (Input.GetKeyDown(KeyCode.B) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                    {
                        if (GameManager.MyTurn)
                            GameManager.MyTurn = false;
                        else
                            GameManager.MyTurn = true;
                    }
                }
            }
            else
            {
                GameManager.SoundRestart = false;
                MainMenu = false;
            }
        }
    }
}
