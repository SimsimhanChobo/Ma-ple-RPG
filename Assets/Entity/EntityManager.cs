using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    bool tempBoss = false;

    void Update()
    {
        if (tempBoss != GameManager.Boss && !GameManager.Boss)
        {
            foreach (Transform child in transform)
            {
                EntitySetting entitySetting = child.GetComponent<EntitySetting>();
                if (entitySetting != null)
                {
                    for (int ii = 0; ii < entitySetting.mobType.Count; ii++)
                    {
                        if (entitySetting.mobType[ii] == MobType.Boss)
                        {
                            child.gameObject.SetActive(true);
                            return;
                        }
                    }
                }
            }
        }

        tempBoss = GameManager.Boss;
    }
}
