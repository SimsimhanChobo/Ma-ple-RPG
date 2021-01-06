using UnityEngine;

public class StartLoadingPadeImageBeat : MonoBehaviour
{
    public int NextBeat = 0;
    public Vector3 target;

    public bool b = false;

    void Update()
    {
        if (!b)
        {
            target = transform.localPosition;
            b = true;
        }

        transform.localPosition = Vector2.Lerp(transform.localPosition, target, 0.125f * (60 * Time.deltaTime));

        if (GameManager.Pitch > 0)
        {
            if (NextBeat < GameManager.CurrentBeat)
            {
                NextBeat += 1;
                transform.localPosition = new Vector2(target.x, target.y + 3f);
            }
        }

        if (GameManager.Pitch < 0)
        {
            if (NextBeat > GameManager.CurrentBeat)
            {
                NextBeat -= 1;
                transform.localPosition = new Vector2(target.x, target.y + 3f);
            }
        }
    }
}
