using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftSkyboxColorChange : MonoBehaviour
{
    public Color DayTopColor;
    public Color DayBottomColor;

    public Color NightTopColor;
    public Color NightBottomColor;

    public Color color;

    public float Brightness;
    public float Brightness2;
    public float Brightness3;

    void Update()
    {
        if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
        {
            Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0739474f));
            Brightness2 = 4 / (255f / ((3800 - TimeControl.time2) * 0.0739474f)) - 2;
            Brightness3 = 4 / (255f / ((3800 - TimeControl.time2) * 0.0739474f)) - 1;
            RenderSettings.skybox.SetColor("_SkyColor1", Color.Lerp(DayTopColor, NightTopColor, 1 - Brightness));

            if (Brightness2 <= 0)
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(color, Color.Lerp(DayBottomColor, NightBottomColor, 1 - Brightness), 1 - Brightness3));
            else
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(Color.Lerp(DayBottomColor, NightBottomColor, 1 - Brightness), color, 1 - Brightness2));
        }
        else if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
        {
            Brightness = 0;
            RenderSettings.skybox.SetColor("_SkyColor1", NightTopColor);
            RenderSettings.skybox.SetColor("_SkyColor2", NightBottomColor);
        }
        else if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
        {
            Brightness = 1f / (255f / (TimeControl.time3 * 0.07f));
            Brightness2 = 4 / (255f / (TimeControl.time3 * 0.07f)) - 1.7f;
            Brightness3 = 4 / (255f / (TimeControl.time3 * 0.07f)) - 0.7f;

            RenderSettings.skybox.SetColor("_SkyColor1", Color.Lerp(NightTopColor, DayTopColor, Brightness));

            if (Brightness2 <= 0)
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(color, Color.Lerp(NightBottomColor, DayBottomColor, Brightness), 1 - Brightness3));
            else
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(Color.Lerp(NightBottomColor, DayBottomColor, Brightness), color, 1 - Brightness2));
        }
        else if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
        {
            Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.07f));
            Brightness2 = 4 / (255f / ((TimeControl.GameTime + 1500) * 0.07f)) - 1.7f;
            Brightness3 = 4 / (255f / ((TimeControl.GameTime + 1500) * 0.07f)) - 0.7f;

            RenderSettings.skybox.SetColor("_SkyColor1", Color.Lerp(NightTopColor, DayTopColor, Brightness));

            if (Brightness2 <= 0)
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(color, Color.Lerp(NightBottomColor, DayBottomColor, Brightness), 1 - Brightness3));
            else
                RenderSettings.skybox.SetColor("_SkyColor2", Color.Lerp(Color.Lerp(NightBottomColor, DayBottomColor, Brightness), color, 1 - Brightness2));
        }
        else if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
        {
            Brightness = 1;
            RenderSettings.skybox.SetColor("_SkyColor1", DayTopColor);
            RenderSettings.skybox.SetColor("_SkyColor2", DayBottomColor);
        }

        if (TimeControl.Sky)
            RenderSettings.skybox.SetFloat("_SkyExponent1", 20);
        else
            RenderSettings.skybox.SetFloat("_SkyExponent1", 0);
    }

    void OnApplicationQuit()
    {
        RenderSettings.skybox.SetColor("_SkyColor1", DayTopColor);
        RenderSettings.skybox.SetColor("_SkyColor2", DayBottomColor);
    }
}
