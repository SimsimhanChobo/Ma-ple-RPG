using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvasSkinFrontChange : MonoBehaviour
{
    public bool Wear = false;

    public static int Change = 1;

    [ContextMenu("Skin Change")]
    void change() => Change = 1;

    void Update()
    {
        if ((Change == 0 && !Wear) || (Change == 1 && Wear))
        {
            Change -= 1;

            Texture2D Skin = SkinRotation.PlayerObject.GetComponent<PlayerSkinChange>().Skin;
            Image image = GetComponent<Image>();

            if (!Wear)
            {
                Sprite sprite = Sprite.Create(Skin, new Rect(8, 48, 8, 8), new Vector2(0.5f, 0.5f));
                image.sprite = sprite;
            }
            else
            {
                Sprite sprite = Sprite.Create(Skin, new Rect(40, 48, 8, 8), new Vector2(0.5f, 0.5f));
                image.sprite = sprite;
            }
        }
    }
}
