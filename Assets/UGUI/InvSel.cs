using UnityEngine;

public class InvSel : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = new Vector2(20 * GameManager.PlayerInvCannes, 0);
    }
}
