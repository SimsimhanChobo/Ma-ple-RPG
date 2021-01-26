using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public GameObject mainCamera;

    void FixedUpdate()
    {
        // 카메라 이동
        if (GameManager.MinecraftGame && GameManager.PlayerHP > 0.0001f)
        {
            transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z + 14 - 28);
            transform.localRotation = mainCamera.transform.localRotation;
        }
    }
}
