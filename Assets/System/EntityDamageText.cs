using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamageText : MonoBehaviour
{
    float Timer = 0;

    void OnEnable() => GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);

    void Update()
    {
        if (transform.localPosition.y <= 1.45f)
        {
            transform.localPosition = new Vector2(0, 1.45f);
            Timer += Time.deltaTime;
            if (Timer >= 2)
                Destroy(gameObject.transform.parent.parent.gameObject);
        }
    }
}
