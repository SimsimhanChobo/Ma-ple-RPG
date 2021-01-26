using UnityEngine;

[ExecuteInEditMode]
public class MapManager : MonoBehaviour
{
    public static Grid Grid;
    public static GameObject GameObject;

    void Update()
    {
        if (GamePlay.EditorPlay)
        {
            GameObject = gameObject;
            Grid = GetComponent<Grid>();
        }
    }
}