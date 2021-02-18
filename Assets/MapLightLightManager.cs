using UnityEngine;

public class MapLightLightManager : MonoBehaviour
{
    public Color color = new Color(1, 1, 1, 1);

    [HideInInspector]
    public float Brightness = 0;

    void Update()
    {
        Light light = gameObject.GetComponent<Light>();
        if (Brightness < 0)
            Brightness = 0;
        else if (Brightness > 1)
            Brightness = 1;
        light.color = new Color((1 - Brightness) * color.r, (1 - Brightness) * color.g, (1 - Brightness) * color.b, color.a);
    }
}
