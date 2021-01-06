using UnityEngine;
using UnityEngine.UI;

public class Level슬라이더 : MonoBehaviour
{
    public Slider Level;

    void Update()
    {
        Level.maxValue = Mathf.Lerp(Level.maxValue, GameManager.PlayerMaxXP, 0.1f * (60 * Time.deltaTime));
        Level.value = Mathf.Lerp(Level.value, GameManager.PlayerXP, 0.1f * (60 * Time.deltaTime));
    }
}
