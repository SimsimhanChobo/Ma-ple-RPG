using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBossAI : MonoBehaviour
{
    EntitySetting entitySetting;

    bool die = false;

    void Start() => BossStart();

    void BossStart()
    {
        entitySetting = GetComponent<EntitySetting>();
        entitySetting.MaxHP = 20;
        entitySetting.HP = 20;
        SoundManager.StopAll(SoundType.BGM, true);
        SoundManager.PlayBGM("Start Scourge of The Universe", false, 0.15f, 1, true, true);
        GameManager.Timer = 0;
        GameManager.CurrentBeat = 0;
        GameManager.BPM = 190;
        GameManager.StartDelay = 0.164f;
        BeatManager.beatManager.NextBeatRestart();

        Invoke("BossStart2", 22.75f);
    }

    void BossStart2()
    {
        SoundManager.PlayBGM("Scourge of The Universe", true, 0.15f, 1, true, false);
        GameManager.Timer = 0;
        GameManager.CurrentBeat = 0;
        GameManager.BPM = 190;
        GameManager.StartDelay = 0.164f;
        BeatManager.beatManager.NextBeatRestart();
    }

    void BossStart3()
    {
        SoundManager.StopAll(SoundType.BGM, true);
        SoundManager.PlayBGM("Start Universal Collapse", false, 0.15f, 1, true, true);
        GameManager.Timer = 0;
        GameManager.CurrentBeat = 0;
        GameManager.BPM = 200;
        GameManager.StartDelay = 0.05f;
        BeatManager.beatManager.NextBeatRestart();

        Invoke("BossStart4", 9.62f);
    }

    void BossStart4()
    {
        SoundManager.PlayBGM("Universal Collapse", true, 0.15f, 1, true, false);
        GameManager.Timer = 0;
        GameManager.CurrentBeat = 0;
        GameManager.BPM = 200;
        GameManager.StartDelay = 0.05f;
        BeatManager.beatManager.NextBeatRestart();
    }

    public void PlayerDie()
    {
        CancelInvoke();
        entitySetting.HP = 0.00000001f;
        GameManager.Boss = false;
    }

    public void PlayerRespawn()
    {
        CancelInvoke();
        GameManager.Boss = true;
        BossStart();
    }

    public void Die()
    {
        if (!die)
        {
            die = true;
            CancelInvoke();
            entitySetting.MaxHP *= 2;
            entitySetting.DieCancel();
            BossStart3();
        }
        else
        {
            CancelInvoke();
            GameManager.Boss = false;
            SoundManager.StopAll(SoundType.BGM, false);
            GameManager.SoundRestart = true;
        }
    }
}
