using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftSkyboxColorChange : MonoBehaviour
{
    public Material SkyBox;

    public Color DayTopColor;
    public Color DayBottomColor;

    public Color NightTopColor;
    public Color NightBottomColor;

    public Color color;

    float Brightness;
    float Brightness2;
    float Brightness3;

    public static bool CustomColor = false;
    public static Color CustomColorTop;
    public static Color CustomColorBottom;

    Color tempTopColor;
    Color tempBottomColor;

    void Update()
    {
        RenderSettings.skybox = SkyBox;

        if (!CustomColor)
        {
            if (TimeControl.GameTime >= 10000 && TimeControl.GameTime <= 13800)
            {
                Brightness = 1f / (255f / ((3800 - TimeControl.time2) * 0.0739474f));
                Brightness2 = 4 / (255f / ((3800 - TimeControl.time2) * 0.0739474f)) - 2;
                Brightness3 = 4 / (255f / ((3800 - TimeControl.time2) * 0.0739474f)) - 1;

                tempTopColor = Color.Lerp(tempTopColor, Color.Lerp(DayTopColor, NightTopColor, 1 - Brightness), 0.05f * 60 * Time.deltaTime);
                RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);

                if (Brightness2 <= 0)
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(color, Color.Lerp(DayBottomColor, NightBottomColor, 1 - Brightness), 1 - Brightness3), 0.05f * 60 * Time.deltaTime);
                else
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(Color.Lerp(DayBottomColor, NightBottomColor, 1 - Brightness), color, 1 - Brightness2), 0.05f * 60 * Time.deltaTime);

                RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);
            }
            else if (TimeControl.GameTime > 13800 && TimeControl.GameTime < 22500)
            {
                Brightness = 0;

                tempTopColor = Color.Lerp(tempTopColor, NightTopColor, 0.05f * 60 * Time.deltaTime);
                tempBottomColor = Color.Lerp(tempBottomColor, NightBottomColor, 0.05f * 60 * Time.deltaTime);
                RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);
                RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);
            }
            else if (TimeControl.GameTime >= 22500 && TimeControl.GameTime <= 24000)
            {
                Brightness = 1f / (255f / (TimeControl.time3 * 0.07f));
                Brightness2 = 4 / (255f / (TimeControl.time3 * 0.07f)) - 1.7f;
                Brightness3 = 4 / (255f / (TimeControl.time3 * 0.07f)) - 0.7f;

                tempTopColor = Color.Lerp(tempTopColor, Color.Lerp(NightTopColor, DayTopColor, Brightness), 0.05f * 60 * Time.deltaTime);
                RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);

                if (Brightness2 <= 0)
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(color, Color.Lerp(NightBottomColor, DayBottomColor, Brightness), 1 - Brightness3), 0.05f * 60 * Time.deltaTime);
                else
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(Color.Lerp(NightBottomColor, DayBottomColor, Brightness), color, 1 - Brightness2), 0.05f * 60 * Time.deltaTime);

                RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);
            }
            else if (TimeControl.GameTime >= 0 && TimeControl.GameTime < 2300)
            {
                Brightness = 1f / (255f / ((TimeControl.GameTime + 1500) * 0.07f));
                Brightness2 = 4 / (255f / ((TimeControl.GameTime + 1500) * 0.07f)) - 1.7f;
                Brightness3 = 4 / (255f / ((TimeControl.GameTime + 1500) * 0.07f)) - 0.7f;

                tempTopColor = Color.Lerp(tempTopColor, Color.Lerp(NightTopColor, DayTopColor, Brightness), 0.05f * 60 * Time.deltaTime);
                RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);

                if (Brightness2 <= 0)
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(color, Color.Lerp(NightBottomColor, DayBottomColor, Brightness), 1 - Brightness3), 0.05f * 60 * Time.deltaTime);
                else
                    tempBottomColor = Color.Lerp(tempBottomColor, Color.Lerp(Color.Lerp(NightBottomColor, DayBottomColor, Brightness), color, 1 - Brightness2), 0.05f * 60 * Time.deltaTime);

                RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);
            }
            else if (TimeControl.GameTime >= 2300 && TimeControl.GameTime < 10000)
            {
                Brightness = 1;

                tempTopColor = Color.Lerp(tempTopColor, DayTopColor, 0.05f * 60 * Time.deltaTime);
                tempBottomColor = Color.Lerp(tempBottomColor, DayBottomColor, 0.05f * 60 * Time.deltaTime);
                RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);
                RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);
            }

            if (TimeControl.Sky)
                RenderSettings.skybox.SetFloat("_SkyExponent1", 20);
            else
                RenderSettings.skybox.SetFloat("_SkyExponent1", 0);
        }
        else
        {
            tempTopColor = Color.Lerp(tempTopColor, CustomColorTop, 0.05f * 60 * Time.deltaTime);
            tempBottomColor = Color.Lerp(tempBottomColor, CustomColorBottom, 0.05f * 60 * Time.deltaTime);

            RenderSettings.skybox.SetColor("_SkyColor1", tempTopColor);
            RenderSettings.skybox.SetColor("_SkyColor2", tempBottomColor);

            if (TimeControl.Sky)
                RenderSettings.skybox.SetFloat("_SkyExponent1", 20);
            else
                RenderSettings.skybox.SetFloat("_SkyExponent1", 0);
        }
    }

    void OnApplicationQuit()
    {
        RenderSettings.skybox.SetColor("_SkyColor1", DayTopColor);
        RenderSettings.skybox.SetColor("_SkyColor2", DayBottomColor);
    }
}
