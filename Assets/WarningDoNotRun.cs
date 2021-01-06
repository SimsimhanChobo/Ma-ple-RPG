using UnityEngine;

public class WarningDoNotRun : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            Texture2D texture2D = new Texture2D(8192, 8192);
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                
            Instantiate(gameObject, transform, transform);
            Debug.Log(texture2D = new Texture2D(8192, 8192));
        }
    }
}