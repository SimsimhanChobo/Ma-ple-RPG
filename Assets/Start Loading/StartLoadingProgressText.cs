﻿using UnityEngine;
using UnityEngine.UI;

public class StartLoadingProgressText : MonoBehaviour
{
    public Image progressBar;
    public Text text;

    void LateUpdate()
    {
        if (progressBar.fillAmount < 0.995f && progressBar.fillAmount != 0)
            text.text = Mathf.Ceil(progressBar.fillAmount * 100) + "%";
        else if (progressBar.fillAmount != 0)
            text.text = "Resource Loading...";
    }
}
