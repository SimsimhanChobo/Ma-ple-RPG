using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public GameObject InventoryImage;

    public static bool InventoryShow = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InventoryShow)
                InventoryShow = false;
            else
                InventoryShow = true;
        }

        if (InventoryShow && InventoryImage != null)
            InventoryImage.SetActive(true);
        else if (InventoryImage != null)
            InventoryImage.SetActive(false);
    }
}
