using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainVolChange : MonoBehaviour
{
    Slider slider;

    void Awake() => slider = GetComponent<Slider>();

    void Start() => slider.value = GameManager.MainVolume * 100;

    void Update() => GameManager.MainVolume = slider.value * 0.01f;
}
