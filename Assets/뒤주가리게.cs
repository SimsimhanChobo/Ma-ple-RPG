using UnityEngine;

public class 뒤주가리게 : MonoBehaviour
{
    new public GameObject gameObject;

    void Update()
    {
        if (GameManager.PlayerHP > 0.0001f)
        {
            if (event_soft_lock.Play)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    }
}
