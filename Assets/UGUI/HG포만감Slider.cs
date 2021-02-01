using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HG포만감Slider : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.maxValue = Mathf.Lerp(slider.maxValue, GameManager.PlayerMaxHG, 0.1f * (60 * Time.deltaTime));
        slider.value = Mathf.Lerp(slider.value, GameManager.PlayerHGSaturationLevel, 0.1f * (60 * Time.deltaTime));
    }
}
