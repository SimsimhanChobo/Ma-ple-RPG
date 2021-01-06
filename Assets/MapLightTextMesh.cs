using UnityEngine;

public class MapLightTextMesh : MonoBehaviour
{
    public Color color = new Color(1, 1, 1, 1);
    public bool Opposition = false;
    public bool All = false;

    [HideInInspector]
    public float Brightness = 0;

    void Update()
    {
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();

        if (Opposition && !All)
        {
            if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
                Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0739474f));
            if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
                Brightness = 0;
            if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
                Brightness = 1f / (255f / (TimeControl.time3 * 0.07f));
            if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
                Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.07f));
            if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
                Brightness = 1;

            textMesh.color = new Color((1 - Brightness) * color.r, (1 - Brightness) * color.g, (1 - Brightness) * color.b, color.a);
        }
        else if (!All)
        {
            if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
                Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0539474f + 50f));
            if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
                Brightness = 1f / (255f / 50f);
            if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
                Brightness = 1f / (255f / (TimeControl.time3 * 0.0539474f + 50f));
            if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
                Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.0539474f + 50f));
            if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
                Brightness = 1;

            textMesh.color = new Color(Brightness * color.r, Brightness * color.g, Brightness * color.b, color.a);
        }
        else if (Opposition && All)
        {
            if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
                Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0739474f));
            if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
                Brightness = 0;
            if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
                Brightness = 1f / (255f / (TimeControl.time3 * 0.07f));
            if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
                Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.07f));
            if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
                Brightness = 1;

            textMesh.color = new Color((1 - Brightness) * color.r, (1 - Brightness) * color.g, (1 - Brightness) * color.b, color.a);
        }
        else if (All)
        {
            if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
                Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0739474f));
            if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
                Brightness = 0;
            if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
                Brightness = 1f / (255f / (TimeControl.time3 * 0.07f));
            if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
                Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.07f));
            if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
                Brightness = 1;

            textMesh.color = new Color(Brightness * color.r, Brightness * color.g, Brightness * color.b, color.a);
        }
    }
}
