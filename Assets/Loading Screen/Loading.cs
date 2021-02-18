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

    public static bool LoadingScreenHide = false;

    public static void LoadScene(string sceneName, string LogoText, bool LoadingScreen)
    {
        if (LoadingScreen)
        {
            LoadingScreenHide = false;

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
        else
        {
            LoadingScreenHide = true;
            SceneManager.LoadScene(sceneName);
        }
    }

    void Start()
    {
        Debug.Log(nextScene + " Scene Loading!");
        PresenceManager.UpdatePresence(detail: nextScene + " Loading...", state: "");

        Logo.text = logoText;

        LoadingUI.scaleFactor = GameManager.GUISize;

        Logo.color = new Color(1, 1, 1, 1);
        PleaseWait.color = new Color(1, 1, 1, 1);
        LoadingBarBackground.color = new Color(1, 1, 1, 1);
        progressBar.color = new Color(1, 1, 1, 1);
        LoadingProgressText.color = new Color(1, 1, 1, 1);

        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
                progressBar.fillAmount = op.progress;
            else
            {
                progressBar.fillAmount = 1;
                yield return null;
                isLoading = false;
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
