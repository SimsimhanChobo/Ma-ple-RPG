using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraSelectMainCamera : MonoBehaviour
{
    void Awake() => GetComponent<Canvas>().worldCamera = MainCamera.Camera;
}
