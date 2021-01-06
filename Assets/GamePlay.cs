using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static bool EditorPlay = true;

    void Awake() => EditorPlay = false;

    void Start() => EditorPlay = false;

    void Update() => EditorPlay = false;
}
