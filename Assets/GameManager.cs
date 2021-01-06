using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //플레이어 좌표 정보
    public static float PlayerX = 0f;
    public static float PlayerY = 0f;
    public static float PlayerZ = 0f;

    [Header("플레이어 좌표 정보")]
    [Tooltip("플레이어의 좌표 정보입니다")]
    public float _PlayerX;
    public float _PlayerY;
    public float _PlayerZ;

    //플레이어 상태
    public static float PlayerMaxHP = 130f;
    public static float PlayerHP = PlayerMaxHP;
    public static float PlayerMaxHG = 20f;
    public static float PlayerHG = PlayerMaxHG;
    public static float PlayerMaxAV = 100f;
    public static float PlayerAV = PlayerMaxAV;
    public static float PlayerAS = 0.2f;
    public static int PlayerLevel = 0;
    public static float PlayerMaxXP = 30f;
    public static float PlayerXP = 0f;
    public static float PlayerGold = 300f;
    public static int GameMode = 2;

    public static bool PlayerHGSpeedDown = true;

    [Header("플레이어 상태")]
    [Tooltip("플레이어의 상태입니다")]
    public float _PlayerMaxHP;
    public float _PlayerHP;
    public float _PlayerMaxHG;
    public float _PlayerHG;
    public float _PlayerMaxAV;
    public float _PlayerAV;
    public float _PlayerAS;
    public int _PlayerLevel;
    public float _PlayerMaxXP;
    public float _PlayerXP;
    public float _PlayerGold;
    public int _GameMode = 2;

    //플레이어 상태
    public static float PlayerMaxSpeed = 5f;
    public static float PlayerJumpPower = 9;
    public static bool PlayerMove = false;
    public static float PlayerDamageDelay = 0.4f;
    public static float PlayerDamageDelayTimer = 0f;

    [Space(15)]
    public float _PlayerSpeed;
    public float _PlayerJumpPower;
    public bool _PlayerMove;
    public float PlayerMoveHGTimer = 0;
    public int PlayerMoveHGTimerRandom = 0;
    public float PlayerHGHPTimer = 0;
    public int PlayerHGHPTimerRandom = 0;
    public float PlayerHGDamageTimer = 0;
    public float _PlayerDamageDelay = PlayerDamageDelay;
    public float _PlayerDamageDelayTimer = PlayerDamageDelayTimer;

    public float FPS;

    [Space(15)]
    public float DeltaTime;
    public float unscaledDeltaTime;

    [Space(15)]

    //맵
    public static int Map = 0;

    [Header("맵 번호")]
    [Tooltip("현재 맵의 번호입니다")]
    public int _Map;

    //기타 정보
    public static bool MainMenu = true;
    public static bool CameraX고정 = true;
    public static bool CameraY고정 = true;
    public static float GameSpeed = 1;
    public static bool InvAV0 = false;
    public static float GUISize = 1;
    public static bool 일시정지 = false;

    public static float MainVolume = 70;

    public Player player;

    [Header("기타 정보")]
    [Tooltip("기타 정보들 입니다")]
    public bool _MainMenu;
    public bool _CameraX고정;
    public bool _CameraY고정;
    public float _GameSpeed;
    public bool _InvAV0;
    public float _GUISize;
    public bool _일시정지;

    //플레이어 인벤토리
    public static List<string> PlayerInv = new List<string>();

    public static int PlayerInvLine = 0;
    public static int PlayerInvMaxLine = 5;
    public static int PlayerInvCannes = 0;
    public static string PlayerInvItem = "air";

    [Header("플레이어 인벤토리")]
    [Tooltip("플레이어의 인벤토리와 상태들입니다")]
    public List<string> _PlayerInv = new List<string>();

    public int _PlayerInvLine;
    public int _PlayerInvMaxLine;
    public int _PlayerInvCannes;
    public string _PlayerInvItem;

    //맵 이동 변수
    public static bool MapMove = false;
    public static bool SoundRestart = false;

    [Header("맵 이동 변수")]
    [Tooltip("플레이어가 맵을 이동할때 true 를 내보냅니다")]
    public bool _MapMove = MapMove;
    public bool _SoundRestart = SoundRestart;

    //리듬 변수
    public static float Timer = 0f;
    public static float BPM = 0f;
    public static float CurrentBeat = 0f;
    public static float StartDelay = 0f;
    public static float Pitch = 1f;

    [Header("리듬 변수")]
    [Tooltip("리듬과 관련된 변수들 입니다")]
    public float _Timer = 0f;
    public float _CurrentBeat = 0f;
    public float _Bpm = 0f;
    public float _StartDelay = 0f;
    public float _Pitch = 0f;
    public BeatManager BeatManager;

    //대화창
    [Header("대화창")]
    [Tooltip("대화창과 관련된 변수와 오브젝트, 스크립트들 입니다")]
    public 대화창TextEffect talkeffect;
    public GameObject scanNPC;
    public GameObject talkPanel;
    public static bool isAction;
    public int talkIndex;
    public GameObject 대화창화살표;

    public static int EventSelection = 0;

    public int _EventSelection = EventSelection;

    public bool _isAction;

    //세이브
    [Header("세이브")]
    [Tooltip("세이브 파일과 관련된 변수들 입니다")]
    public static GameManager gameManager;
    public static bool dataReset;
    public static int dataReset_i;
    public static bool dataResetMessage;

    public bool _dataReset;
    public int _dataReset_i;
    public bool _dataResetMessage;

    //키 조작
    public static bool ButtonPointer = false;
    public static bool LeftKey = false;
    public static bool RightKey = false;
    public static bool DownKey = false;
    public static bool UpKey = false;
    public static bool leftKeyUp = false;
    public static bool rightKeyUp = false;
    public static bool upKeyUp = false;
    public static bool downKeyUp = false;
    public static bool ZKey = false;
    public static bool XKey = false;
    public static bool CKey = false;
    public static bool InvKey = false;
    public static bool MinusKey = false;
    public static bool PlusKey = false;

    [Header("키 조작")]
    [Tooltip("키보드 조작과 관련된 변수들 입니다")]
    public bool _ButtonPointer = false;
    public bool _LeftKey = false;
    public bool _RightKey = false;
    public bool _DownKey = false;
    public bool _UpKey = false;
    public bool _leftKeyUp = false;
    public bool _rightKeyUp = false;
    public bool _upKeyUp = false;
    public bool _downKeyUp = false;
    public bool _ZKey = false;
    public bool _XKey = false;
    public bool _CKey = false;
    public bool _InvKey = false;
    public bool _MinusKey = false;
    public bool _PlusKey = false;

    //전투
    public static bool MyTurn = true;

    [Header("전투")]
    [Tooltip("전투와 관련된 변수들 입니다")]
    public bool _MyTurn = MyTurn;

    //오브젝트
    [Header("오브젝트")]
    [Tooltip("오브젝트 설정")]
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip hit_drown1;
    public AudioClip hit_drown2;
    public AudioClip hit_drown3;
    public AudioClip hit_drown4;
    public AudioClip hit_fire1;
    public AudioClip hit_fire2;
    public AudioClip hit_fire3;

    public Text GameOverText;
    public MainCamera mainCamera;

    public BoxCollider2D 왼쪽벽;
    public BoxCollider2D 오른쪽벽;

    public static string gameoverText = "";

    public bool b = false;

    public Text mainVolumeText;

    public GameObject MinusButton;
    public GameObject PlusButton;

    public GameObject PhoneControllerCanvas;
    public GameObject MinecraftUGUIManager;
    public GameObject DebugCanvas;
    public GameObject StartPadeLodingUI;
    public GameObject MainCameraSize;

    public 일시정지Canvas 일시정지Canvas;

    //기타 게임
    [Header("기타 게임")]
    [Tooltip("기타 게임 설정")]
    public int ADOFAIKey = 0;
    public int MinecraftKey = 0;

    public static bool MinecraftGame = true;
    public static bool ADOFAIGame = false;

    public bool _MinecraftGame = MinecraftGame;
    public bool _ADOFAIGame = ADOFAIGame;

    public static bool GameStart = false;

    public static int ADOFAIMap = 0;

    //시간
    public static float GameTime = 6000;
    public static float DayTimeMinute = 20;
    public static float RealTime = 0;

    [Header("시간")]
    [Tooltip("시간 변수")]
    public float _GameTime = GameTime;
    public float _RealTime = RealTime;

    //성능
    public static int Graphic = 0;
    public static int GUIAni = 0;
    public static int CameraAni = 0;
    public static int BlockAni = 0;
    public static int TalkAni = 0;
    public static bool Particle = true;
    public static int PlayerLerpMove = 1;

    [Header("성능")]
    [Tooltip("성능 변수")]
    public int _Graphic = Graphic;
    public int _GUIAni = GUIAni;
    public int _CameraAni = CameraAni;
    public int _BlockAni = BlockAni;
    public int _TalkAni = TalkAni;
    public bool _Particle = Particle;
    public int _PlayerLerpMove = PlayerLerpMove;

    float MainVolTemp = 0;


    int tempGrabhic = 0;

    void Awake()
    {
        ResourceManager.ResourcePackAdd("C:/Users/Simsimhan Chobo/Documents/asdfasdfsafsdfasdfsasfasdfsdfa");

        gameManager = gameObject.GetComponent<GameManager>();

        if (MinecraftGame)
        {
            PhoneControllerCanvas.SetActive(true);
            MinecraftUGUIManager.SetActive(true);
            MainCameraSize.SetActive(true);
            DebugCanvas.SetActive(true);
            StartPadeLodingUI.SetActive(true);
        }

        if (!GameStart)
        {
            /*QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;*/
        }
    }

    void Start()
    {
        if (!GameStart)
        {
            MapMove = true;
            SoundRestart = true;

            Debug.Log("마플 RPG Game Start!");

            if (gameoverText != "" && PlayerHP < 0.0001f)
                GameOver(gameoverText);
        }

        GameStart = true;

        Timer = 0;
    }

    void Update()
    {
        //Minecraft
        if (MinecraftGame)
        {
            if (!일시정지 && !isAction)
            {
                //맵
                if (MapMove)
                {
                    MapMove = false;
                    Timer = 0;
                    CurrentBeat = 0;
                    BeatManager.NextBeatRestart();
                }

                if (MainMenu)
                {
                    CameraX고정 = true;
                    CameraY고정 = true;
                }
                else if (MainMenu == false)
                {
                    if (Map == 0)
                    {
                        CameraX고정 = false;
                        CameraY고정 = true;
                    }
                }


                //인벤토리
                if (!ChattingManager.ChattingActive && !InvManager.InventoryShow)
                {
                    if (Input.GetKeyDown(KeyCode.Minus) || MinusKey)
                    {
                        if (MinusKey)
                            ButtonPointer = false;

                        PlayerInvLine -= 1;
                        if (PlayerInvLine < 0)
                            PlayerInvLine = PlayerInvMaxLine;
                        if (PlayerInvMaxLine < PlayerInvLine)
                            PlayerInvLine = 0;
                        if (PlayerInvLine * 10 > PlayerInv.Count)
                        {
                            while (PlayerInvLine * 10 > PlayerInv.Count)
                                PlayerInvLine -= 1;
                        }

                        MinusKey = false;
                    }

                    if (Input.GetKeyDown(KeyCode.Equals) || PlusKey)
                    {
                        if (PlusKey)
                            ButtonPointer = false;

                        PlayerInvLine += 1;
                        if (PlayerInvLine <= 0)
                            PlayerInvLine = PlayerInvMaxLine;
                        if (PlayerInvMaxLine < PlayerInvLine)
                            PlayerInvLine = 0;
                        if (PlayerInvLine * 10 > PlayerInv.Count)
                            PlayerInvLine = 0;

                        PlusKey = false;
                    }

                    if (PlayerInv.Count >= 10)
                    {
                        MinusButton.SetActive(true);
                        PlusButton.SetActive(true);
                    }
                    else
                    {
                        MinusButton.SetActive(false);
                        PlusButton.SetActive(false);
                    }

                    if (0 < Input.GetAxis("Mouse ScrollWheel"))
                    {
                        PlayerInvCannes -= 1;
                        PlayerAV = 0;
                        if (PlayerInvCannes < 0)
                            PlayerInvCannes = 8;
                    }
                    if (0 > Input.GetAxis("Mouse ScrollWheel"))
                    {
                        PlayerInvCannes += 1;
                        PlayerAV = 0;
                        if (PlayerInvCannes > 8)
                            PlayerInvCannes = 0;
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        if (PlayerInvCannes != 0)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 0;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        if (PlayerInvCannes != 1)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 1;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        if (PlayerInvCannes != 2)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 2;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        if (PlayerInvCannes != 3)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 3;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        if (PlayerInvCannes != 4)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 4;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha6))
                    {
                        if (PlayerInvCannes != 5)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 5;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha7))
                    {
                        if (PlayerInvCannes != 6)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 6;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha8))
                    {
                        if (PlayerInvCannes != 7)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 7;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha9))
                    {
                        if (PlayerInvCannes != 8)
                        {
                            PlayerAV = 0;
                            PlayerInvCannes = 8;
                        }
                    }
                }

                if (PlayerInv.Count - 1 < PlayerInvCannes + PlayerInvLine * 9)
                    PlayerInvItem = "air";
                else
                    PlayerInvItem = PlayerInv[PlayerInvCannes + PlayerInvLine * 9];

                //AV
                if (PlayerAV <= PlayerMaxAV)
                    PlayerAV += PlayerMaxAV / (60 * PlayerAS) * (60 * Time.deltaTime);

                if (PlayerAV >= PlayerMaxAV)
                    PlayerAV = PlayerMaxAV;

                //HG
                if (PlayerMove && !MainMenu)
                {
                    PlayerMoveHGTimer += Time.deltaTime;
                    if (PlayerMoveHGTimer >= PlayerMoveHGTimerRandom)
                    {
                        PlayerMoveHGTimer = 0;
                        PlayerMoveHGTimerRandom = Random.Range(6, 12);
                        PlayerHG -= Random.Range(0.25f, 0.5f);
                    }
                }

                if (PlayerHG <= 0)
                {
                    PlayerHGDamageTimer += Time.deltaTime;

                    if (PlayerHGDamageTimer >= 2)
                    {
                        PlayerDamage(0.05f * PlayerMaxHP, false, 0);
                        PlayerHGDamageTimer = 0;
                    }
                }
                else
                    PlayerHGDamageTimer = 0;

                if (PlayerMaxHP != PlayerHP && PlayerHG / PlayerMaxHG * 100 > 50 && !MainMenu)
                {
                    PlayerHGHPTimer += Time.deltaTime;
                    if (PlayerHGHPTimer >= PlayerHGHPTimerRandom)
                    {
                        PlayerHGHPTimer = 0;
                        PlayerHGHPTimerRandom = Random.Range(1, 3);
                        PlayerHG -= 0.5f;
                        PlayerHP += 2;
                    }
                }

                PlayerMaxSpeed = 7.1f;
                PlayerJumpPower = 8.17f;
                if (PlayerHG / PlayerMaxHG * 100 < 30 && !event_soft_lock.Play && PlayerHGSpeedDown)
                    PlayerMaxSpeed = 7.1f * 0.75f;

                //자동 시작
                if (MainMenu)
                {
                    if (PlayerX <= -7 && PlayerX >= -8.5f && (Input.GetButton("Horizontal") || LeftKey || RightKey))
                    {
                        MainMenu = false;
                        MapMove = true;
                        SoundRestart = true;
                    }
                    else if (PlayerX >= 7 && PlayerX <= 8.5f && (Input.GetButton("Horizontal") || LeftKey || RightKey))
                    {
                        MainMenu = false;
                        MapMove = true;
                        SoundRestart = true;
                    }
                }

                //메인 메뉴로
                if (!MainMenu)
                {
                    if (Input.GetKeyDown(KeyCode.M) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
                    {
                        if (Player.rigid.velocity.x <= 0.0025f && Player.rigid.velocity.x >= -0.0025f && Player.rigid.velocity.y <= 0.0025f && Player.rigid.velocity.y >= -0.0025f && !event_soft_lock.Play)
                        {
                            PlayerAV = PlayerMaxAV;
                            mainMenu();
                        }
                    }
                }
            }

            //HP, HG가 최대 HP또는 HG를 넘어섰을때
            if (PlayerMaxHP < PlayerHP)
                PlayerHP = PlayerMaxHP;
            if (PlayerMaxHG < PlayerHG)
                PlayerHG = PlayerMaxHG;
            if (PlayerHG < 0)
                PlayerHG = 0;

            /*if (b)
                GameSpeed -= 0.01f * 60 * Time.deltaTime;
            else
                GameSpeed += 0.01f * 60 * Time.deltaTime;*/

            if (GameSpeed >= 2)
                b = true;
            else if (GameSpeed <= 0.5f)
                b = false;

            if (GameSpeed > 100)
                GameSpeed = 100;

            if (GameSpeed < 0)
                GameSpeed = 0;

            //일시정지
            if (일시정지 && PlayerHP > 0.0001f)
                Time.timeScale = 0;
            else if (!일시정지 && PlayerHP > 0.0001f)
                Time.timeScale = GameSpeed;

            if (Input.GetKey(KeyCode.V) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                PlayerDamage(Random.Range(5, 11), false, 0);
                //PlayerDamage(130, false);
            }

            //무적 시간
            PlayerDamageDelayTimer += Time.deltaTime;

            //게임 오버
            if (PlayerHP < 0.0001f)
            {
                if (PlayerY <= -50)
                    GameOver("세계 밖으로 떨어졌습니다");
                else if (PlayerHG <= 0)
                    GameOver("아사했습니다.");
                else
                    GameOver("시스템에 의해 데미지를 받았습니다");
            }

            //주 음량 변경
            if (MainVolTemp != MainVolume)
            {
                mainVolumeText.text = "주 음량: " + Mathf.Round(MainVolume * 100) + "%";
                if (MainVolume <= -1)
                {
                    MainVolume = 0;
                    mainVolumeText.text = "주 음량: 꺼짐";
                }
            }
            MainVolTemp = MainVolume;

            //ADOFAI Game
            if (!ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (ADOFAIKey == 0 && Input.GetKeyDown(KeyCode.A))
                    ADOFAIKey = 1;
                else if (ADOFAIKey == 1 && Input.GetKeyDown(KeyCode.D))
                    ADOFAIKey = 2;
                else if (ADOFAIKey == 2 && Input.GetKeyDown(KeyCode.O))
                    ADOFAIKey = 3;
                else if (ADOFAIKey == 3 && Input.GetKeyDown(KeyCode.F))
                    ADOFAIKey = 4;
                else if (ADOFAIKey == 4 && Input.GetKeyDown(KeyCode.A))
                    ADOFAIKey = 5;
                else if (ADOFAIKey == 5 && Input.GetKeyDown(KeyCode.I))
                {
                    if (!isAction && !일시정지)
                    {
                        MinecraftGame = false;
                        ADOFAIGame = true;
                    }

                    ADOFAIKey = 0;
                    Loading.LoadScene("ADOFAI", "A Dance of Fire and Ice");
                }
            }

            //대화창 화살표 안보이게
            if (!isAction)
                대화창화살표.SetActive(false);
        }

        if (ADOFAIGame)
        {
            if (!ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                //Minecraft Game
                if (MinecraftKey == 0 && Input.GetKeyDown(KeyCode.M))
                    MinecraftKey = 1;
                else if (MinecraftKey == 1 && Input.GetKeyDown(KeyCode.I))
                    MinecraftKey = 2;
                else if (MinecraftKey == 2 && Input.GetKeyDown(KeyCode.N))
                    MinecraftKey = 3;
                else if (MinecraftKey == 3 && Input.GetKeyDown(KeyCode.E))
                    MinecraftKey = 4;
                else if (MinecraftKey == 4 && Input.GetKeyDown(KeyCode.C))
                    MinecraftKey = 5;
                else if (MinecraftKey == 5 && Input.GetKeyDown(KeyCode.R))
                    MinecraftKey = 6;
                else if (MinecraftKey == 6 && Input.GetKeyDown(KeyCode.A))
                    MinecraftKey = 7;
                else if (MinecraftKey == 7 && Input.GetKeyDown(KeyCode.F))
                    MinecraftKey = 8;
                else if (MinecraftKey == 8 && Input.GetKeyDown(KeyCode.T))
                {
                    if (!isAction && !일시정지)
                    {
                        MinecraftGame = true;
                        ADOFAIGame = false;
                    }

                    MinecraftKey = 0;
                    Loading.LoadScene("마플 RPG", "마플 RPG");
                }
            }
        }

        //성능
        if (Graphic != tempGrabhic)
        {
            if (Graphic == 0)
                QualitySettings.SetQualityLevel(2);
            else
                QualitySettings.SetQualityLevel(0);
        }

        tempGrabhic = Graphic;

        //피치 조정
        if (Pitch < -3)
            Pitch = -3;
        else if (Pitch > 3)
            Pitch = 3;

        //비트
        Timer += Time.deltaTime * Pitch;
        CurrentBeat = (Timer - StartDelay) / (60 / BPM);

        //데이터 리셋 취소
        if (!일시정지)
            dataReset_i = 0;

        //인스펙터에서 static 변수를 변경
        Pitch = _Pitch;
        GameSpeed = _GameSpeed;

        //인스펙터 변수
        if (Time.deltaTime != 0)
            FPS = Mathf.Round(1 / Time.deltaTime);
        else
            FPS = 0;
        DeltaTime = Time.deltaTime;
        unscaledDeltaTime = Time.unscaledDeltaTime;

        //현실 시간
        RealTime = (int.Parse(DateTime.Now.ToString("HH")) * 3600f) + (int.Parse(DateTime.Now.ToString("mm")) * 60f) + int.Parse(DateTime.Now.ToString("ss"));

        _Bpm = BPM;
        _CameraX고정 = CameraX고정;
        _CameraY고정 = CameraY고정;
        _CurrentBeat = CurrentBeat;
        _dataReset = dataReset;
        _dataResetMessage = dataResetMessage;
        _dataReset_i = dataReset_i;
        _EventSelection = EventSelection;
        _GameMode = GameMode;
        _GameSpeed = GameSpeed;
        _GUISize = GUISize;
        _InvAV0 = InvAV0;
        _isAction = isAction;
        _MainMenu = MainMenu;
        _Map = Map;
        _MapMove = MapMove;
        _MyTurn = MyTurn;
        _Pitch = Pitch;
        _PlayerAS = PlayerAS;
        _PlayerAV = PlayerAV;
        _PlayerDamageDelay = PlayerDamageDelay;
        _PlayerDamageDelayTimer = PlayerDamageDelayTimer;
        _PlayerGold = PlayerGold;
        _PlayerHG = PlayerHG;
        _PlayerHP = PlayerHP;
        _PlayerInv = PlayerInv;
        _PlayerInvCannes = PlayerInvCannes;
        _PlayerInvItem = PlayerInvItem;
        _PlayerInvLine = PlayerInvLine;
        _PlayerInvMaxLine = PlayerInvMaxLine;
        _PlayerJumpPower = PlayerJumpPower;
        _PlayerLevel = PlayerLevel;
        _PlayerMaxAV = PlayerMaxAV;
        _PlayerMaxHG = PlayerMaxHG;
        _PlayerMaxHP = PlayerMaxHP;
        _PlayerMaxXP = PlayerMaxXP;
        _PlayerMove = PlayerMove;
        _PlayerSpeed = PlayerMaxSpeed;
        _PlayerX = PlayerX;
        _PlayerXP = PlayerXP;
        _PlayerY = PlayerY;
        _PlayerZ = PlayerZ;
        _StartDelay = StartDelay;
        _Timer = Timer;
        _일시정지 = 일시정지;

        _SoundRestart = SoundRestart;

        _MinecraftGame = MinecraftGame;
        _ADOFAIGame = ADOFAIGame;

        _ButtonPointer = ButtonPointer;
        _LeftKey = LeftKey;
        _RightKey = RightKey;
        _DownKey = DownKey;
        _UpKey = UpKey;
        _leftKeyUp = leftKeyUp;
        _rightKeyUp = rightKeyUp;
        _upKeyUp = upKeyUp;
        _downKeyUp = downKeyUp;
        _ZKey = ZKey;
        _XKey = XKey;
        _CKey = CKey;
        _InvKey = InvKey;
        _MinusKey = MinusKey;
        _PlusKey = PlusKey;

        _GameTime = GameTime;
        _RealTime = RealTime;

        _Graphic = Graphic;
        _GUIAni = GUIAni;
        _BlockAni = BlockAni;
        _CameraAni = CameraAni;
        _TalkAni = TalkAni;
        _Particle = Particle;
    }
    public void Action(GameObject scanNPC)
    {
        if (대화창TextEffect.isAnim == false && Input.GetKey(KeyCode.C) == false && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
        {
            talkPanel.SetActive(true);
            NpcData npcData = scanNPC.GetComponent<NpcData>();
            Talk(npcData.NpcTalk);
        }

        if (Input.GetKey(KeyCode.C) && NpcEventManager.b && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
        {
            talkPanel.SetActive(true);
            NpcData npcData = scanNPC.GetComponent<NpcData>();
            Talk(npcData.NpcTalk);
        }
    }

    public void Talk(List<string> talk)
    {
        if (talk.Count == talkIndex)
        {
            TalkEnd();
            return;
        }

        string talkData = talk[talkIndex];

        isAction = true;

        talkeffect.SetMsg(talkData);
        talkIndex++;
    }

    public void TalkEnd()
    {
        talkeffect.EffectEnd();
        isAction = false;
        talkPanel.SetActive(false);
        talkIndex = 0;
    }

    public void GameQuit() => Application.Quit();
    
    //세이브
    public void saveData(bool GameOver)
    {
        Debug.Log("Save Data!");

        SaveData.playerData.MainMenu = MainMenu;
        SaveData.playerData.PlayerX = PlayerX;
        SaveData.playerData.PlayerY = PlayerY;
        SaveData.playerData.PlayerZ = PlayerZ;
        SaveData.playerData.MainCameraPos = MainCamera.MainCameraPos;

        SaveData.playerData.PlayerMaxHP = PlayerMaxHP;
        if (GameOver)
            SaveData.playerData.PlayerHP = 0;
        else
            SaveData.playerData.PlayerHP = PlayerHP;
        SaveData.playerData.PlayerMaxHG = PlayerMaxHG;
        SaveData.playerData.PlayerHG = PlayerHG;
        SaveData.playerData.Air = Player.Air;
        SaveData.playerData.FallDamage = Player.FallDamage;

        SaveData.playerData.PlayerAS = PlayerAS;
        SaveData.playerData.PlayerLevel = PlayerLevel;
        SaveData.playerData.PlayerMaxXP = PlayerMaxXP;
        SaveData.playerData.PlayerXP = PlayerXP;
        SaveData.playerData.PlayerGold = PlayerGold;

        SaveData.playerData.PlayerSpeed = PlayerMaxSpeed;
        SaveData.playerData.PlayerJumpPower = PlayerJumpPower;

        SaveData.playerData.Map = Map;

        SaveData.playerData.PlayerInv = PlayerInv;
        SaveData.playerData.PlayerInvMaxLine = PlayerInvMaxLine;

        SaveData.playerData.GameOverText = gameoverText;

        SaveData.playerData.GameMode = GameMode;


        SaveData.playerEventData.soft_lock = event_soft_lock.Play;

        SaveData.settingData.GUISize = GUISize;
        SaveData.settingData.Sky = TimeControl.Sky;
        SaveData.settingData.GameTime = TimeControl.TimeSetting;
        SaveData.settingData.dataTimeMinute = DayTimeMinute;
        SaveData.settingData.time = GameTime;
        SaveData.settingData.MainVolume = MainVolume;
        SaveData.settingData.Graphic = Graphic;
        SaveData.settingData.GUIAni = GUIAni;
        SaveData.settingData.CameraAni = CameraAni;
        SaveData.settingData.BlockAni = BlockAni;
        SaveData.settingData.TalkAni = TalkAni;
        SaveData.settingData.Particle = Particle;
        SaveData.settingData.PlayerLerpMove = PlayerLerpMove;
        SaveData.settingData.Game3D = MainCamera.Game3D;

        SaveData.saveData();
    }

    //로드
    public static void loadData()
    {
        Debug.Log("Load Data!");

        SaveData.loadData();

        MainMenu = SaveData.playerData.MainMenu;
        PlayerX = SaveData.playerData.PlayerX;
        PlayerY = SaveData.playerData.PlayerY;
        PlayerZ = SaveData.playerData.PlayerZ;
        MainCamera.MainCameraPos = SaveData.playerData.MainCameraPos;

        PlayerMaxHP = SaveData.playerData.PlayerMaxHP;
        PlayerHP = SaveData.playerData.PlayerHP;
        PlayerMaxHG = SaveData.playerData.PlayerMaxHG;
        PlayerHG = SaveData.playerData.PlayerHG;
        Player.Air = SaveData.playerData.Air;
        Player.FallDamage = SaveData.playerData.FallDamage;

        PlayerAS = SaveData.playerData.PlayerAS;
        PlayerLevel = SaveData.playerData.PlayerLevel;
        PlayerMaxXP = SaveData.playerData.PlayerMaxXP;
        PlayerXP = SaveData.playerData.PlayerXP;
        PlayerGold = SaveData.playerData.PlayerGold;

        PlayerMaxSpeed = SaveData.playerData.PlayerSpeed;
        PlayerJumpPower = SaveData.playerData.PlayerJumpPower;

        Map = SaveData.playerData.Map;
        

        PlayerInv = SaveData.playerData.PlayerInv;
        PlayerInvMaxLine = SaveData.playerData.PlayerInvMaxLine;

        gameoverText = SaveData.playerData.GameOverText;

        GameMode = SaveData.playerData.GameMode;

        event_soft_lock.Play = SaveData.playerEventData.soft_lock;

        GUISize = SaveData.settingData.GUISize;
        TimeControl.Sky = SaveData.settingData.Sky;
        TimeControl.TimeSetting = SaveData.settingData.GameTime;
        DayTimeMinute = SaveData.settingData.dataTimeMinute;
        GameTime = SaveData.settingData.time;
        MainVolume = SaveData.settingData.MainVolume;
        Graphic = SaveData.settingData.Graphic;
        GUIAni = SaveData.settingData.GUIAni;
        CameraAni = SaveData.settingData.CameraAni;
        BlockAni = SaveData.settingData.BlockAni;
        TalkAni = SaveData.settingData.TalkAni;
        Particle = SaveData.settingData.Particle;
        PlayerLerpMove = SaveData.settingData.PlayerLerpMove;
        MainCamera.Game3D = SaveData.settingData.Game3D;
    }
    
    //리셋
    public void PlayerDataReset(bool b)
    {
        if (!isAction)
            dataReset_i += 1;
        if (b)
            dataResetMessage = true;
        if (dataReset_i == 4 || !b)
        {
            if (!isAction)
            {
                Debug.Log("Data Reset!");

                dataReset_i = 0;
                dataReset = true;
                if (isAction)
                    return;

                SaveData.playerData.MainMenu = true;
                SaveData.playerData.PlayerX = 0;
                SaveData.playerData.PlayerY = -4;
                SaveData.playerData.PlayerZ = 0;
                SaveData.playerData.MainCameraPos = new Vector3(0, -0.5f, 14);

                SaveData.playerData.PlayerMaxHP = 130;
                SaveData.playerData.PlayerHP = 130;
                SaveData.playerData.PlayerMaxHG = 20;
                SaveData.playerData.PlayerHG = 20;
                SaveData.playerData.Air = 300;
                SaveData.playerData.FallDamage = 0;

                SaveData.playerData.PlayerAS = 0.2f;
                SaveData.playerData.PlayerLevel = 0;
                SaveData.playerData.PlayerMaxXP = 30;
                SaveData.playerData.PlayerXP = 0;
                SaveData.playerData.PlayerGold = 300;

                SaveData.playerData.PlayerSpeed = 5;
                SaveData.playerData.PlayerJumpPower = 9;

                SaveData.playerData.Map = 0;

                PlayerInv.Clear();
                SaveData.playerData.PlayerInv = PlayerInv;
                SaveData.playerData.PlayerInvMaxLine = 5;

                SaveData.playerData.GameMode = 2;

                SaveData.playerEventData.soft_lock = false;

                if (b)
                {
                    SaveData.settingData.GUISize = GUISize;
                    SaveData.settingData.Sky = TimeControl.Sky;
                    SaveData.settingData.GameTime = TimeControl.TimeSetting;
                    SaveData.settingData.dataTimeMinute = DayTimeMinute;
                    SaveData.settingData.MainVolume = MainVolume;
                    SaveData.settingData.Graphic = Graphic;
                    SaveData.settingData.GUIAni = GUIAni;
                    SaveData.settingData.CameraAni = CameraAni;
                    SaveData.settingData.BlockAni = BlockAni;
                    SaveData.settingData.TalkAni = TalkAni;
                    SaveData.settingData.Particle = Particle;
                    SaveData.settingData.PlayerLerpMove = PlayerLerpMove;
                    SaveData.settingData.Game3D = MainCamera.Game3D;
                }
                else
                {
                    SaveData.settingData.GUISize = Screen.width / 1280f;
                    SaveData.settingData.Sky = true;
                    SaveData.settingData.GameTime = TimeControl.TimeSetting;
                    SaveData.settingData.dataTimeMinute = -1;
                    SaveData.settingData.MainVolume = 0.9f;
                    SaveData.settingData.Graphic = 0;
                    SaveData.settingData.GUIAni = 0;
                    SaveData.settingData.CameraAni = 0;
                    SaveData.settingData.BlockAni = 0;
                    SaveData.settingData.TalkAni = 0;
                    SaveData.settingData.Particle = true;
                    SaveData.settingData.PlayerLerpMove = 1;
                    SaveData.settingData.Game3D = true;
                }
                SaveData.settingData.time = 6000;

                SaveData.saveData();

                SaveData.playerData.GameOverText = "";
                if (b)
                {
                    mainMenu();
                    event_soft_lock.Stop = true;
                    일시정지Canvas.PauseToggle();
                    Invoke("PlayerDataResetNextCode", 1 / 60);
                }
            }
        }
    }

    void PlayerDataResetNextCode()
    {
        loadData();

        dataReset_i = 0;
        dataReset = false;
        Timer = 0;
    }

    public void GameOver(string gameOverText)
    {
        Debug.Log("Game Over : " + gameOverText);

        gameoverText = gameOverText;
        GameOverText.text = "MinedApple(이)가 " + gameOverText;
        일시정지 = true;
        PlayerDamage(0, true, 0);
        player.GameOver();
        PlayerHP = 0.0001f;
        MainMenu = false;
    }

    //플레이어 데미지
    public void PlayerDamage(float damage, bool set, int type)
    {
        if (!일시정지 && !isAction && PlayerHP > 0.0001F)
        {
            if (PlayerHP < 0)
            {
                PlayerHP = 0;

                PlayerDamageMaterial.PlayerDamage = false;
            }

            //무적 시간
            if (PlayerDamageDelayTimer < PlayerDamageDelay + Time.deltaTime && ((damage < PlayerHP && set) || (PlayerHP - damage < PlayerHP && !set)))
            {
                if (PlayerY > -15)
                    Debug.Log("Player Damage Cancel");

                if (!MainMenu)
                    PlayerHP += damage;
            }
            else if (PlayerDamageDelayTimer >= PlayerDamageDelay + Time.deltaTime && ((damage < PlayerHP && set) || (PlayerHP - damage < PlayerHP && !set)))
            {
                if (!set)
                    Debug.Log("Player Damage " + damage);
                else
                    Debug.Log("Player Damage " + (PlayerHP - damage));

                PlayerDamageMaterial.PlayerDamage = true;

                PlayerDamageDelayTimer = 0;

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

                player.PlayerDamage();
                if ((Graphic == 0 && CameraAni == 0) || CameraAni == 1)
                    mainCamera.transform.localRotation = Quaternion.Euler(0, 0, 1.5f);
            }
            
            if (!MainMenu)
                if (set)
                    PlayerHP = damage;
                else
                    PlayerHP -= damage;
        }
    }

    void OnApplicationQuit()
    {
        if (PlayerHP <= 0.0001f)
            saveData(true);
        else
            saveData(false);

        Debug.Log("Game Quit!");
    }

    public void dataReset_ireset() => dataReset_i = 0;

    public void mainMenu()
    {
        player.MainMenu();
        BeatManager.NextBeatRestart();
        MainMenu = true;
    }

    public void ButtonDown(string Button)
    {
        ButtonPointer = true;

        switch (Button)
        {
            case "Left":
                LeftKey = true;
                break;
            case "Right":
                RightKey = true;
                break;
            case "Up":
                UpKey = true;
                break;
            case "Down":
                DownKey = true;
                break;
            case "Z":
                ZKey = true;
                break;
            case "X":
                XKey = true;
                break;
            case "C":
                CKey = true;
                break;
            case "M":
                if (!MainMenu)
                    if (Player.rigid.velocity.x <= 0.0025f && Player.rigid.velocity.x >= -0.0025f && Player.rigid.velocity.y <= 0.0025f && Player.rigid.velocity.y >= -0.0025f)
                    {
                        PlayerAV = PlayerMaxAV;
                        mainMenu();
                    }
                break;
            case "-":
                MinusKey = true;
                break;
            case "+":
                PlusKey = true;
                break;
        }
    }

    public void ButtonUp(string Button)
    {
        ButtonPointer = false;

        switch (Button)
        {
            case "Left":
                LeftKey = false;
                leftKeyUp = true;
                break;
            case "Right":
                RightKey = false;
                rightKeyUp = true;
                break;
            case "Up":
                UpKey = false;
                break;
            case "Down":
                DownKey = false;
                break;
            case "C":
                CKey = false;
                break;
        }
    }
}