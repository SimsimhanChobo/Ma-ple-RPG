using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPrefab : MonoBehaviour
{
    public bool BGM = false;
    public bool Bit8 = false;
    public bool RhythmPitchUse = false;
    public float Vol = 1;
    public float Pitch = 1;

    public bool PadeIn = false;
    public bool PadeOut = false;

    AudioSource audioSource;

    void OnEnable() => audioSource = GetComponent<AudioSource>();

    void Update()
    {
        if (!Bit8)
        {
            if (!PadeIn && !PadeOut)
                audioSource.volume = GameManager.MainVolume * Vol;
            else if (audioSource.volume < GameManager.MainVolume * Vol && PadeIn && !PadeOut)
                audioSource.volume += 0.0075f * GameManager.MainVolume * Vol * 60 * Time.deltaTime;
            else if (audioSource.volume > GameManager.MainVolume * Vol && PadeIn && !PadeOut)
                audioSource.volume = GameManager.MainVolume * Vol;
            else if (audioSource.volume > 0 && PadeOut)
                audioSource.volume -= 0.0075f * GameManager.MainVolume * Vol * 60 * Time.deltaTime;
            else if (audioSource.volume <= 0)
                Destroy(gameObject);
        }

        if (RhythmPitchUse)
            audioSource.pitch = GameManager.Pitch * Pitch * GameManager.GameSpeed;
        else
            audioSource.pitch = Pitch * GameManager.GameSpeed;

        if (!GameManager.일시정지)
            audioSource.UnPause();
        else if (GameManager.PlayerHP > 0.0001f)
            audioSource.Pause();
        else if (BGM)
            audioSource.Pause();

        if (!audioSource.isPlaying && !GameManager.일시정지 && GameManager.PlayerHP > 0.0001f)
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (BGM)
            SoundManager.BGMCount -= 1;
        else
            SoundManager.SoundCount -= 1;
    }
}
