using UnityEngine;
using UnityEngine.UI;

public class DebugLogClone : MonoBehaviour
{
    public RectTransform DebugLogBackground;
    public RectTransform DebugLogText;

    public Image DebugLogBackground2;
    public Text DebugLogText2;

    public DebugLogClone debugLogClone;

    public float Timer = 0;
    public int cloneCount = 0;
    public static int cloneCount2 = 0;
    public float i = 1;

    void Awake()
    {
        DebugLogText2.text = DebugModeLog.DebugLogMessage.ToString();
        transform.localPosition = new Vector2(0, -52 * 0.5f);
    }

    void Update()
    {
        if (!DebugText.DebugActive)
        {
            DebugLogBackground2.color = new Color(1, 1, 1, 0);
            DebugLogText2.color = new Color(0, 0, 0, 0);
            DebugLogBackground.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            DebugLogBackground2.color = new Color(1, 1, 1, 1);
            DebugLogText2.color = new Color(0, 0, 0, 1);
            DebugLogBackground.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        Timer += Time.unscaledDeltaTime;

        DebugLogBackground.sizeDelta = new Vector2(DebugLogText.sizeDelta.x * 0.25f + 48, DebugLogText.sizeDelta.y * 0.25f + 24);
        transform.localPosition = Vector2.Lerp(transform.localPosition, new Vector2(0, -52 * (cloneCount - cloneCount2 + 1) * 0.5f), 0.125f * (60 * Time.unscaledDeltaTime));
        
        if (Timer >= 5)
        {
            i -= 0.05f * (60 * Time.unscaledDeltaTime);
            if (!DebugText.DebugActive)
            {
                Destroy(gameObject);
            }
            else
            {
                DebugLogBackground2.color = new Color(1, 1, 1, i);
                DebugLogText2.color = new Color(0, 0, 0, i);

            }
            
            if (DebugLogText2.color.a <= 0)
            {
                cloneCount2++;
                Destroy(gameObject);
            }
        }
    }

    public void CloneCount()
    {
        cloneCount++;
    }
}
