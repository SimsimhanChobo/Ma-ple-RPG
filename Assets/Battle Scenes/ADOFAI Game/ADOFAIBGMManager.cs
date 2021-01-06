using UnityEngine;

public class ADOFAIBGMManager : MonoBehaviour
{
    public bool ADOFAIGameBGMPlay = false;
    public AudioSource audioSource;

    public AudioClip ADanceOfFireAndIce;

    void Update()
    {
        if (!ADOFAIGameBGMPlay)
        {
            if (GameManager.ADOFAIMap == 0)
            {
                audioSource.clip = ADanceOfFireAndIce;
                audioSource.Play();

                GameManager.BPM = 150f;
                GameManager.StartDelay = 0.077f;

                ADOFAIGameBGMPlay = true;
            }
        }
    }
}
