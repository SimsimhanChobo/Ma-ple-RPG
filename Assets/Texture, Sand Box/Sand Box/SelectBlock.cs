using UnityEngine;

public class SelectBlock : MonoBehaviour
{
    public GameObject 마플캐릭터판정;
    public RaycastHit2D Block;
    public Vector3 BackTarget;
    public Vector3 target;

    void Update()
    {
        BackTarget = target;

        transform.position = new Vector2(Mathf.Round(마플캐릭터판정.transform.position.x) + 0.5f, Mathf.Round(마플캐릭터판정.transform.position.y) + 1.5f);

        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 14));
        target = new Vector2(Mathf.Floor(target.x) + 0.5f, Mathf.Floor(target.y) + -0.5f);

        if (Mathf.Round(마플캐릭터판정.transform.position.x) - target.x > 0)
        {
            Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(-(마플캐릭터판정.transform.position.x - target.x), 0, 0), new Color(0, 1, 0));
            for (int i = 0; i < Mathf.Round(마플캐릭터판정.transform.position.x) - target.x; i++)
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);

                Block = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), new Vector3(0, 0.01f, 0), Mathf.Infinity, LayerMask.GetMask("Map"));

                if (Block.collider != null)
                {
                    Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(-(마플캐릭터판정.transform.position.x - transform.position.x) + 1, 0, 0), new Color(1, 0, 0));
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y);

                    return;
                }
            }
        }
        else if (Mathf.Round(마플캐릭터판정.transform.position.x) - target.x < 0)
        {
            Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(-(마플캐릭터판정.transform.position.x - target.x), 0, 0), new Color(0, 1, 0));
            for (int i = 0; i < Mathf.Abs(Mathf.Round(마플캐릭터판정.transform.position.x) - target.x) - 1; i++)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);

                RaycastHit2D Block = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), new Vector3(0, 0.01f, 0), Mathf.Infinity, LayerMask.GetMask("Map"));

                if (Block.collider != null)
                {
                    Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(-(마플캐릭터판정.transform.position.x - transform.position.x) - 1, 0, 0), new Color(1, 0, 0));
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);

                    return;
                }
            }
        }

        if (Mathf.Round(마플캐릭터판정.transform.position.y) - target.y > 0)
        {
            Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(0, -(마플캐릭터판정.transform.position.y - target.y) + 0.5f, 0), new Color(0, 1, 0));
            for (int i = 0; i < Mathf.Round(마플캐릭터판정.transform.position.y) - target.y; i++)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);

                Block = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector3(0, 0.01f, 0), Mathf.Infinity, LayerMask.GetMask("Map"));

                if (Block.collider != null)
                {
                    Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(0, -(마플캐릭터판정.transform.position.y - transform.position.y) + 0.5f, 0), new Color(1, 0, 0));
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1);

                    return;
                }
            }
        }
        else if (Mathf.Round(마플캐릭터판정.transform.position.y) - target.y < 0)
        {
            Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(0, -(마플캐릭터판정.transform.position.y - target.y) + 0.5f, 0), new Color(0, 1, 0));
            for (int i = 0; i < Mathf.Abs(Mathf.Round(마플캐릭터판정.transform.position.y) - target.y) - 1; i++)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1);

                Block = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), new Vector3(0, 0.01f, 0), Mathf.Infinity, LayerMask.GetMask("Map"));

                if (Block.collider != null)
                {
                    Debug.DrawRay(new Vector2(마플캐릭터판정.transform.position.x, 마플캐릭터판정.transform.position.y + 0.5f), new Vector3(0, -(마플캐릭터판정.transform.position.y - transform.position.y) + 0.5f, 0), new Color(1, 0, 0));
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1);

                    return;
                }
            }
        }
    }
}
