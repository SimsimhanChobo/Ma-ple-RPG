using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapleRpgSystemIsLoding : MonoBehaviour
{
    void Awake()
    {
        if (GameManager.gameManager == null)
            Loading.LoadScene("마플 RPG System", "마플 RPG", true);
    }
}
