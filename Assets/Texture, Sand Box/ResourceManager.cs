using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static readonly List<string> ResourcePackPath = new List<string>();

    public static Texture2D Null = new Texture2D(16, 16);
    static readonly List<Vector2> UvsTemp = new List<Vector2>();
    static Rect[] RectTemp;

    static byte[] byteTexture;

    public static Texture2D ResourceLoad(string Path)
    {
        Texture2D TextureLoadTemp = new Texture2D(0, 0);

        int i = 0;
        bool b = true;
        while (b)
        {
            if (i >= ResourcePackPath.Count)
            {
                if (File.Exists(Application.streamingAssetsPath + "/Basic Resource/" + Path + ".png"))
                    byteTexture = File.ReadAllBytes(Application.streamingAssetsPath + "/Basic Resource/" + Path + ".png");
                if (byteTexture.Length > 0)
                {
                    TextureLoadTemp.name = "temp";
                    TextureLoadTemp.LoadImage(byteTexture);
                }

                return TextureLoadTemp;
            }
            if (i < ResourcePackPath.Count)
                if (!File.Exists(ResourcePackPath[i] + Path + ".png"))
                {
                    if (File.Exists(Application.streamingAssetsPath + "/Basic Resource/" + Path + ".png"))
                        byteTexture = File.ReadAllBytes(Application.streamingAssetsPath + "/Basic Resource/" + Path + ".png");
                    if (byteTexture.Length > 0)
                    {
                        TextureLoadTemp.name = "temp";
                        TextureLoadTemp.LoadImage(byteTexture);
                    }

                    return TextureLoadTemp;
                }
            
            if (File.Exists(ResourcePackPath[i] + Path + ".png"))
                byteTexture = File.ReadAllBytes(ResourcePackPath[i] + Path + ".png");
            if (byteTexture.Length > 0)
            {
                TextureLoadTemp.name = "temp";
                TextureLoadTemp.LoadImage(byteTexture);
            }
            else
                b = false;

            i++;
        }

        Debug.Log(TextureLoadTemp.name);
        return TextureLoadTemp;
    }

    public static Texture2D GetBlockTextures(List<Texture2D> BlockTexture, out Vector2[] Uvs)
    {
        Texture2D background = new Texture2D(48, 96);
        RectTemp = background.PackTextures(BlockTexture.ToArray(), 0, 8192);
        UvsTemp.Clear();

        //for (int i = 0; i < BlockTexture.Count; i++)
            //Debug.Log("BlockTexture " + BlockTexture[i]);

        for (int i = 0; i < 6; i++)
        {
            UvsTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y));
            UvsTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y + RectTemp[i].height));
            UvsTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y));
            UvsTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y));
            UvsTemp.Add(new Vector2(RectTemp[i].x, RectTemp[i].y + RectTemp[i].height));
            UvsTemp.Add(new Vector2(RectTemp[i].x + RectTemp[i].width, RectTemp[i].y + RectTemp[i].height));
            //Debug.Log("RectTemp " + RectTemp[i]);
        }

        //for (int i = 0; i < 6 * 6; i++)
            //Debug.Log("UvsTemp " + UvsTemp[i]);

        Uvs = UvsTemp.ToArray();

        return background;
    }

#pragma warning disable IDE0060 // 사용하지 않는 매개 변수를 제거하세요.
    public static void ResourcePackAdd(string Path)
#pragma warning restore IDE0060 // 사용하지 않는 매개 변수를 제거하세요.
    {
        if (Path[Path.Length - 1].ToString() == "/")
            ResourcePackPath.Add(Path);
        else
            ResourcePackPath.Add(Path + "/");
    }

    public static void ResourceReload()
    {

    }
}
