using UnityEngine;
using UnityEngine.UI;

public class StartPadeImage : MonoBehaviour
{
    public Image image;
    float i = 1f;
    void Awake() => image.color = new Color(0, 0, 0, 1);

    void Update()
    {
        image.color = new Color(0, 0, 0, i);
        i -= 0.075f * (60 * Time.deltaTime);
        if (i <= 0)
            Destroy(gameObject);
    }
}
