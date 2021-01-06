using UnityEngine;
using UnityEngine.UI;

public class HP슬라이더 : MonoBehaviour
{
    public Slider HP;

    void Update()
    {
        HP.maxValue = Mathf.Lerp(HP.maxValue, GameManager.PlayerMaxHP, 0.1f * (60 * Time.deltaTime));
        HP.value = Mathf.Lerp(HP.value, GameManager.PlayerHP, 0.1f * (60 * Time.deltaTime));
    }
}
