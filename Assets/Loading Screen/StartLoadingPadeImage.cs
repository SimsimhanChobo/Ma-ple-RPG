using UnityEngine;
using UnityEngine.UI;

public class StartLoadingPadeImage : MonoBehaviour
{
    public Image progressBar;

    public Canvas StartPadeLoadingUI;

    public Text Logo;
    public Text PleasWait;
    public Image Background;
    public Text LoadingProgressText;

    public float i = 1;

    public int NextBeat = 0;

    void Awake()
    {
        if (Loading.LoadingScreenHide)
            Destroy(gameObject);

        if (!StartLoading.b)
        {
            StartLoading.b = true;
            GameManager.loadData();
        }

        StartPadeLoadingUI.scaleFactor = GameManager.GUISize;

        Logo.text = Loading.logoText;
        Logo.color = new Color(1, 1, 1, 1);
        PleasWait.color = new Color(1, 1, 1, 1);
        Background.color = new Color(0, 0, 0, 1);
        progressBar.color = new Color(1, 1, 1, 1);
        LoadingProgressText.color = new Color(1, 1, 1, 1);

    }

    void Update()
    {
        Logo.color = new Color(1, 1, 1, i);
        PleasWait.color = new Color(1, 1, 1, i);
        Background.color = new Color(0, 0, 0, i);
        progressBar.color = new Color(1, 1, 1, i);
        LoadingProgressText.color = new Color(1, 1, 1, i);

        i -= 0.025f * GameManager.GameSpeed;
        if (i <= 0)
            Destroy(gameObject);
    }
}
