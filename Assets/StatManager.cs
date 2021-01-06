using UnityEngine;

public class StatManager : MonoBehaviour
{
    void Update()
    {
        GameManager.PlayerAS = 0.2f;
        
        if (GameManager.PlayerInvItem == "wooden_sword")
            GameManager.PlayerAS = 0.6f;
    }
}
