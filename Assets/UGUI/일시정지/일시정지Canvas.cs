using UnityEngine;
using UnityEngine.UI;

public class 일시정지Canvas : MonoBehaviour
{
    public GameObject gameobjcet;
    public Text GuiSizeSettingButtonText;
    public Text GUI비율ButtonText;
    public Button 게임시간Button;
    public Text 게임시간ButtonText;
    public Text 하늘ButtonText;
    public InputField 하루InputField;
    public Text 그래픽ButtonText;
    public Text GUI애니메이션ButtonText;
    public Text 카메라애니메이션ButtonText;
    public Text 블록애니메이션ButtonText;
    public Text 대화애니메이션ButtonText;
    public Text 입자ButtonText;
    public Text 플레이어부드러운움직임ButtonText;
    public Text 모드2DText;

    public GameObject 게임메뉴화면;
    public GameObject 설정화면;
    public GameObject 비디오설정화면;
    public GameObject 세부설정화면;
    public GameObject 애니메이션설정화면;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.PlayerHP > 0.0001f && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            PauseToggle();

        if (GameManager.GUISize > Screen.width / 1280f)
            GameManager.GUISize = 0.5f;

        if (TimeControl.TimeSetting > 5)
        {
            GameManager.GameTime = 6000;
            TimeControl.TimeSetting = 0;
        }

        GuiSizeSettingButtonText.text = "GUI Size " + GameManager.GUISize + "X";

        GUI비율ButtonText.text = "GUI 비율: " + GameManager.GUISize;

        if (TimeControl.TimeSetting == 0)
            게임시간ButtonText.text = "게임 시간: 기본";
        else if (TimeControl.TimeSetting == 1)
            게임시간ButtonText.text = "게임 시간: 현실 시간";
        else if (TimeControl.TimeSetting == 2)
            게임시간ButtonText.text = "게임 시간: 낮";
        else if (TimeControl.TimeSetting == 3)
            게임시간ButtonText.text = "게임 시간: 정오";
        else if (TimeControl.TimeSetting == 4)
            게임시간ButtonText.text = "게임 시간: 밤";
        else if (TimeControl.TimeSetting == 5)
            게임시간ButtonText.text = "게임 시간: 한밤중";

        if (TimeControl.Sky)
            하늘ButtonText.text = "하늘: 켜짐";
        else if (!TimeControl.Sky)
            하늘ButtonText.text = "하늘: 꺼짐";

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameManager.MainVolume;

        if (GameManager.Graphic == 0)
            그래픽ButtonText.text = "그래픽: 화려하게";
        else if (GameManager.Graphic == 1)
            그래픽ButtonText.text = "그래픽: 빠르게";

        if (GameManager.GUIAni == 0)
            GUI애니메이션ButtonText.text = "GUI 애니메이션: 기본";
        else if (GameManager.GUIAni == 1)
            GUI애니메이션ButtonText.text = "GUI 애니메이션: 화려하게";
        else if (GameManager.GUIAni == 2)
            GUI애니메이션ButtonText.text = "GUI 애니메이션: 빠르게";

        if (GameManager.CameraAni == 0)
            카메라애니메이션ButtonText.text = "카메라 애니메이션: 기본";
        else if (GameManager.CameraAni == 1)
            카메라애니메이션ButtonText.text = "카메라 애니메이션: 화려하게";
        else if (GameManager.CameraAni == 2)
            카메라애니메이션ButtonText.text = "카메라 애니메이션: 빠르게";

        if (GameManager.BlockAni == 0)
            블록애니메이션ButtonText.text = "블록 애니메이션: 기본";
        else if (GameManager.BlockAni == 1)
            블록애니메이션ButtonText.text = "블록 애니메이션: 화려하게";
        else if (GameManager.BlockAni == 2)
            블록애니메이션ButtonText.text = "블록 애니메이션: 빠르게";

