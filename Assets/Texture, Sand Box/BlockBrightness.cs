using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBrightness : MonoBehaviour
{
    public Color Color = Color.white;
    public static int BlockBrightnessLength = 4;
    Vector3 temp;

    int Brightness = 15;
    int tempBrightness = 15;

    public int Light = 0;

    void Awake()
    {
        temp = transform.position;
        BlockChange(0);
    }

    void Start()
    {
        if (Light != 0)
            BlockLight(transform.position, Light);
    }   

    /*void Update()
    {
        if (temp != transform.position)
            Reload(transform.position);

        temp = transform.position;
    }*/

    public static void Reload(Vector2 pos)
    {
        RaycastHit2D[] raycastHit2Ds = Physics2D.BoxCastAll(pos, new Vector2(20, 20), 0, Vector2.zero, 16, LayerMask.GetMask("Map", "Stairs", "Fire"));

        List<int> temp = new List<int>();

        for (int i = 0; i < raycastHit2Ds.Length; i++)
        {
            raycastHit2Ds[i].collider.gameObject.GetComponent<BlockBrightness>().BlockChange(0);

            if (raycastHit2Ds[i].collider.gameObject.GetComponent<BlockBrightness>().Light != 0)
                temp.Add(i);
        }

        for (int i = 0; i < temp.Count; i++)
            BlockLight(raycastHit2Ds[temp[i]].collider.transform.position, raycastHit2Ds[temp[i]].collider.gameObject.GetComponent<BlockBrightness>().Light);
    }

    public static void BlockLight(Vector2 pos, int Light)
    {
        for (int i = 0; i <= Mathf.Abs(Light); i++)
        {
            RaycastHit2D[] raycastHit2Ds = Physics2D.BoxCastAll(pos, new Vector2(Light - i, Light - i), 45, Vector2.zero, Mathf.Abs(Light) - i, LayerMask.GetMask("Map", "Stairs", "Fire"));

            for (int ii = 0; ii < raycastHit2Ds.Length; ii++)
            {
                BlockBrightness blockBrightness = raycastHit2Ds[ii].collider.gameObject.GetComponent<BlockBrightness>();
                blockBrightness.BlockChange(blockBrightness.Brightness + i);
            }
        }
    }


    public void BlockChange(int Light)
    {
        int Left = 0;
        int Right = 0;
        int Top = 0;
        int Bottom = 0;

        for (int i = 0; i <= 15 + BlockBrightnessLength; i++)
        {
            RaycastHit2D Sky = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), i, LayerMask.GetMask("Map", "Stairs", "Fire"));

            if (Sky.collider != null && i != 0)
            {
                RaycastHit2D[] sky = Physics2D.RaycastAll(transform.position + new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), BlockBrightnessLength, LayerMask.GetMask("Map", "Stairs", "Fire"));
                
                Left = (int)(i + (BlockBrightnessLength - sky.Length) * 15f / BlockBrightnessLength);
                break;
            }
            else if (i == 15)
                Left = 15;
        }

        for (int i = 0; i <= 15 + BlockBrightnessLength; i++)
        {
            RaycastHit2D Sky = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), new Vector3(1, 0, 0), i, LayerMask.GetMask("Map", "Stairs", "Fire"));

            if (Sky.collider != null && i != 0)
            {
                RaycastHit2D[] sky = Physics2D.RaycastAll(transform.position + new Vector3(1, 0, 0), new Vector3(1, 0, 0), BlockBrightnessLength, LayerMask.GetMask("Map", "Stairs", "Fire"));

                Right = (int)(i + (BlockBrightnessLength - sky.Length) * 15f / BlockBrightnessLength);
                break;
            }
            else if (i == 15)
                Right = 15;
        }

        for (int i = 0; i <= 15 + BlockBrightnessLength; i++)
        {
            RaycastHit2D Sky = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), new Vector3(0, 1, 0), i, LayerMask.GetMask("Map", "Stairs", "Fire"));

            if (Sky.collider != null && i != 0)
            {
                RaycastHit2D[] sky = Physics2D.RaycastAll(transform.position + new Vector3(0, 1, 0), new Vector3(0, 1, 0), BlockBrightnessLength, LayerMask.GetMask("Map", "Stairs", "Fire"));

                Top = (int)(i + (BlockBrightnessLength - sky.Length) * 15f / BlockBrightnessLength);
                break;
            }
            else if (i == 15)
                Top = 15;
        }

        for (int i = 0; i <= 15 + BlockBrightnessLength; i++)
        {
            RaycastHit2D Sky = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), new Vector3(0, -1, 0), i, LayerMask.GetMask("Map", "Stairs", "Fire"));

            if (Sky.collider != null && i != 0)
            {
                RaycastHit2D[] sky = Physics2D.RaycastAll(transform.position + new Vector3(0, -1, 0), new Vector3(0, -1, 0), BlockBrightnessLength, LayerMask.GetMask("Map", "Stairs", "Fire"));

                Bottom = (int)(i + (BlockBrightnessLength - sky.Length) * 15f / BlockBrightnessLength);
                break;
            }
            else if (i == 15)
                Bottom = 15;
        }

        RaycastHit2D[] left = Physics2D.RaycastAll(transform.position + new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), 15, LayerMask.GetMask("Map", "Stairs", "Fire"));
        RaycastHit2D[] right = Physics2D.RaycastAll(transform.position + new Vector3(1, 0, 0), new Vector3(1, 0, 0), 15, LayerMask.GetMask("Map", "Stairs", "Fire"));
        RaycastHit2D[] top = Physics2D.RaycastAll(transform.position + new Vector3(0, 1, 0), new Vector3(0, 1, 0), 15, LayerMask.GetMask("Map", "Stairs", "Fire"));
        RaycastHit2D[] bottom = Physics2D.RaycastAll(transform.position + new Vector3(0, -1, 0), new Vector3(0, -1, 0), 15, LayerMask.GetMask("Map", "Stairs", "Fire"));

        if (Light > 15)
            Light = 15;
        else if (Light < -15)
            Light = -15;

        if (Light == 0)
            Brightness = (Left / (left.Length + 1)) + (Right / (right.Length + 1)) + (Top / (top.Length + 1)) + (Bottom / (bottom.Length + 1));
        else
            Brightness = Light;

        blockChange();
    }

    void blockChange()
    {
        if (tempBrightness != Brightness)
            blockChange2();

        tempBrightness = Brightness;
    }


    void blockChange2()
    {
        if (Brightness < 0)
            Brightness = 0;
        else if (Brightness > 14)
            Brightness = 14;

        float brightness = Brightness / 14f;

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            Transform child = allChildren[i];
            Renderer Renderer = child.GetComponent<Renderer>();
            BlockBrightness blockBrightness = child.GetComponent<BlockBrightness>();
            if (Renderer != null && blockBrightness != null)
                Renderer.material.color = blockBrightness.Color * new Color(brightness, brightness, brightness);
            else if (Renderer != null)
                Renderer.material.color = new Color(brightness, brightness, brightness);
        }
    }
}