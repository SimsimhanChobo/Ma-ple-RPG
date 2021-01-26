using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLoading : MonoBehaviour
{
    public Image progressBar;

    public Canvas LoadingUI;

    public Text 마플RPG;
    public Text PleaseWait;
    public Image LoadingBarBackground;
    public Text LoadingProgressText;

    public float i = -0.3f;
    public float ii = 0;
    public bool iii = true;

    public static bool b = false;

    void Start()
    {
        GameManager.loadData();

        GameManager.GUISize = SaveData.settingData.GUISize;
        LoadingUI.scaleFactor = GameManager.GUISize;

        b = true;
    }

    void Update()
    {
        if (iii)
        {
            마플RPG.color = new Color(1, 1, 1, i);
            i += 0.025f * (60 * Time.deltaTime);

            if (i > 1.5)
            {
                PleaseWait.color = new Color(1, 1, 1, ii);
                LoadingBarBackground.color = new Color(1, 1, 1, ii);
                progressBar.color = new Color(1, 1, 1, ii);
                LoadingProgressText.color = new Color(1, 1, 1, ii);
                ii += 0.025f * (60 * Time.deltaTime);

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
        AsyncOperation op = SceneManager.LoadSceneAsync("마플 RPG System");
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, 0.05f * (60 * Time.deltaTime));
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1, 0.05f * (60 * Time.deltaTime));
                if (progressBar.fillAmount >= 0.995f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
