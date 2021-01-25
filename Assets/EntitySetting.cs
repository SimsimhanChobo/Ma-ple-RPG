using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySetting : MonoBehaviour
{
    public MobType mobType;

    public float MaxHP;
    float HP;
    float AV;
}

public enum MobType
{
    None,
    Slime,
    Undead,
    Zombie,
    Skeleton
}
