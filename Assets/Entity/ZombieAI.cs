using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject Skin;

    Rigidbody2D rigid;
    EntitySetting entitySetting;

    float flipX = 0;
    float MoveAniTimer;
    bool MoveB;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        entitySetting = GetComponent<EntitySetting>();
    }

    void Update()
    {
        transform.LookAt(Player.player.transform);
        transform.localEulerAngles = new Vector2(0, transform.localEulerAngles.y);

        if (transform.forward.x >= 1)
            flipX = 1;

        if (transform.forward.x <= -1)
            flipX = -1;

        //애니메이션
        if (!GameManager.Pause)
        {
            //애니메이션
            if (MainCamera.Game3D)
            {
                if (flipX == -1 && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation(Skin, "All", new Vector3(0, 90, 0));
                else if ((flipX == 1 || flipX == 0) && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation(Skin, "All", new Vector3(0, -90, 0));
            }
            else
            {
                if (flipX == -1 && (rigid.velocity.x >= 0.05f || rigid.velocity.x <= -0.05f))
                    SkinRotation.skinRotation(Skin, "All", new Vector3(0, 90, 0), true);
                else if ((flipX == 1 || flipX == 0) && ((rigid.velocity.x >= 0.05f || rigid.velocity.x <= -0.05f)))
                    SkinRotation.skinRotation(Skin, "All", new Vector3(0, -90, 0), true);
            }

            if (rigid.velocity.x >= 0.05f || rigid.velocity.x <= -0.05f)
            {
                SkinRotation.skinRotation(Skin, "Left Arm", new Vector3(90f, 0, 0));
                SkinRotation.skinRotation(Skin, "Right Arm", new Vector3(90f, 0, 0));
            }
            else
            {
                SkinRotation.skinRotation(Skin, "Left Arm", Vector2.zero);
                SkinRotation.skinRotation(Skin, "Right Arm", Vector2.zero);
            }

            if (rigid.velocity.x >= 0.05f || rigid.velocity.x <= -0.05f)
            {
                MoveAniTimer += Time.deltaTime;

                if (MoveAniTimer >= 0.3f)
                    if (MoveB)
                    {
                        MoveAniTimer = 0;
                        MoveB = false;
                    }
                    else
                    {
                        MoveAniTimer = 0;
                        MoveB = true;
                    }

                if (MoveB)
                {
                    SkinRotation.skinRotation(Skin, "Left Leg", new Vector3(-90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation(Skin, "Right Leg", new Vector3(90f, 0, 0), false, 0.065f);
                }
                else
                {
                    SkinRotation.skinRotation(Skin, "Left Leg", new Vector3(90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation(Skin, "Right Leg", new Vector3(-90f, 0, 0), false, 0.065f);
                }
            }
            else
            {
                SkinRotation.skinRotation(Skin, "Left Leg", Vector2.zero);
                SkinRotation.skinRotation(Skin, "Right Leg", Vector2.zero);
            }
        }

        transform.localEulerAngles = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (!GameManager.Pause)
        {
            transform.LookAt(Player.player.transform);
            transform.localEulerAngles = new Vector2(0, transform.localEulerAngles.y);

            RaycastHit2D Jump = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.9f) + entitySetting.Collider, transform.forward, 2f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Water", "Glass"));
            RaycastHit2D Jump2 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f) + entitySetting.Collider, transform.forward, 2f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));
            if (rigid.bodyType == RigidbodyType2D.Dynamic)
            {
                rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(entitySetting.EntitySpeed * transform.forward.x, rigid.velocity.y), 0.1f);

                if (Jump.collider != null && Jump2.collider == null && entitySetting.jump && entitySetting.Water.collider == null)
                    rigid.velocity = new Vector2(rigid.velocity.x, entitySetting.EntityJump);

                if (entitySetting.Water.collider != null)
                {
                    rigid.AddForce(new Vector2(0, 0.000045f), ForceMode2D.Impulse);

                    if (rigid.velocity.y < entitySetting.EntityJump * -1 * 0.25f)
                        rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, entitySetting.EntityJump * -1 * 0.4f), 0.1f);

                    if (rigid.velocity.y > entitySetting.EntityJump * 0.4f)
                        rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, entitySetting.EntityJump * 0.4f), 0.1f);
                }
            }

            /*//반 블록 올라가기
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + (-0.4f * entitySetting.ColliderSizeY)) + entitySetting.Collider, new Vector2(1.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), new Color(0, 1, 1));
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + (0.1f * entitySetting.ColliderSizeY)) + entitySetting.Collider, new Vector2(1.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), new Color(0, 1, 1));

            RaycastHit2D AutoJump = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + (-0.4f * entitySetting.ColliderSizeY)) + entitySetting.Collider, new Vector2(1.2f * entitySetting.ColliderSizeX * transform.forward.x, 0), 1.5f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));
            RaycastHit2D AutoJump2 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + (0.1f * entitySetting.ColliderSizeY)) + entitySetting.Collider, new Vector2(1.2f * entitySetting.ColliderSizeX * transform.forward.x, 0), 1.5f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));

            if (AutoJump.collider != null && AutoJump2.collider == null && entitySetting.FallDamage4 && entitySetting.jump)
            {
                while (AutoJump.collider != null)
                {
                    AutoJump = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + -0.4f * entitySetting.ColliderSizeY), new Vector2(1.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), 1.5f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs"));
                    rigid.position = new Vector2(rigid.position.x, rigid.position.y + 0.2f);
                    rigid.velocity = new Vector2(entitySetting.EntitySpeed * transform.forward.x * 1.5f, rigid.velocity.y);
                }
            }

            if (AutoJump.collider != null)
                Debug.Log(AutoJump.collider.gameObject.name);
            if (AutoJump2.collider != null)
                Debug.Log(AutoJump2.collider.gameObject.name);
            if (Jump.collider != null)
                Debug.Log(Jump.collider.gameObject.name);
            if (Jump2.collider != null)
                Debug.Log(Jump2.collider.gameObject.name);*/

            transform.localEulerAngles = Vector2.zero;
        }
    }
}