        if (GameManager.TalkAni == 0)
            대화애니메이션ButtonText.text = "대화 애니메이션: 기본";
        else if (GameManager.TalkAni == 1)
            대화애니메이션ButtonText.text = "대화 애니메이션: 화려하게";
        else if (GameManager.TalkAni == 2)
            대화애니메이션ButtonText.text = "대화 애니메이션: 빠르게";

        if (GameManager.Particle)
            입자ButtonText.text = "입자: 켜짐";
        else
            입자ButtonText.text = "입자: 꺼짐";

        if (GameManager.PlayerLerpMove == 0)
            플레이어부드러운움직임ButtonText.text = "플레이어 부드러운 움직임: 화려하게";
        else if (GameManager.PlayerLerpMove == 1)
            플레이어부드러운움직임ButtonText.text = "플레이어 부드러운 움직임: 빠르게";
        else if (GameManager.PlayerLerpMove == 2)
            플레이어부드러운움직임ButtonText.text = "플레이어 부드러운 움직임: 꺼짐";

        if (MainCamera.Game3D)
            모드2DText.text = "2D 모드: 꺼짐";
        else
            모드2DText.text = "2D 모드: 켜짐";
    }

    public void PauseToggle()
    {
        if (GameManager.Pause)
        {
            GameManager.Pause = false;
            gameobjcet.SetActive(false);
            게임메뉴화면.SetActive(true);
            설정화면.SetActive(false);
            비디오설정화면.SetActive(false);
            세부설정화면.SetActive(false);
            애니메이션설정화면.SetActive(false);
        }
        else
        {
            GameManager.Pause = true;
            gameobjcet.SetActive(true);
        }
    }

    public void GuiSizeSettings() => GameManager.GUISize += 0.5f;

    public void GameTime() => TimeControl.TimeSetting++;

    public void Sky()
    {
        if (!TimeControl.Sky)
            TimeControl.Sky = true;
        else if (TimeControl.Sky)
            TimeControl.Sky = false;
    }

    public void Graphic()
    {
        if (GameManager.Graphic == 0)
            GameManager.Graphic = 1;
        else if (GameManager.Graphic == 1)
            GameManager.Graphic = 0;
    }

    public void GUIAni()
    {
        if (GameManager.GUIAni == 0)
            GameManager.GUIAni = 2;
        else if (GameManager.GUIAni == 1)
            GameManager.GUIAni = 0;
        else if (GameManager.GUIAni == 2)
            GameManager.GUIAni = 1;
    }

    public void CameraAni()
    {
        if (GameManager.CameraAni == 0)
            GameManager.CameraAni = 2;
        else if (GameManager.CameraAni == 1)
            GameManager.CameraAni = 0;
        else if (GameManager.CameraAni == 2)
            GameManager.CameraAni = 1;
    }

    public void BlockAni()
    {
        if (GameManager.BlockAni == 0)
            GameManager.BlockAni = 2;
        else if (GameManager.BlockAni == 1)
            GameManager.BlockAni = 0;
        else if (GameManager.BlockAni == 2)
            GameManager.BlockAni = 1;
    }
    public void TalkAni()
    {
        if (GameManager.TalkAni == 0)
            GameManager.TalkAni = 2;
        else if (GameManager.TalkAni == 1)
            GameManager.TalkAni = 0;
        else if (GameManager.TalkAni == 2)
            GameManager.TalkAni = 1;
    }

    public void ParticleToggle()
    {
        if (GameManager.Particle)
            GameManager.Particle = false;
        else
            GameManager.Particle = true;
    }

    public void PlayerLerpMove()
    {
        if (GameManager.PlayerLerpMove == 0)
            GameManager.PlayerLerpMove = 2;
        else if (GameManager.PlayerLerpMove == 1)
            GameManager.PlayerLerpMove = 0;
        else if (GameManager.PlayerLerpMove == 2)
            GameManager.PlayerLerpMove = 1;
    }
}
