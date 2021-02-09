using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySetting : MonoBehaviour
{
    public static EntitySetting entitySetting;

    public List<MobType> mobType;

    public GameObject prefab;
    public Slider HPSlider;
    public GameObject EntitySkin;
    public GameObject DIEParticle;

    public string EntityName;

    public float ColliderSizeX = 1;
    public float ColliderSizeY = 1;

    public float RealColliderSizeX = 1;
    public float RealColliderSizeY = 1;

    public Vector3 Collider;

    public float MaxHP = 100;
    public float HP = 100;

    public bool Invincible = false;

    public float AV = 100;

    public float MaxAir = 300;
    public float Air = 300;

    public float DamageMaterialTimer = 0;
    public bool DamageMaterialTimerTemp = false;
    public float DieTimer = 0;

    public float MaxSpeed = 3.55f;
    public float MaxJump = 8.17f;

    public float EntitySpeed = 3.55f;
    public float EntityJump = 8.17f;

    public float FireTimer = 0;
    public float FireTimer2 = 0;

    public float SuffocatTimer = 0;

    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;

    public bool jump = false;

    public float FallDamage = 0;
    public int FallDamage2 = 0;
    public float FallDamage3 = 0;
    public bool FallDamage4 = false;

    public RaycastHit2D Jump;
    public RaycastHit2D Water;
    public RaycastHit2D Fire;
    public RaycastHit2D Suffocat;

    bool Boss = false;

    void OnEnable()
    {
        entitySetting = GetComponent<EntitySetting>();

        for (int i = 0; i < mobType.Count; i++)
            if (mobType[i] == MobType.Boss)
            {
                if (GameManager.Boss)
                    gameObject.SetActive(false);

                Boss = true;
                GameManager.Boss = true;
                HPSlider = GameManager.gameManager.BossHPBar;
            }

        HP = MaxHP;

        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }

    void Update()
    {
        if (!GameManager.일시정지 || (Boss && GameManager.PlayerHP <= 0.0001f))
        {
            if (HPSlider != null)
            {
                HPSlider.maxValue = MaxHP;
                HPSlider.value = Mathf.Lerp(HPSlider.value, HP, 0.1f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed));
            }

            if (HP > MaxHP)
                HP = MaxHP;

            if (HP < 0)
                HP = 0;
        }

        if (Boss)
        {
            GameManager.BossName = gameObject.name;
            GameManager.BossMaxHP = MaxHP;
            GameManager.BossHP = HP;
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.일시정지)
        {
            boxCollider2D.size = new Vector2(0.975f * RealColliderSizeX, 0.975f * RealColliderSizeY);

            //점프 레이캐스트
            Jump = Physics2D.Raycast(transform.position + Collider, new Vector3(0, -0.7f, 0), 1.1f * ColliderSizeY, LayerMask.GetMask("Map", "Stairs", "Glass"));
            if (Jump.collider != null)
            {
                Debug.DrawRay(transform.position + Collider, new Vector3(0, -0.7f, 0), new Color(1, 0, 0));
                jump = true;
            }
            else
                jump = false;

            //Water
            Water = Physics2D.Raycast(transform.position + Collider, new Vector2(0, 0.01f), 0.01f, LayerMask.GetMask("Water"));

            //AIR
            if (Water.collider != null)
            {
                FireTimer = 0;
                FireTimer2 = 1;

                Air -= 1 * (20 * Time.deltaTime);

                if (Air <= -20)
                {
                    Damage(2, false, 1, false, false);
                    Air = 0;
                }

            }
            else
            {
                Air += 4 * (20 * Time.deltaTime);
                if (Air >= 300)
                    Air = 300;
            }

            if (DamageMaterialTimer <= 0)
            {
                if (!DamageMaterialTimerTemp)
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
                }

                DamageMaterialTimerTemp = true;
                DamageMaterialTimer = 0;
            }
            else
            {
                if (DamageMaterialTimerTemp)
                {
                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform child = allChildren[i];
                        Renderer Renderer = child.GetComponent<Renderer>();

                        if (Renderer != null && child.name != "DIE Particle")
                        {
                            Renderer.material.color = new Color(1, 0.5f, 0.5f);
                            Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
                        }
                    }
                }

                DamageMaterialTimerTemp = false;
                DamageMaterialTimer -= Time.deltaTime;
            }

            //불 데미지
            Fire = Physics2D.Raycast(transform.position + (Collider * 0.5f), new Vector3(0, 0.01f, 0), 0.01f, LayerMask.GetMask("Fire"));

            if (Fire.collider != null)
            {
                FireTimer = 10;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 0.5f)
                {
                    Damage(1, false, 2, false, false);
                    FireTimer2 = 0;
                }
            }
            else if (FireTimer > 0)
            {
                FireTimer -= Time.deltaTime;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 1f)
                {
                    Damage(1, false, 2, false, false);
                    FireTimer2 = 0;
                }
            }
            else
            {
                FireTimer = 0;
                FireTimer2 = 1;
            }

            //질식
            Suffocat = Physics2D.Raycast(transform.position + Collider, new Vector3(0, 0.5f, 0), 0.5f * ColliderSizeY, LayerMask.GetMask("Map"));
            if (Suffocat.collider)
            {
                SuffocatTimer += Time.deltaTime;
                if (SuffocatTimer >= 0.5f)
                {
                    Damage(1, false, 0, false, false);
                    SuffocatTimer = 0;
                }
            }
            else
                SuffocatTimer = 0;

            //세계 밖
            if (transform.position.y <= -50)
                Damage(3.6f, false, 0, false, false);

            //낙뎀
            if (!jump)
            {
                if (rigid.velocity.y >= 0)
                    FallDamage3 = transform.position.y;

                FallDamage4 = false;

                if (FallDamage < transform.position.y - FallDamage3)
                {
                    int i = 0;
                    while (FallDamage < transform.position.y - FallDamage3)
                    {
                        FallDamage--;
                        FallDamage2++;
                        i++;
                        if (i >= 1000)
                            break;
                    }
                }
                if (FallDamage2 > transform.position.y - FallDamage3)
                {
                    int i = 0;
                    while (FallDamage2 > transform.position.y - FallDamage3)
                    {
                        FallDamage++;
                        FallDamage2--;
                        i++;
                        if (i >= 1000)
                            break;
                    }
                }
            }
            else
            {
                FallDamage2 = 0;
                FallDamage3 = transform.position.y;
            }

            if (!FallDamage4 && jump && Water.collider == null)
            {
                if (FallDamage > 3)
                    Damage(FallDamage - 3, false, 0, false, false);

                FallDamage = 0;
                FallDamage4 = true;
            }
            if (Water.collider != null)
            {
                FallDamage = 0;
                FallDamage2 = 0;
                FallDamage3 = transform.position.y;
                FallDamage4 = true;
            }

            if (HP == 0)
            {
                rigid.bodyType = RigidbodyType2D.Static;
                boxCollider2D.isTrigger = true;

                Transform[] allChildren = GetComponentsInChildren<Transform>();
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Transform child = allChildren[i];
                    Renderer Renderer = child.GetComponent<Renderer>();

                    if (Renderer != null && child.name != "DIE Particle")
                    {
                        Renderer.material.color = new Color(1, 0.5f, 0.5f);
                        Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
                    }
                }

                Quaternion target = Quaternion.Euler(0, 0, 90);
                EntitySkin.transform.localRotation = Quaternion.Lerp(EntitySkin.transform.localRotation, target, 0.1f * (60 * Time.deltaTime));

                if (EntitySkin.transform.localEulerAngles.z >= 88.5f || EntitySkin.transform.localEulerAngles.z <= -88.5f)
                {
                    for (int i = 0; i < allChildren.Length; i++)
                    {
                        Transform child = allChildren[i];
                        Renderer Renderer = child.GetComponent<Renderer>();

                        if (Renderer != null && child.name != "DIE Particle")
                            Renderer.enabled = false;
                    }

                    boxCollider2D.enabled = false;
                    if (HPSlider != null)
                        HPSlider.gameObject.SetActive(false);
                    DIEParticle.SetActive(true);
                    DieTimer += Time.deltaTime;
                }

                if (DieTimer >= 3)
                    Destroy(gameObject);
            }

            if (Water.collider != null)
            {
                EntitySpeed = MaxSpeed * 0.4f;
                EntityJump = MaxJump;
                rigid.gravityScale = 1;
            }
            else
            {
                EntitySpeed = MaxSpeed;
                EntityJump = MaxJump;
                rigid.gravityScale = 3;
            }

            transform.localEulerAngles = new Vector2(0, transform.localEulerAngles.y);
        }
    }

    public void Damage(float damage, bool set, int type, bool PlayerAttack, bool Critical)
    {
        if (Invincible)
            return;

        bool Miss = false;

        if (Random.Range(0, 101) <= 15 && PlayerAttack)
        {
            Miss = true;
            if (GameManager.MainMenu)
                GameManager.PlayerHGExhaustionLevel -= 0.1f;
        }

        if (HP > 0.0001F)
        {
            //무적 시간
            if (DamageMaterialTimer > 0 + Time.deltaTime && ((damage < HP && set) || (HP - damage < HP && !set)) && !Miss)
                HP += damage;
            else if (DamageMaterialTimer <= 0 + Time.deltaTime && ((damage < HP && set) || (HP - damage < HP && !set)))
            {
                if (PlayerAttack)
                {
                    GameObject temp = Instantiate(prefab, transform.position, transform.rotation);
                    if (!Miss && !Critical)
                        temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (Mathf.Round(damage * 10) * 0.1f) + "";
                    else if (!Miss && Critical)
                    {
                        temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (Mathf.Round(damage * 10) * 0.1f) + "";
                        temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1);
                        temp.transform.GetChild(0).GetChild(0).GetComponents<Outline>()[0].effectColor = new Color(1, 0, 0);
                        temp.transform.GetChild(0).GetChild(0).GetComponents<Outline>()[1].effectColor = new Color(1, 0, 0);
                    }
                    else
                    {
                        temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Miss";
                        temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0);
                        temp.transform.GetChild(0).GetChild(0).GetComponents<Outline>()[0].effectColor = new Color(1, 1, 1);
                        temp.transform.GetChild(0).GetChild(0).GetComponents<Outline>()[1].effectColor = new Color(1, 1, 1);
                    }
                }

                if (!Miss)
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
            }

            if (!Miss)
            {
                if (set)
                    HP = damage;
                else
                    HP -= damage;
            }

            if (HP <= 0)
            {
                HP = 0;
                SendMessage("Die");
            }
        }
    }

    public void DieCancel()
    {
        HP = MaxHP;
        DamageMaterialTimer = 0;
        DamageMaterialTimerTemp = false;
        DieTimer = 0;
    }

    public void Die()
    {
        //SendMessage Error
    }

    public void PlayerDie()
    {
        //SendMessage Error
    }

    public void PlayerRespawn()
    {
        //SendMessage Error
    }
}

public enum MobType
{
    None,
    Boss,
    Npc,
    Slime,
    Undead,
    Zombie,
    Skeleton
}