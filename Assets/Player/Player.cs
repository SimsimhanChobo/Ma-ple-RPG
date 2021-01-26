using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("변수와 스크립트, 오브젝트, 컴포넌트")]
    [Tooltip("Tooltip is Header")]
    bool jump = false;
    bool Attack = false;
    float Timer = 0;
    int flipX = 0;
    public static GameObject scanNPC;

    public GameObject _scanNPC;
    Rigidbody2D _Rigidbody2D;
    public static Rigidbody2D rigid;
    public GameObject particlesystem;
    public GameObject mainCamera;
    public Image GameOverBackground;
    public GameObject GameOverBackground2;
    public GameObject GameOverManager;
    public static bool GameOverRotationSuc = false;

    public float time = 0;
    bool iiii = false;

    public static int FallDamage;
    int FallDamage2;
    float FallDamage3;
    bool FallDamage4;

    public static float Air = 300;
    public GameObject AR슬라이더;
    public Slider AR슬라이더2;

    public float FireTimer = 0;
    public float FireTimer2 = 0;
    public GameObject PlayerFire;

    public BGMManager bgmManager;
    public BeatManager beatManager;

    public static GameObject player;
    public GameObject PlayerSkin;

    public static float MoveAniTimer = 0;
    public static bool MoveB = false;

    float SuffocatTimer = 0;

    //점프 레이캐스트
    RaycastHit2D Jump;
    RaycastHit2D Jump2;
    RaycastHit2D Jump3;

    //물 레이캐스트
    RaycastHit2D Water;
    RaycastHit2D Water2;
    RaycastHit2D Water3;

    RaycastHit2D Water4;
    RaycastHit2D Water5;
    RaycastHit2D Water6;

    RaycastHit2D Water7;
    RaycastHit2D Water8;
    RaycastHit2D Water9;

    //불 레이캐스트
    RaycastHit2D Fire;
    RaycastHit2D Fire2;
    RaycastHit2D Fire3;

    RaycastHit2D Jump4;

    //질식
    RaycastHit2D Suffocat;
    RaycastHit2D Suffocat2;
    RaycastHit2D Suffocat3;

    //이벤트 레이캐스트
    RaycastHit2D Event;

    //사다리 레이캐스트
    RaycastHit2D Ladder;
    RaycastHit2D Ladder2;
    RaycastHit2D Ladder3;

    //Event 레이캐스트
    RaycastHit2D soft_lock;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = gameObject;

        rigid.bodyType = RigidbodyType2D.Static;
    }

    void Start()
    {
        GameManager.loadData();

        transform.position = new Vector2(GameManager.PlayerX, GameManager.PlayerY);
        rigid.velocity = Vector2.zero;
    }

    void Update()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;

        //X좌표랑 Y좌표 정하기
        GameManager.PlayerX = Mathf.Round(transform.position.x * 100) * 0.01f;
        GameManager.PlayerY = Mathf.Round(transform.position.y * 100) * 0.01f;
        GameManager.PlayerZ = Mathf.Round(transform.position.z * 100) * 0.01f;

        if (!GameManager.일시정지)
        {
            //뱡향 전환
            if (!ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (Input.GetButton("Horizontal"))
                    flipX = (int)Input.GetAxisRaw("Horizontal");

                if (GameManager.LeftKey)
                    flipX = -1;
                if (GameManager.RightKey)
                    flipX = 1;

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    GameManager.PlayerMove = false;
                }

                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    GameManager.PlayerMove = false;
                }
            }

            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1.2f * 0.9f, 0), new Color(0, 1, 0));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1.2f * 0.9f, 0), new Color(0, 1, 0));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1.2f * 0.9f, 0), new Color(0, 1, 0));

            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1.5f * 0.9f), new Vector3(0, 0.5f * 0.9f, 0), new Color(0, 0, 1));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1.5f * 0.9f), new Vector3(-0.251f * 0.9f, 0.5f * 0.9f, 0), new Color(0, 0, 1));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1.5f * 0.9f), new Vector3(0.21f * 0.9f, 0.5f * 0.9f, 0), new Color(0, 0, 1));

            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), new Color(0, 1, 0));

            Debug.DrawRay(new Vector2(rigid.position.x - 2, rigid.position.y + 1 * 0.9f), new Vector3(4, 0, 0), new Color(0, 1, 0));

            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(0, -0.5f * 0.9f, 0), new Color(0, 1, 0));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(-0.111f * 0.9f, -0.5f * 0.9f, 0), new Color(0, 1, 0));
            Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(0.111f * 0.9f, -0.5f * 0.9f, 0), new Color(0, 1, 0));

            //점프 레이캐스트
            Jump = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1.2f * 0.9f, 0), 1.2f * 0.9f, LayerMask.GetMask("Map", "Stairs"));
            Jump2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1.2f * 0.9f, 0), 1.2f * 0.9f, LayerMask.GetMask("Map", "Stairs"));
            Jump3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1.2f * 0.9f, 0), 1.2f * 0.9f, LayerMask.GetMask("Map", "Stairs"));

            //물 레이캐스트
            Water = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            Water2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            Water3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));

            Water4 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0, 0.5f * 0.9f, 0), 0.5f, LayerMask.GetMask("Water"));
            Water5 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(-0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Water"));
            Water6 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Water"));

            Water7 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            Water8 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            Water9 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));

            //불 레이캐스트
            Fire = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Fire"));
            Fire2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Fire"));
            Fire3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Fire"));

            Jump4 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), 1, LayerMask.GetMask("Map"));

            //이벤트 레이캐스트
            Event = Physics2D.Raycast(new Vector2(rigid.position.x - 2, rigid.position.y + 1 * 0.9f), new Vector3(4, 0, 0), 4, LayerMask.GetMask("Npc"));

            //사다리 레이캐스트
            Ladder = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(0, -1f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Ladder"));
            Ladder2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(-0.111f * 0.9f, -0.5f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Ladder"));
            Ladder3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 0.5f * 0.9f), new Vector3(0.111f * 0.9f, -0.5f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Ladder"));

            //질식
            Suffocat = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0, 0.5f * 0.9f, 0), 0.5f, LayerMask.GetMask("Map"));
            Suffocat2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(-0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Map"));
            Suffocat3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Map"));

            if (Jump.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1.2f * 0.9f, 0), new Color(1, 0, 0));
                jump = true;
            }

            if (Jump2.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1.2f * 0.9f, 0), new Color(1, 0, 0));
                jump = true;
            }

            if (Jump3.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1.2f * 0.9f, 0), new Color(1, 0, 0));
                jump = true;
            }



            if (Jump.collider == null && Jump2.collider == null && Jump3.collider == null)
                jump = false;



            if (Jump4.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), new Color(1, 0, 0));
                jump = false;
            }

            if (Water.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1 * 0.9f, 0), new Color(1, 0, 1));

            if (Water2.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1 * 0.9f, 0), new Color(1, 0, 1));

            if (Water3.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1 * 0.9f, 0), new Color(1, 0, 1));

            if (Water4.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), new Color(1, 0, 1));

            if (Water5.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, 1 * 0.9f, 0), new Color(1, 0, 1));

            if (Water6.collider != null)
                Debug.DrawRay(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, 1 * 0.9f, 0), new Color(1, 0, 1));

            //AIR
            if (Water4.collider != null || Water5.collider != null || Water6.collider != null)
            {
                Air -= 1 * (20 * Time.deltaTime);

                AR슬라이더.SetActive(true);

                if (Air <= -20)
                {
                    GameManager.gameManager.PlayerDamage(2 * (GameManager.PlayerMaxHP / 20f), false, 1);
                    if (GameManager.PlayerHP < 0.0001f)
                        GameManager.gameManager.GameOver("익사 했습니다");

                    Air = 0;
                }

            }
            else
            {
                Air += 4 * (20 * Time.deltaTime);
                AR슬라이더.SetActive(true);
                if (Air >= 300)
                {
                    AR슬라이더.SetActive(false);
                    AR슬라이더2.value = 300;
                    Air = 300;
                }
            }

            //불 데미지
            if (Fire.collider != null || Fire2.collider != null || Fire3.collider != null)
            {
                PlayerFire.SetActive(true);

                FireTimer = 10;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 0.5f)
                {
                    GameManager.gameManager.PlayerDamage(1 * (GameManager.PlayerMaxHP / 20f), false, 2);
                    if (GameManager.PlayerHP < 0.0001f)
                        GameManager.gameManager.GameOver("화염에 휩싸였습니다");

                    FireTimer2 = 0;
                }
            }
            else if (FireTimer > 0)
            {
                PlayerFire.SetActive(true);

                FireTimer -= Time.deltaTime;

                FireTimer2 += Time.deltaTime;

                if (FireTimer2 >= 1f)
                {
                    GameManager.gameManager.PlayerDamage(1 * (GameManager.PlayerMaxHP / 20f), false, 2);
                    if (GameManager.PlayerHP < 0.0001f)
                        GameManager.gameManager.GameOver("불에 타 사망했습니다");

                    FireTimer2 = 0;
                }
            }
            else
            {
                PlayerFire.SetActive(false);

                FireTimer = 0;
                FireTimer2 = 1;
            }

            if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null)
            {
                FireTimer = 0;
                FireTimer2 = 1;
            }

            //질식
            if (Suffocat.collider != null && Suffocat2.collider != null && Suffocat3.collider != null)
            {
                SuffocatTimer += Time.deltaTime;
                if (SuffocatTimer >= 0.5f)
                {
                    GameManager.gameManager.PlayerDamage(1 * (GameManager.PlayerMaxHP / 20f), false, 0);
                    if (GameManager.PlayerHP < 0.0001f)
                        GameManager.gameManager.GameOver("벽 속에서 질식했습니다");
                    SuffocatTimer = 0;
                }
            }
            else
                SuffocatTimer = 0;


            //NPC 감지
            scanNPC = null;

            if (Event.collider != null)
            {
                Debug.DrawRay(new Vector2(rigid.position.x - 2, rigid.position.y + 1 * 0.9f), new Vector3(4, 0, 0), new Color(1, 0, 0));
                scanNPC = Event.collider.gameObject;
            }

            //NPC 이벤트 실행
            if (Input.GetButtonDown("Event") && scanNPC != null && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                GameManager.gameManager.Action(scanNPC);
            else if (GameManager.ZKey && scanNPC != null)
            {
                GameManager.gameManager.Action(scanNPC);
                GameManager.ZKey = false;
            }
            else if (GameManager.ZKey && scanNPC == null)
                GameManager.ZKey = false;

            if (Input.GetKey(KeyCode.C) && scanNPC != null && GameManager.isAction && NpcEventManager.b && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                GameManager.gameManager.Action(scanNPC);

            if (GameManager.CKey && scanNPC != null && GameManager.isAction && NpcEventManager.b)
                GameManager.gameManager.Action(scanNPC);

            if (GameManager.isAction && scanNPC == null)
                GameManager.gameManager.TalkEnd();

            //공격
            if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.isAction == false && !GameManager.ButtonPointer && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX * 3, 1), new Color(1, 0, 0));
                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX * 3, 0), new Color(1, 0, 0));
                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX * 3, -1), new Color(1, 0, 0));
                RaycastHit2D raycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX, 1), 3, LayerMask.GetMask("Entity", "Entity Collider"));
                if (raycastHit2D.collider == null) raycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX, 0), 3, LayerMask.GetMask("Entity", "Entity Collider"));
                if (raycastHit2D.collider == null) raycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(flipX, -1), 3, LayerMask.GetMask("Entity", "Entity Collider"));

                if (raycastHit2D.collider != null)
                    raycastHit2D.collider.GetComponent<EntitySetting>().Damage(GameManager.PlayerAttack * GameManager.PlayerAV / GameManager.PlayerMaxAV, false, 0);

                GameManager.PlayerAV = 0;
                Attack = true;
                Timer = 0;
            }

            //공격 모션
            if (Attack)
            {
                Timer += Time.deltaTime;

                /*if (Timer > 0.04)
                    마플캐릭터.sprite = 마플_3;

                if (GameManager.PlayerMaxAV / 7 * 3 < GameManager.PlayerAV / GameManager.PlayerMaxAV * 100)
                    마플캐릭터.sprite = 마플_4;
                if (GameManager.PlayerMaxAV / 7 * 4 < GameManager.PlayerAV / GameManager.PlayerMaxAV * 100)
                    마플캐릭터.sprite = 마플_5;
                if (GameManager.PlayerMaxAV / 7 * 5 < GameManager.PlayerAV / GameManager.PlayerMaxAV * 100)
                    마플캐릭터.sprite = 마플_6;
                if (GameManager.PlayerMaxAV / 7 * 6 < GameManager.PlayerAV / GameManager.PlayerMaxAV * 100)
                    마플캐릭터.sprite = 마플_7;
                if (GameManager.PlayerMaxAV / 7 * 7 < GameManager.PlayerAV / GameManager.PlayerMaxAV * 100)
                    마플캐릭터.sprite = 마플_8;*/
                if (GameManager.PlayerAV == GameManager.PlayerMaxAV)
                    Attack = false;
            }

            //세계 밖으로 떨어졌을때
            if (transform.position.y <= -50 && GameManager.PlayerHP > 0.0001f)
                GameManager.gameManager.PlayerDamage(0.18f * GameManager.PlayerMaxHP, false, 0);

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

            if (!FallDamage4 && jump && Water.collider == null && Water2.collider == null && Water3.collider == null && Water4.collider == null && Water5.collider == null && Water6.collider == null && Water7.collider == null && Water8.collider == null && Water9.collider == null && Ladder.collider == null && Ladder2.collider == null && Ladder3.collider == null)
            {
                Debug.Log("Fall " + FallDamage);
                if (FallDamage > 3)
                    GameManager.gameManager.PlayerDamage((FallDamage - 3) * (GameManager.PlayerMaxHP / 20f), false, 0);

                if (GameManager.PlayerHP < 0.0001f && FallDamage - 3 > 2)
                    GameManager.gameManager.GameOver("높은 곳에서 떨어졌습니다");
                else if (GameManager.PlayerHP < 0.0001f && FallDamage - 3 <= 2)
                    GameManager.gameManager.GameOver("너무 세게 떨어졌습니다");

                FallDamage = 0;
                FallDamage4 = true;
            }
            if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null || Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null)
            {
                FallDamage = 0;
                FallDamage2 = 0;
                FallDamage3 = transform.position.y;
                FallDamage4 = true;
            }

            //EVENT
            Debug.DrawRay(transform.position, new Vector2(0, 2f), new Color(0, 1, 0));
            soft_lock = Physics2D.Raycast(transform.position, new Vector2(0, 2f), 1f, LayerMask.GetMask("event.soft_lock"));

            if (soft_lock.collider != null && !event_soft_lock.Play)
                event_soft_lock.start = true;
        }

        if (!GameManager.일시정지 || GameManager.isAction || GameManager.PlayerHP <= 0.0001f)
        {
            //애니메이션
            if (MainCamera.Game3D)
            {
                if (flipX == -1 && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation("All", new Vector3(0, 90, 0));
                else if ((flipX == 1 || flipX == 0) && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation("All", new Vector3(0, -90, 0));
            }
            else
            {
                if (flipX == -1 && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation("All", new Vector3(0, 90, 0), true);
                else if ((flipX == 1 || flipX == 0) && (!GameManager.isAction || GameManager.PlayerMove))
                    SkinRotation.skinRotation("All", new Vector3(0, -90, 0), true);
            }

            if (GameManager.PlayerMove && GameManager.PlayerHP > 0.0001f)
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
                    SkinRotation.skinRotation("Left Arm", new Vector3(90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Right Arm", new Vector3(-90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Left Leg", new Vector3(-90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Right Leg", new Vector3(90f, 0, 0), false, 0.065f);
                }
                else
                {
                    SkinRotation.skinRotation("Left Arm", new Vector3(-90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Right Arm", new Vector3(90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Left Leg", new Vector3(90f, 0, 0), false, 0.065f);
                    SkinRotation.skinRotation("Right Leg", new Vector3(-90f, 0, 0), false, 0.065f);
                }
            }
            else
            {
                SkinRotation.skinRotation("Left Arm", new Vector3(0, 0, 0));
                SkinRotation.skinRotation("Right Arm", new Vector3(0, 0, 0));
                SkinRotation.skinRotation("Left Leg", new Vector3(0, 0, 0));
                SkinRotation.skinRotation("Right Leg", new Vector3(0, 0, 0));
            }

            if (GameManager.isAction && !GameManager.PlayerMove)
            {
                if (MainCamera.Game3D)
                    SkinRotation.skinLookAt(scanNPC.transform.Find("Minecraft Player Skin").gameObject, "All");
                else
                    SkinRotation.skinLookAt(scanNPC.transform.Find("Minecraft Player Skin").gameObject, "All", true);

                if (!MainCamera.Game3D && SkinRotation.PlayerObject.transform.localEulerAngles.y > 180)
                    SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                else if (!MainCamera.Game3D)
                    SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                SkinRotation.skinPos(new Vector3(0, 0, -0.43f));
                SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, SkinRotation.PlayerObject.transform.localRotation.eulerAngles.y, 0)), true);
            }
            else
                SkinRotation.skinPos(new Vector3(0, 0, 0));
        }

        //인스펙터 변수
        _scanNPC = scanNPC;
        _Rigidbody2D = rigid;

        //만우절 이벤트 Z 회전 고정 풀기
        if (DateTime.Now.ToString("MM") == "04" && DateTime.Now.ToString("dd") == "01")
            rigid.freezeRotation = false;
        else
            rigid.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (!GameManager.일시정지)
        {
            //멈추기
            if (Input.GetButtonUp("Horizontal") || ChattingManager.ChattingActive || InvManager.InventoryShow)
                GameManager.PlayerMove = false;
            else if (GameManager.leftKeyUp || GameManager.rightKeyUp)
            {
                GameManager.PlayerMove = false;
                GameManager.leftKeyUp = false;
                GameManager.rightKeyUp = false;
            }

            //걷기 애니메이션
            if (Input.GetButton("Horizontal") && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                GameManager.PlayerMove = true;
            else if (GameManager.LeftKey || GameManager.RightKey)
                GameManager.PlayerMove = true;

            if (rigid.velocity.x >= -0.5f && rigid.velocity.x <= 0.5f || rigid.velocity.x == 0)
                GameManager.PlayerMove = false;

            RaycastHit2D Water = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));

            RaycastHit2D Water4 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water5 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(-0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water6 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1.51f * 0.9f), new Vector3(0.251f * 0.9f, 0.5f * 0.9f, 0), 0.5f * 0.9f, LayerMask.GetMask("Water"));

            RaycastHit2D Water7 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water8 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));
            RaycastHit2D Water9 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, 1 * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Water"));

            RaycastHit2D Ladder = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Ladder"));
            RaycastHit2D Ladder2 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(-0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Ladder"));
            RaycastHit2D Ladder3 = Physics2D.Raycast(new Vector2(rigid.position.x, rigid.position.y + 1 * 0.9f), new Vector3(0.111f * 0.9f, -1f * 0.9f, 0), 1f * 0.9f, LayerMask.GetMask("Ladder"));

            //플레이어 움직이기
            int h = (int)Input.GetAxisRaw("Horizontal");

            if (ChattingManager.ChattingActive || InvManager.InventoryShow)
                h = 0;

            if (Water.collider == null && Water2.collider == null && Water3.collider == null && Water4.collider == null && Water5.collider == null && Water6.collider == null && Water7.collider == null && Water8.collider == null && Water9.collider == null)
            {
                rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * h, rigid.velocity.y), 0.2f);

                if (GameManager.LeftKey)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * -1, rigid.velocity.y), 0.2f);
                else if (GameManager.RightKey)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed, rigid.velocity.y), 0.2f);

                if (rigid.velocity.x < GameManager.PlayerMaxSpeed * -1)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * -1, rigid.velocity.y), 0.2f);
                else if (rigid.velocity.x > GameManager.PlayerMaxSpeed)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed, rigid.velocity.y), 0.2f);
            }

            if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null)
            {
                rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * h * 0.4f, rigid.velocity.y), 0.1f);

                if (GameManager.LeftKey)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * -1 * 0.4f, rigid.velocity.y), 0.1f);
                else if (GameManager.RightKey)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * 0.4f, rigid.velocity.y), 0.1f);

                if (rigid.velocity.x < GameManager.PlayerMaxSpeed * -1 * 0.5f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * -1 * 0.4f, rigid.velocity.y), 0.2f);

                if (rigid.velocity.x > GameManager.PlayerMaxSpeed * 0.5f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(GameManager.PlayerMaxSpeed * 0.4f, rigid.velocity.y), 0.2f);

                if (rigid.velocity.y < GameManager.PlayerJumpPower * -1 * 0.25f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower * -1 * 0.4f), 0.1f);

                if (rigid.velocity.y > GameManager.PlayerJumpPower * 0.4f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower * 0.4f), 0.1f);
            }

            if (Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null)
            {
                if (rigid.velocity.y < GameManager.PlayerJumpPower * -1 * 0.25f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower * -1 * 0.4f), 0.1f);

                if (rigid.velocity.y > GameManager.PlayerJumpPower * 0.4f)
                    rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower * 0.4f), 0.1f);
            }

            //점프
            if (!ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (Input.GetButton("Jump") && FallDamage4)
                {
                    if (jump && Water.collider == null && Water2.collider == null && Water3.collider == null && Water4.collider == null && Water5.collider == null && Water6.collider == null && Water7.collider == null && Water8.collider == null && Water9.collider == null)
                        rigid.velocity = new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower);
                    else if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null)
                        rigid.AddForce(new Vector2(0, 0.000045f), ForceMode2D.Impulse);
                    else if (Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null)
                        rigid.velocity = new Vector2(rigid.velocity.x, 3);

                }
                else if (GameManager.UpKey && FallDamage4)
                {
                    if (jump && Water.collider == null && Water2.collider == null && Water3.collider == null && Water4.collider == null && Water5.collider == null && Water6.collider == null && Water7.collider == null && Water8.collider == null && Water9.collider == null)
                        rigid.velocity = new Vector2(rigid.velocity.x, GameManager.PlayerJumpPower);
                    else if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null)
                        rigid.AddForce(new Vector2(0, 0.000045f), ForceMode2D.Impulse);
                    else if (Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null)
                        rigid.velocity = new Vector2(rigid.velocity.x, 3);
                }
            }

            if ((Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null) && (!Input.GetButton("Jump") || ChattingManager.ChattingActive) && !GameManager.UpKey)
                rigid.velocity = new Vector2(rigid.velocity.x, -3);

            if (Water.collider != null || Water2.collider != null || Water3.collider != null || Water4.collider != null || Water5.collider != null || Water6.collider != null || Water7.collider != null || Water8.collider != null || Water9.collider != null)
                rigid.gravityScale = 1;
            else if (Ladder.collider != null || Ladder2.collider != null || Ladder3.collider != null)
                rigid.gravityScale = 0f;
            else
                rigid.gravityScale = 3;

            //반 블록 올라가기
            Debug.DrawRay(transform.position, new Vector2(0.5f * h, 0), new Color(0, 1, 1));
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.6f), new Vector2(0.5f * h, 0), new Color(0, 1, 1));

            RaycastHit2D AutoJump = Physics2D.Raycast(transform.position, new Vector2(0.5f * h, 0), 0.2f, LayerMask.GetMask("Map", "Stairs"));
            RaycastHit2D AutoJump2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.6f), new Vector2(0.5f * h, 0), 0.5f, LayerMask.GetMask("Map", "Stairs"));

            if (Input.GetButton("Horizontal") && AutoJump.collider != null && AutoJump2.collider == null && FallDamage4 && jump)
            {
                while (AutoJump.collider != null)
                {
                    AutoJump = Physics2D.Raycast(rigid.position, new Vector2(0.2f * h, 0), 0.2f, LayerMask.GetMask("Map", "Stairs"));
                    rigid.position = new Vector2(rigid.position.x, rigid.position.y + 0.001f);
                    rigid.velocity = new Vector2(GameManager.PlayerMaxSpeed * h * 1.5f, rigid.velocity.y);
                }
            }
        }

        /*if (GameManager.isAction)
        {
            if (ii)
            {
                i = rigid.velocity.y;
                iii = rigid.gravityScale;
            }
            ii = false;
            rigid.velocity = Vector3.zero;
            rigid.gravityScale = 0;
        }
        else
        {
            if (ii == false)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, i);
                rigid.gravityScale = iii;
            }
            ii = true;
        }*/
    }

    public void PlayerDamage()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        Invoke("PlayerDamage2", GameManager.PlayerDamageDelay);
    }

    void PlayerDamage2() =>
        PlayerDamageMaterial.PlayerDamage = false;

    public void GameOver()
    {
        FallDamage = 0;
        FallDamage2 = 0;
        FallDamage3 = 0;
        FallDamage4 = false;

        GameOverBackground2.SetActive(true);

        iiii = true;
        GameOverRotationSuc = false;
        time = 0;

        rigid.velocity = Vector2.zero;
        GameOver2();
    }

    void GameOver2()
    {
        Quaternion target = Quaternion.Euler(0, 0, 90);
        PlayerSkin.transform.localRotation = Quaternion.Lerp(PlayerSkin.transform.localRotation, target, 0.03f * 60 * Time.unscaledDeltaTime * GameManager.GameSpeed);

        rigid.velocity = Vector2.zero;

        if (GameOverBackground.color.a < 0.25)
            GameOverBackground.color = new Color(1, 0, 0, GameOverBackground.color.a + 0.0005f * GameManager.GameSpeed);

        if (PlayerSkin.transform.localEulerAngles.z >= 88.5f || PlayerSkin.transform.localEulerAngles.z <= -88.5f)
        {
            Time.timeScale = 0;
            GameOverManager.SetActive(true);

            if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
            {
                target = Quaternion.Euler(0, 0, -6);
                mainCamera.transform.localRotation = Quaternion.Lerp(mainCamera.transform.localRotation, target, 0.005f * (60 * Time.unscaledDeltaTime) * GameManager.GameSpeed);

                Vector3 target2 = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, -12);
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, target2, 0.005f * (60 * Time.unscaledDeltaTime) * GameManager.GameSpeed);
            }

            SkinRotation.PlayerObject.SetActive(false);

            GameOverRotationSuc = true;

            SoundManager.StopAll(SoundType.BGM);

            if (time >= 4f)
                particlesystem.SetActive(false);
            else if (iiii)
            {
                iiii = false;
                if (GameManager.Particle)
                    particlesystem.SetActive(true);
            }

            time += Time.unscaledDeltaTime;
        }

        Invoke("GameOver2", 1 / 60 * GameManager.GameSpeed);
    }

    public void Respawn()
    {
        CancelInvoke();

        GameManager.PlayerHP = GameManager.PlayerMaxHP;
        GameManager.PlayerHG = GameManager.PlayerMaxHG;
        GameManager.일시정지 = false;
        PlayerSkin.transform.localRotation = Quaternion.Euler(0, 0, 0);
        GameOverBackground.color = new Color(1, 0, 0, 0);
        particlesystem.SetActive(false);
        GameOverManager.SetActive(false);
        GameOverBackground2.SetActive(false);
        SkinRotation.PlayerObject.SetActive(true);
        time = 0;
        GameManager.gameoverText = "";

        GameManager.gameManager.mainMenu();
        bgmManager.MainMenu = false;
        beatManager.MainMenu = false;
    }

    //맵을 이동했을때 또는 메인메뉴로 갔을때 위치 초기화
    public void MainMenu()
    {
        rigid.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);

        transform.position = new Vector2(0, -4);
    }
}