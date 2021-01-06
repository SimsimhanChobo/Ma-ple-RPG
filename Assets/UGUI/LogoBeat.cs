using UnityEngine;

public class LogoBeat : MonoBehaviour
{
    public float NextBeat = 0;
    Vector3 target = new Vector2(0, 90);

    void Update()
    {
        if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
            //transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));
            transform.localPosition = new Vector2(Mathf.Lerp(transform.localPosition.x, target.x, 0.125f * (60 * Time.deltaTime)), Mathf.Lerp(transform.localPosition.y, target.y, 0.125f * (60 * Time.deltaTime)));

        else
            transform.localPosition = target;

        if (GameManager.Pitch > 0)
        {
            if (NextBeat < GameManager.CurrentBeat)
            {
                NextBeat += 1;
                if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                    transform.localPosition = new Vector2(0, 90 + 3);
            }
        }

        if (GameManager.Pitch < 0)
        {
            if (NextBeat > GameManager.CurrentBeat)
            {
                NextBeat -= 1;
                if ((GameManager.Graphic == 0 && GameManager.GUIAni == 0) || GameManager.GUIAni == 1)
                    transform.localPosition = new Vector2(0, 90 + 3);
            }
        }
    }
}
