using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject SoundPrefab;
    public GameObject _BGM;
    public GameObject _Sound;

    static GameObject soundPrefab;

    static GameObject soundManager;
    static GameObject BGM;
    static GameObject Sound;

    public static int BGMCount = 0;
    public static int SoundCount = 0;

    [HideInInspector]
    public AudioClip[] BGMLoadAll;

    void OnEnable()
    {
        soundPrefab = SoundPrefab;

        soundManager = gameObject;
        BGM = _BGM;
        Sound = _Sound;

        BGMLoadAll = Resources.LoadAll<AudioClip>("BGM");
    }

    void Update()
    {
        soundManager = gameObject;
        _BGM = BGM;
        _Sound = Sound;
    }

    /// <summary>
    /// Play BGM
    /// </summary>
    public static void PlayBGM(string BGMName, bool Loop, float Vol, float Pitch, bool RhythmPitchUse)
    {
        if (BGMCount < 10)
        {
            BGMCount += 1;

            GameObject BGMObject = Instantiate(soundPrefab, SoundManager.BGM.transform);
            BGMObject.name = "BGM." + BGMName.Replace(".", "/");
            SoundPrefab SoundPrefab = BGMObject.GetComponent<SoundPrefab>();
            SoundPrefab.BGM = true;
            SoundPrefab.RhythmPitchUse = RhythmPitchUse;
            SoundPrefab.Vol = Vol;
            SoundPrefab.Pitch = Pitch;

            AudioSource BGM = BGMObject.GetComponent<AudioSource>();
            BGM.clip = Resources.Load<AudioClip>("BGM/" + BGMName.Replace(".", "/"));
            BGM.loop = Loop;
            BGM.volume = GameManager.MainVolume * Vol;
            if (RhythmPitchUse)
                BGM.pitch = GameManager.Pitch * Pitch * GameManager.GameSpeed;
            else
                BGM.pitch = Pitch * GameManager.GameSpeed;
            BGM.Play();
        }
    }

    /// <summary>
    /// Stop BGM
    /// </summary>
    public static void StopBGM(string SoundBGM)
    {
        BGMCount -= 1;

        Transform[] allChildren = BGM.GetComponentsInChildren<Transform>();

        for (int i = 1; i < allChildren.Length; i++)
            if (allChildren[i].name == "BGM." + SoundBGM.Replace(".", "/"))
                Destroy(allChildren[i].gameObject);
    }

    /// <summary>
    /// Play Sound
    /// </summary>
    public static void PlaySound(string SoundName, float Vol, float Pitch)
    {
        if (SoundCount < 256)
        {
            SoundCount += 1;

            GameObject SoundObject = Instantiate(soundPrefab, SoundManager.Sound.transform);
            SoundObject.name = "Sound." + SoundName.Replace(".", "/");
            SoundPrefab SoundPrefab = SoundObject.GetComponent<SoundPrefab>();
            SoundPrefab.Vol = Vol;
            SoundPrefab.Pitch = Pitch;

            AudioSource Sound = SoundObject.GetComponent<AudioSource>();
            Sound.clip = Resources.Load<AudioClip>("Sound/" + SoundName.Replace(".", "/"));
            Sound.volume = GameManager.MainVolume * Vol;
            Sound.pitch = Pitch * GameManager.GameSpeed;
            Sound.Play();
        }
    }

    /// <summary>
    /// Stop Sound
    /// </summary>
    public static void StopSound(string SoundName)
    {
        SoundCount -= 1;

        Transform[] allChildren = Sound.GetComponentsInChildren<Transform>();

        for (int i = 1; i < allChildren.Length; i++)
            if (allChildren[i].name == "Sound." + SoundName.Replace(".", "/"))
                Destroy(allChildren[i].gameObject);
    }

    public static void StopAll(SoundType soundType)
    {
        if (soundType == SoundType.All)
        {
            Transform[] allChildren = soundManager.GetComponentsInChildren<Transform>();

            for (int i = 1; i < allChildren.Length; i++)
                if (soundManager != allChildren[i])
                    Destroy(allChildren[i].gameObject);
        }
        else if (soundType == SoundType.BGM)
        {
            Transform[] allChildren = BGM.GetComponentsInChildren<Transform>();

            for (int i = 1; i < allChildren.Length; i++)
                if (soundManager != allChildren[i])
                    Destroy(allChildren[i].gameObject);
        }
        else if (soundType == SoundType.Sound)
        {
            Transform[] allChildren = Sound.GetComponentsInChildren<Transform>();

            for (int i = 1; i < allChildren.Length; i++)
                if (soundManager != allChildren[i])
                    Destroy(allChildren[i].gameObject);
        }
    }

    public static void PlayBGM8Bit(string BGMName, string BGM8BitName, bool Loop, float Vol, float Pitch, bool RhythmPitchUse)
    {
        if (BGMCount < 10)
        {
            BGMCount += 1;

            GameObject BGMObject = Instantiate(soundPrefab, SoundManager.BGM.transform);
            BGMObject.name = "BGM 8-Bit." + BGMName.Replace(".", "/");
            BGMManager.MaxVol = Vol;
            SoundPrefab SoundPrefab = BGMObject.GetComponent<SoundPrefab>();
            SoundPrefab.BGM = true;
            SoundPrefab.RhythmPitchUse = RhythmPitchUse;
            SoundPrefab.Pitch = Pitch;
            SoundPrefab.Bit8 = true;

            AudioSource BGM = BGMObject.GetComponent<AudioSource>();
            BGM.clip = Resources.Load<AudioClip>("BGM/" + BGMName.Replace(".", "/"));
            BGM.loop = Loop;
            BGM.volume = GameManager.MainVolume * Vol;
            if (RhythmPitchUse)
                BGM.pitch = GameManager.Pitch * Pitch * GameManager.GameSpeed;
            else
                BGM.pitch = Pitch * GameManager.GameSpeed;
            BGM.Play();
            BGMManager.audioSourceNormal = BGM;

            BGMObject = Instantiate(soundPrefab, SoundManager.BGM.transform);
            BGMObject.name = "BGM 8-Bit." + BGM8BitName.Replace(".", "/");
            SoundPrefab = BGMObject.GetComponent<SoundPrefab>();
            SoundPrefab.BGM = true;
            SoundPrefab.RhythmPitchUse = RhythmPitchUse;
            SoundPrefab.Pitch = Pitch;
            SoundPrefab.Bit8 = true;

            BGM = BGMObject.GetComponent<AudioSource>();
            BGM.clip = Resources.Load<AudioClip>("BGM/" + BGM8BitName.Replace(".", "/"));
            BGM.loop = Loop;
            BGM.volume = GameManager.MainVolume * Vol;
            if (RhythmPitchUse)
                BGM.pitch = GameManager.Pitch * Pitch * GameManager.GameSpeed;
            else
                BGM.pitch = Pitch * GameManager.GameSpeed;
            BGM.Play();
            BGMManager.audioSourceBit8 = BGM;
        }
    }
}

public enum SoundType
{
    All,
    BGM,
    Sound,
}