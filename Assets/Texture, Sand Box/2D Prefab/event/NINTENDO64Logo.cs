using UnityEngine;
using UnityEngine.UI;

public class NINTENDO64Logo : MonoBehaviour
{
    public static GameObject GameObject;
    public static bool Start = false;
    bool b = false;
    float f = 0;
    float ff = 0;

    void Awake() => GameObject = gameObject;

    void Update()
    {
        if (Start)
        {
            Image image = GameObject.GetComponent<Image>();
            RectTransform rectTransform = GameObject.GetComponent<RectTransform>();

            if (f >= 1)
                b = true;

            if (f <= 0 && b)
                Start = false;

            if (!b)
            {
                rectTransform.localScale = new Vector2(ff, ff);
                image.color = new Color(1, 1, 1, f);
                f += 0.05f * (60 * Time.deltaTime);
                ff -= 0.02f * (60 * Time.deltaTime);

                if (ff <= 0)
                    ff = 0;
            }
            else
            {
                rectTransform.localScale = new Vector2(ff, ff);
                image.color = new Color(1, 1, 1, f);
                f -= 0.05f * (60 * Time.deltaTime);
                ff -= 0.02f * (60 * Time.deltaTime);

                if (ff <= 0)
                    ff = 0;
            }
        }
        else
        {
            Image image = GameObject.GetComponent<Image>();
            RectTransform rectTransform = GameObject.GetComponent<RectTransform>();

            b = false;
            f = 0;
            ff = 1;

            rectTransform.localScale = new Vector2(ff, ff);
            image.color = new Color(1, 1, 1, f);
        }    
    }

    public static void event_soft_lock()
    {
        NINTENDO64Logo NINTENDO64Logo = GameObject.GetComponent<NINTENDO64Logo>();
        Start = true;
        NINTENDO64Logo.b = false;
        NINTENDO64Logo.f = 0;
        NINTENDO64Logo.ff = 1;
    }
}
