using UnityEngine;

public class PlayerLerpMove : MonoBehaviour
{
    public Vector3 target;
    public Quaternion target2;
    public GameObject Player판정;
    public float Timer = 0;

    public GameObject PlayerMinecraftSkin;

    void Awake() => SkinRotation.PlayerObject = PlayerMinecraftSkin;

    void Start() => transform.localPosition = new Vector3(GameManager.PlayerX, GameManager.PlayerY, GameManager.PlayerZ);

    void FixedUpdate() => Move();

    void Move()
    {
        if (!GameManager.Pause || GameManager.isAction || GameManager.PlayerHP <= 0.0001f)
        {
            Timer += Time.deltaTime;
            if (Timer >= 0)
            {
                Timer = 0;

                target = Player판정.transform.localPosition;
                target2 = Player판정.transform.localRotation;
            }

            if (GameManager.PlayerLerpMove == 0)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.2f);
                if (GameManager.PlayerHP > 0.0001f)
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, target2, 0.2f);
            }
            else if (GameManager.PlayerLerpMove == 1)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.4f);
                if (GameManager.PlayerHP > 0.0001f)
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, target2, 0.4f);
            }
            else if (GameManager.PlayerLerpMove == 2)
            {
                transform.localPosition = target;
                if (GameManager.PlayerHP > 0.0001f)
                    transform.localRotation = target2;
            }
        }
    }
}
