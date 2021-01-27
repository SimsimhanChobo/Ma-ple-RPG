using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySetting : MonoBehaviour
{
    public List<MobType> mobType;

    public GameObject prefab;
    public Canvas canvas;
    public Slider HPSlider;
    public GameObject EntitySkin;
    public GameObject DIEParticle;

    public float ColliderX;
    public float ColliderY;

    public float MaxHP;
    public float HP;

    public float AV;

    public float MaxAir;
    public float Air;

    public float DamageMaterialTimer;
    public float DieTimer;

    public float MaxSpeed;
    public float MaxJump;

    public float EntitySpeed;
    public float EntityJump;

    public float FireTimer;
    public float FireTimer2;

    public float SuffocatTimer;

    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;

    public bool jump = false;

    public float FallDamage;
    public int FallDamage2;
    public float FallDamage3;
    public bool FallDamage4;

    public RaycastHit2D Jump;
    public RaycastHit2D Water;
    public RaycastHit2D Fire;
    public RaycastHit2D Suffocat;

    void Start()
    {
        HP = MaxHP;

        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (!GameManager.일시정지)
        {
            boxCollider2D.size = new Vector2(0.975f * ColliderX, 0.975f * ColliderY);

            HPSlider.maxValue = MaxHP;
            HPSlider.value = Mathf.Lerp(HPSlider.value, HP, 0.1f * (60 * Time.deltaTime));

            if (HP > MaxHP)
                HP = MaxHP;

            if (HP < 0)
                HP = 0;

            //점프 레이캐스트
            Jump = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y), new Vector3(0, -0.7f, 0), 1.1f * ColliderY, LayerMask.GetMask("Map", "Stairs", "Glass"));
            if (Jump.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y), new Vector3(0, -0.7f, 0), new Color(1, 0, 0));
                jump = true;
            }
            else
                jump = false;

            //Water
            Water = Physics2D.Raycast(transform.position, new Vector2(0, 0.01f), 0.01f, LayerMask.GetMask("Water"));

            //AIR
            if (Water.collider != null)
            {
                Air -= 1 * (20 * Time.deltaTime);

                if (Air <= -20)
                {
                    Damage(2, false, 1, false);
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

                    if (Renderer != null && child.name != "DIE Particle")
                    {
                        Renderer.material.color = new Color(1, 0.5f, 0.5f);
                        Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
                    }
                }

                DamageMaterialTimer -= Time.deltaTime;
            }

            //불 데미지
            Fire = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y), new Vector3(0, 0.01f, 0), 1f, LayerMask.GetMask("Fire"));

            if (Fire.collider != null)
            {
                FireTimer = 10;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 0.5f)
                {
                    Damage(1, false, 2, false);
                    FireTimer2 = 0;
                }
            }
            else if (FireTimer > 0)
            {
                FireTimer -= Time.deltaTime;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 1f)
                {
                    Damage(1, false, 2, false);
                    FireTimer2 = 0;
                }
            }
            else
            {
                FireTimer = 0;
                FireTimer2 = 1;
            }

            //질식
            Suffocat = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y), new Vector3(0, 0.5f, 0), 0.5f * ColliderY, LayerMask.GetMask("Map"));
            if (Suffocat.collider)
            {
                SuffocatTimer += Time.deltaTime;
                if (SuffocatTimer >= 0.5f)
                {
                    Damage(1, false, 0, false);
                    SuffocatTimer = 0;
                }
            }
            else
                SuffocatTimer = 0;

            //세계 밖
            if (transform.position.y <= -50 && GameManager.PlayerHP > 0.0001f)
                Damage(0.18f * GameManager.PlayerMaxHP, false, 0, false);

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
                    Damage(FallDamage - 3, false, 0, false);

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

    public void Damage(float damage, bool set, int type, bool PlayerAttack)
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
                if (PlayerAttack)
                {
                    GameObject temp = Instantiate(prefab, transform.position, transform.rotation);
                    temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (Mathf.Round(damage * 10) * 0.1f) + "";
                }

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
