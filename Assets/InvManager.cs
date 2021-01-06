using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public GameObject InventoryImage;

    public static bool InventoryShow = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.isAction && !GameManager.일시정지 & GameManager.PlayerHP > 0.0001f && !ChattingManager.ChattingActive)
        {
            if (InventoryShow)
                InventoryShow = false;
            else
                InventoryShow = true;
        }

        if (GameManager.PlayerHP <= 0.0001f || Input.GetKeyDown(KeyCode.Escape))
            InventoryShow = false;

        if (InventoryShow && InventoryImage != null)
            InventoryImage.SetActive(true);
        else if (InventoryImage != null)
            InventoryImage.SetActive(false);
    }
}
