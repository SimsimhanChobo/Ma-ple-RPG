using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HGTimerSlider : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.maxValue = 4;
        slider.value = Mathf.Lerp(slider.value, 4 - GameManager.PlayerHGExhaustionLevel, 0.1f * (60 * Time.deltaTime));
    }
}
