using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    public Sprite _air;

    public Sprite _cooked_beef;
    public Sprite _cooked_porkchop;
    public Sprite _pumpkin_pie;
    public Sprite _wooden_sword;


    public static Sprite air;

    public static Sprite cooked_beef;
    public static Sprite cooked_porkchop;
    public static Sprite pumpkin_pie;
    public static Sprite wooden_sword;

    void Awake()
    {
        air = _air;
        cooked_beef = _cooked_beef;
        cooked_porkchop = _cooked_porkchop;
        pumpkin_pie = _pumpkin_pie;
        wooden_sword = _wooden_sword;
    }
}
