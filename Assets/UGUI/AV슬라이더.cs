using UnityEngine;
using UnityEngine.UI;

public class AV슬라이더 : MonoBehaviour
{
    public Slider AV;

    void Update()
    {
        AV.maxValue = Mathf.Lerp(AV.maxValue, GameManager.PlayerMaxAV, 0.3f * (60 * Time.deltaTime));
        AV.value = Mathf.Lerp(AV.value, GameManager.PlayerAV, 0.3f * (60 * Time.deltaTime));
    }
}
