using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySetting : MonoBehaviour
{
    public List<MobType> mobType;

    public Slider HPSlider;
    public GameObject EntitySkin;

    public float MaxHP;
    public float HP;

    public float AV;

    public float MaxAR;
    public float AR;

    public float DamageMaterialTimer;

    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        HP = MaxHP;

        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        HPSlider.maxValue = MaxHP;
        HPSlider.value = Mathf.Lerp(HPSlider.value, HP, 0.1f * (60 * Time.deltaTime));

        if (HP > MaxHP)
            HP = MaxHP;

        if (HP < 0)
            HP = 0;

        if (DamageMaterialTimer <= 0)
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform child = allChildren[i];
                Renderer Renderer = child.GetComponent<Renderer>();

                if (Renderer != null)
                {
                    Renderer.material.color = new Color(1, 1, 1);
                    Renderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
                }
            }

            DamageMaterialTimer = 0;
        }
        else
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform child = allChildren[i];
                Renderer Renderer = child.GetComponent<Renderer>();

                if (Renderer != null)
                {
                    Renderer.material.color = new Color(1, 0.5f, 0.5f);
                    Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
                }
            }

            DamageMaterialTimer -= Time.deltaTime;
        }

        if (HP == 0)
        {
            rigid.bodyType = RigidbodyType2D.Static;
            rigid.velocity = Vector2.zero;
            boxCollider2D.isTrigger = true;

            Transform[] allChildren = GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Transform child = allChildren[i];
                Renderer Renderer = child.GetComponent<Renderer>();

                if (Renderer != null)
                {
                    Renderer.material.color = new Color(1, 0.5f, 0.5f);
                    Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
                }
            }

            Quaternion target = Quaternion.Euler(0, 0, 90);
            EntitySkin.transform.localRotation = Quaternion.Lerp(EntitySkin.transform.localRotation, target, 0.1f * (60 * Time.deltaTime));

            if (EntitySkin.transform.localEulerAngles.z >= 88.5f || EntitySkin.transform.localEulerAngles.z <= -88.5f)
                Destroy(gameObject);
        }
    }

    public void Damage(float damage, bool set, int type)
    {
        if (HP > 0.0001F)
        {
            if (HP < 0)
                HP = 0;

            //무적 시간
            if (DamageMaterialTimer > 0 + Time.deltaTime && ((damage < HP && set) || (HP - damage < HP && !set)))
                HP += damage;
            else if (DamageMaterialTimer <= 0 + Time.deltaTime && ((damage < HP && set) || (HP - damage < HP && !set)))
            {
                DamageMaterialTimer = 0.5f;

                if (type == 0)
                {
                    int r = Random.Range(1, 4);

                    if (r == 1)
                        SoundManager.PlaySound("damage.hit1", 1, 1);
                    else if (r == 2)
                        SoundManager.PlaySound("damage.hit2", 1, 1);
                    else if (r == 3)
                        SoundManager.PlaySound("damage.hit3", 1, 1);
                }
                else if (type == 1)
                {
                    int r = Random.Range(1, 5);

                    if (r == 1)
                        SoundManager.PlaySound("entity.player.hurt.drown1", 1, 1);
                    else if (r == 2)
                        SoundManager.PlaySound("entity.player.hurt.drown2", 1, 1);
                    else if (r == 3)
                        SoundManager.PlaySound("entity.player.hurt.drown3", 1, 1);
                    else if (r == 4)
                        SoundManager.PlaySound("entity.player.hurt.drown4", 1, 1);
                }
                else if (type == 2)
                {
                    int r = Random.Range(1, 4);

                    if (r == 1)
                        SoundManager.PlaySound("entity.player.hurt.fire_hurt1", 1, 1);
                    else if (r == 2)
                        SoundManager.PlaySound("entity.player.hurt.fire_hurt2", 1, 1);
                    else if (r == 3)
                        SoundManager.PlaySound("entity.player.hurt.fire_hurt3", 1, 1);
                }
                else if (type == 4)
                {
                    int r = Random.Range(1, 3);

                    if (r == 1)
                        SoundManager.PlaySound("entity.player.hurt.berrybush_hurt1", 1, 1);
                    else if (r == 2)
                        SoundManager.PlaySound("entity.player.hurt.berrybush_hurt2", 1, 1);
                }
            }

            if (set)
                HP = damage;
            else
                HP -= damage;
        }
    }
}

public enum MobType
{
    None,
    Boss,
    Slime,
    Undead,
    Zombie,
    Skeleton
}
