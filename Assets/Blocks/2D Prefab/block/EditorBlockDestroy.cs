using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorBlockDestroy : MonoBehaviour
{
    void Awake() => Destroy(gameObject);
}
