using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTextureChange : MonoBehaviour
{
    public Sprite sprite;

    void Start() => StartCoroutine(TextureChange(sprite));

    public IEnumerator TextureChange(Sprite sprite)
    {
        yield return new WaitUntil(() => Vector3.Distance(MainCamera.Camera.transform.position, new Vector3(transform.position.x, transform.position.y, MainCamera.Camera.transform.position.z)) <= 20);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
