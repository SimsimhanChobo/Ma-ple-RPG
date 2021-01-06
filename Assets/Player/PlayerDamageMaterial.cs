using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageMaterial : MonoBehaviour
{
    public static bool PlayerDamage = false;
    bool PlayerDamageTemp = true;

    Renderer Renderer;

    void Awake() => Renderer = GetComponent<Renderer>();

    void Update()
    {
        if (!PlayerDamage && PlayerDamageTemp)
        {
            Renderer.material.color = new Color(1, 1, 1);
            Renderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
            PlayerDamageTemp = false;
        }
        if (PlayerDamage && !PlayerDamageTemp)
        {
            Renderer.material.color = new Color(1, 0.5f, 0.5f);
            Renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0, 0));
            PlayerDamageTemp = true;
        }
    }
}
