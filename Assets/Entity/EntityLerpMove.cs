using UnityEngine;

public class EntityLerpMove : MonoBehaviour
{
    public Vector3 vector3 = Vector3.zero;
    public Vector3 target;
    public float Timer = 0;

    public Vector3 Offset;

    void Update()
    {
        Timer += Time.unscaledDeltaTime * GameManager.GameSpeed;
        if (Timer >= 0)
        {
            Timer = 0;

            target = transform.parent.position + Offset;
        }
    }

    void FixedUpdate() => Move();

    void Move()
    {
        if (GameManager.PlayerLerpMove == 0)
            vector3 = Vector3.Lerp(vector3, target, 0.2f * 60 * Time.unscaledDeltaTime);
        else if (GameManager.PlayerLerpMove == 1)
            vector3 = Vector3.Lerp(vector3, target, 0.4f * 60 * Time.unscaledDeltaTime);
        else if (GameManager.PlayerLerpMove == 2)
            vector3 = target;

        transform.position = vector3;
    }
}
