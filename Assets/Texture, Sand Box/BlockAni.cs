using System.Collections;
using UnityEngine;

public class BlockAni : MonoBehaviour
{
    public Texture2D Texture;

    public int Line = 1;
    public float Delay = 1;

    int index = 0;

    Sprite sprite;

    
    SpriteRenderer spriteRenderer;

    void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    void Start() => StartCoroutine("blockAni");

    IEnumerator blockAni()
    {
        while (true)
        {
            yield return new WaitUntil(() => Vector3.Distance(MainCamera.Camera.transform.position, new Vector3(transform.position.x, transform.position.y, MainCamera.Camera.transform.position.z)) <= 20);

            Destroy(sprite);

            index++;
            if (index > Line)
                index = 1;

            sprite = Sprite.Create(Texture, new Rect(0, Texture.height - (Texture.height / Line * index), 16, Texture.height / Line), new Vector2(0.5f, 0.5f), 16);
            spriteRenderer.sprite = sprite;
            spriteRenderer.size = new Vector2(1, 0.99f);

            if (Delay > 0)
                yield return new WaitForSeconds(Delay);
            else
                yield return null;

            yield return new WaitUntil(() => (GameManager.Graphic == 0 && GameManager.BlockAni == 0) || GameManager.BlockAni == 1 && Vector3.Distance(MainCamera.Camera.transform.position, new Vector3(transform.position.x, transform.position.y, MainCamera.Camera.transform.position.z)) <= 20);
        }
    }
}
