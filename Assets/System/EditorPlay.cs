using UnityEngine;

[ExecuteInEditMode]
public class EditorPlay : MonoBehaviour
{
    void Awake()
    {
        if (!Application.isPlaying)
            GamePlay.EditorPlay = true;
    }
}