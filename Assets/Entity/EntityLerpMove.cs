using UnityEngine;

public class EntityLerpMove : MonoBehaviour
{
    public Vector3 vector3 = Vector3.zero;
    public Vector3 target;
    public float Timer = 0;

    void FixedUpdate() => Move();

    void Move()
    {
        if (!GameManager.일시정지)
        {
            Timer += Time.deltaTime;
            if (Timer >= 0)
            {
                Timer = 0;

                target = transform.parent.position;
                target.y -= 0.5f;
            }

            if (GameManager.PlayerLerpMove == 0)
                vector3 = Vector3.Lerp(vector3, target, 0.2f);
            else if (GameManager.PlayerLerpMove == 1)
                vector3 = Vector3.Lerp(vector3, target, 0.4f);
            else if (GameManager.PlayerLerpMove == 2)
                vector3 = target;

            transform.position = vector3;
        }
    }
}
