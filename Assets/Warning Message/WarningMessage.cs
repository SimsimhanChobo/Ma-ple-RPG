using UnityEngine;
using UnityEngine.UI;

public class WarningMessage : MonoBehaviour
{
    public static float i = 0;
    public static bool Start = false;
    public static bool Exit = false;
    public static Text Text;
    public Text text;
    UnityEngine.UI.Outline outline;

    void Awake()
    {
        Text = text;
        outline = GetComponent<UnityEngine.UI.Outline>();
    }

    void Update()
    {
        if (!GameManager.일시정지)
        {
            if (Input.GetKeyDown(KeyCode.M) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (Player.rigid.velocity.x > 0.0025f || Player.rigid.velocity.x < -0.0025f || Player.rigid.velocity.y > 0.0025f && Player.rigid.velocity.y < -0.0025f)
                {
                    Text.text = "캐릭터가 아직 움직이고 있습니다!";
                    Start = true;
                    Exit = false;
                    i = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.M) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (GameManager.MainMenu)
                {
                    Text.text = "메인화면에서 메인화면 버튼을 누를수 없습니다!";
                    Start = true;
                    Exit = false;
                    i = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.M) && !ChattingManager.ChattingActive && !InvManager.InventoryShow)
            {
                if (event_soft_lock.Play)
                {
                    Text.text = "아직 뒤주에 있습니다";
                    Start = true;
                    Exit = false;
                    i = 0;
                }
            }
        }

        if (GameManager.dataResetMessage)
        {
            if (GameManager.isAction)
            {
                GameManager.dataResetMessage = false;
                Text.text = "엑션(조사, 대화) 중에 데이터 리셋을 할수 없습니다!";
                Start = true;
                Exit = false;
                i = 0;
            }
            else if (GameManager.dataReset_i == 1)
            {
                GameManager.dataResetMessage = false;
                Text.text = "한번 더!";
                Start = true;
                Exit = false;
                i = 0;
            }
            else if (GameManager.dataReset_i == 2)
            {
                GameManager.dataResetMessage = false;
                Text.text = "한번만 더!";
                Start = true;
                Exit = false;
                i = 0;
            }
            else if (GameManager.dataReset_i == 3)
            {
                GameManager.dataResetMessage = false;
                Text.text = "마지막으로 한번 더!";
                Start = true;
                Exit = false;
                i = 0;
            }
            else if (GameManager.dataReset)
            {
                Text.text = "데이터 리셋됨!";
                Start = true;
                Exit = false;
                GameManager.dataResetMessage = false;
                i = 0;
            }
        }

        if (Start)
        {
            i += 0.05f * (60 * Time.unscaledDeltaTime);
            Text.color = new Color(1, 0, 0, i); //알파 값 변경
            outline.effectColor = new Color(1, 1, 1, i);

            if (i >= 4.5)
            {
                Start = false;
                Exit = true;
            }
        }

        if (Exit)
        {
            i -= 0.05f * (60 * Time.unscaledDeltaTime);
            Text.color = new Color(1, 0, 0, i); //알파 값 변경
            outline.effectColor = new Color(1, 1, 1, i);

            if (i <= 0)
            {
                Exit = false;
                Text.text = null;
            }
        }
    }

    public static void isActionNextLoading()
    {
        Text.text = "엑션(조사, 대화) 중에 로딩을 할수 없습니다!";
        Start = true;
        Exit = false;
        i = 0;
    }

    public static void 일시정지NextLoading()
    {
        Text.text = "일시정지 중에 로딩을 할수 없습니다!";
        Start = true;
        Exit = false;
        i = 0;
    }
}
