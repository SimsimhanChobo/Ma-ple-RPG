using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapleRpgSystem : MonoBehaviour
{
    public GameObject MapleRpg;
    public GameObject Deltarune;

    void Start()
    {
        var obj = FindObjectsOfType<MapleRpgSystem>();

        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);

        Loading.isLoading = true;

        StartCoroutine(ChapterLoading());
    }

    void LateUpdate()
    {
        if (Loading.isLoading)
        {
            MapleRpg.SetActive(false);
            Deltarune.SetActive(false);
        }
        else
        {
            MapleRpg.SetActive(true);
            Deltarune.SetActive(true);
        }
    }

    IEnumerator ChapterLoading()
    {
        yield return null;
        Loading.LoadScene(GameManager.Chapter, GameManager.Chapter, true);
    }
}
