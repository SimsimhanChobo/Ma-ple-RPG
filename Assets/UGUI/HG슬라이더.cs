using UnityEngine;
using UnityEngine.UI;

public class HG슬라이더 : MonoBehaviour
{
    public Slider HG;

    void Update()
    {
        HG.maxValue = Mathf.Lerp(HG.maxValue, GameManager.PlayerMaxHG, 0.1f * (60 * Time.deltaTime));
        HG.value = Mathf.Lerp(HG.value, GameManager.PlayerHG, 0.1f * (60 * Time.deltaTime));
    }
}
