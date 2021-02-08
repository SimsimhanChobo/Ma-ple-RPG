using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DiscordPresence;

public class Loading : MonoBehaviour
{
    public static bool isLoading = false;

    public Image progressBar;

    public Canvas LoadingUI;

    public Text Logo;
    public Text PleaseWait;
    public Image LoadingBarBackground;
    public Text LoadingProgressText;

    public float i = -0.3f;
    public float ii = 0;
    public bool iii = true;

    static string nextScene;
    public static string logoText = "마플 RPG";

    public static void LoadScene(string sceneName, string LogoText)
    {
        isLoading = true;

        if (!GameManager.isAction)
        {
            nextScene = sceneName;
            logoText = LogoText;
            SceneManager.LoadScene("Loading Screen");
        }
        else if (GameManager.isAction)
        {
            WarningMessage.isActionNextLoading();
        }
        else if (GameManager.일시정지)
        {
            WarningMessage.일시정지NextLoading();
        }
    }

    void Start()
    {
        Debug.Log(nextScene + " Scene Loading!");
        PresenceManager.UpdatePresence(detail: nextScene + " Loading...", state: "");

        Logo.text = logoText;

        if (nextScene == "마플 RPG")
            GameManager.MainMenu = true;
    }

    void Update()
    {
        LoadingUI.scaleFactor = GameManager.GUISize;

        if (iii)
        {
            Logo.color = new Color(1, 1, 1, i);
            i += 0.025f * (60 * Time.unscaledDeltaTime);

            if (i > 1.5)
            {
                PleaseWait.color = new Color(1, 1, 1, ii);
                LoadingBarBackground.color = new Color(1, 1, 1, ii);
                progressBar.color = new Color(1, 1, 1, ii);
                LoadingProgressText.color = new Color(1, 1, 1, ii);
                ii += 0.025f * (60 * Time.unscaledDeltaTime);

                if (ii >= 1)
                {
                    StartCoroutine(LoadSceneProcess());
                    iii = false;
                }
            }
        }
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, 0.05f * (60 * Time.unscaledDeltaTime));
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1, 0.05f * (60 * Time.unscaledDeltaTime));
                if (progressBar.fillAmount >= 0.995f)
                {
                    op.allowSceneActivation = true;
                    isLoading = false;
                    yield break;
                }
            }
        }
    }
}
