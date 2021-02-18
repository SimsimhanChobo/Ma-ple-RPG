using System.Collections;
using UnityEngine;

public class ADOFAIPlayer : MonoBehaviour
{
    public int i = 0;
    public bool BluePlayer = false;
    public SpriteRenderer spriteRenderer;
    public Sprite Red;
    public Sprite Blue;

    public static bool GameStart = false;

    void Awake()
    {
        GameStart = true;
    }

    void Start()
    {
        i = 0;
        GameManager.Timer = 0;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, -(GameManager.CurrentBeat * 180f) + i);

        if (GameManager.Pitch > 0)
        {
            if (-(GameManager.CurrentBeat * 180f) + i <= -180)
            {
                transform.Translate(Vector3.left * 1.35f);

                i += 180;
                transform.localRotation = Quaternion.Euler(0, 0, -(GameManager.CurrentBeat * 180f) + i);
                if (BluePlayer)
                {
                    spriteRenderer.sprite = Red;
                    BluePlayer = false;
                }
                else
                {
                    spriteRenderer.sprite = Blue;
                    BluePlayer = true;
                }
            }
        }
        else
        {
            if (-(GameManager.CurrentBeat * 180f) + i >= 0)
            {
                transform.Translate(Vector3.left * 1.35f);

                i -= 180;
                transform.localRotation = Quaternion.Euler(0, 0, -(GameManager.CurrentBeat * 180f) + i);
                if (BluePlayer)
                {
                    spriteRenderer.sprite = Red;
                    BluePlayer = false;
                }
                else
                {
                    spriteRenderer.sprite = Blue;
                    BluePlayer = true;
                }
            }
        }

        IList list = System.Enum.GetValues(typeof(KeyCode));
        for (int i1 = 0; i1 < list.Count; i1++)
        {
            KeyCode vKey = (KeyCode)list[i1];
            if (Input.GetKeyDown(vKey))
            {
                transform.Translate(Vector3.left * 1.35f);

                i += 180;
                transform.localRotation = Quaternion.Euler(0, 0, -(GameManager.CurrentBeat * 180f) + i);
                if (BluePlayer)
                {
                    spriteRenderer.sprite = Red;
                    BluePlayer = false;
                }
                else
                {
                    spriteRenderer.sprite = Blue;
                    BluePlayer = true;
                }
            }
        }
    }
}
