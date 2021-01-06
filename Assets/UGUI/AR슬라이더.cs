using UnityEngine;
using UnityEngine.UI;

public class AR슬라이더 : MonoBehaviour
{
    public Slider AR;
    public Slider HP;

    void Update()
    {
        AR.maxValue = 300;
        AR.value = Mathf.Lerp(AR.value, Player.Air, 0.1f * (60 * Time.deltaTime));
    }
}
