using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    Rigidbody2D rigid;
    EntitySetting entitySetting;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        entitySetting = GetComponent<EntitySetting>();
    }

    void FixedUpdate()
    {
        if (!GameManager.일시정지)
        {
            transform.LookAt(Player.player.transform);
            transform.localEulerAngles = new Vector2(0, transform.localEulerAngles.y);

            RaycastHit2D Jump = Physics2D.Raycast(transform.position, transform.forward, 0.7f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Water", "Glass"));
            RaycastHit2D Jump2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.9f), transform.forward, 0.7f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));
            if (rigid.bodyType == RigidbodyType2D.Dynamic)
            {
                rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(entitySetting.EntitySpeed * transform.forward.x, rigid.velocity.y), 0.1f);

                if (Jump.collider != null && Jump2.collider == null && entitySetting.Jump.collider != null && entitySetting.Water.collider == null)
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
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + (-0.4f * entitySetting.ColliderSizeY)), new Vector2(0.7f * entitySetting.ColliderSizeX * transform.forward.x, 0), new Color(0, 1, 1));
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + (0.1f * entitySetting.ColliderSizeY)), new Vector2(0.7f * entitySetting.ColliderSizeX * transform.forward.x, 0), new Color(0, 1, 1));

            RaycastHit2D AutoJump = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + (-0.4f * entitySetting.ColliderSizeY)), new Vector2(0.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), 0.7f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));
            RaycastHit2D AutoJump2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + (0.1f * entitySetting.ColliderSizeY)), new Vector2(0.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), 0.7f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs", "Glass"));

            if (AutoJump.collider != null && AutoJump2.collider == null && entitySetting.FallDamage4 && entitySetting.jump)
            {
                while (AutoJump.collider != null)
                {
                    AutoJump = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + -0.4f * entitySetting.ColliderSizeY), new Vector2(0.5f * entitySetting.ColliderSizeX * transform.forward.x, 0), 0.7f * entitySetting.ColliderSizeX, LayerMask.GetMask("Map", "Stairs"));
                    rigid.position = new Vector2(rigid.position.x, rigid.position.y + 0.2f);
                    rigid.velocity = new Vector2(entitySetting.EntitySpeed * transform.forward.x * 1.5f, rigid.velocity.y);
                }
            }*/

            transform.localEulerAngles = Vector2.zero;
        }
    }
}
