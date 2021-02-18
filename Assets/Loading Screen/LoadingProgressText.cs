using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressText : MonoBehaviour
{
    public Image progressBar;
    public Text text;

    void LateUpdate()
    {
        if (progressBar.fillAmount < 1 && progressBar.fillAmount != 0)
            text.text = Mathf.Ceil(progressBar.fillAmount * 100) + "%";
        else if (progressBar.fillAmount != 0)
            text.text = "Resource Loading...";
    }
}
