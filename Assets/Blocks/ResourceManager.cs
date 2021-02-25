using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    readonly public static string BlockTexturePath = "assets/minecraft/textures/block/";
    readonly public static string ColorMapTexturePath = "assets/minecraft/textures/colormap/";
    readonly public static string EffectTexturePath = "assets/minecraft/textures/effect/";
    readonly public static string EntityTexturePath = "assets/minecraft/textures/entity/";
    readonly public static string EnvironmentTexturePath = "assets/minecraft/textures/environment/";
    readonly public static string GuiTexturePath = "assets/minecraft/textures/gui/";
    readonly public static string ItemTexturePath = "assets/minecraft/textures/item/";
    readonly public static string MapTexturePath = "assets/minecraft/textures/Map/";
    readonly public static string MiscTexturePath = "assets/minecraft/textures/misc/";
    readonly public static string MobEffectTexturePath = "assets/minecraft/textures/mob_effect/";
    readonly public static string ModelsTexturePath = "assets/minecraft/textures/models/";
    readonly public static string PaintingTexturePath = "assets/minecraft/textures/painting/";
    readonly public static string ParticleTexturePath = "assets/minecraft/textures/particle/";

    public static T ResourceSearch<T>(string Path)
    {
        T ret;
        ret = (T)Convert.ChangeType(Resources.Load(Path), typeof(T));
        return ret;
    }
}
