using System.Collections;
using UnityEngine;

public class BlockAni : MonoBehaviour
{
    public Texture2D Texture;

    public int Line = 1;
    public float Delay = 1;

    int index = 0;

    Sprite sprite;

    float Timer;
    
    SpriteRenderer spriteRenderer;

    void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    void Start()
    {
        sprite = Sprite.Create(Texture, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f), 16);
        spriteRenderer.sprite = sprite;
        spriteRenderer.size = new Vector2(1, 0.99f);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Delay && GameManager.BlockAni == 1 || (GameManager.Graphic == 0 && GameManager.BlockAni == 0))
        {
            Destroy(sprite);

            index++;
            if (index > Line)
                index = 1;

            sprite = Sprite.Create(Texture, new Rect(0, Texture.height - (Texture.height / Line * index), 16, Texture.height / Line), new Vector2(0.5f, 0.5f), 16);
            spriteRenderer.sprite = sprite;
            spriteRenderer.size = new Vector2(1, 0.99f);
        }
    }
}
