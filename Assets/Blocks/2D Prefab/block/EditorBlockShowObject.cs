using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorBlockShowObject : MonoBehaviour
{
    /*void Update()
    {
        BlockSetting blockSetting = transform.parent.GetComponent<BlockSetting>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (blockSetting.blockType == BlockType.Normal && blockSetting.Texture.width == 16 && blockSetting.Texture.height == 16)
            spriteRenderer.sprite = Sprite.Create(blockSetting.Texture, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f), 16);
        if (blockSetting.blockType == BlockType.SideTopBottom && blockSetting.Side.width == 16 && blockSetting.Side.height == 16)
            spriteRenderer.sprite = Sprite.Create(blockSetting.Side, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f), 16);
        if (blockSetting.blockType == BlockType.SideTopBottomFront && blockSetting.Side2Front.width == 16 && blockSetting.Side2Front.height == 16)
            spriteRenderer.sprite = Sprite.Create(blockSetting.Side2Front, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f), 16);
        if (blockSetting.blockType == BlockType.SideTopBottomFrontBack && blockSetting.Side3Front.width == 16 && blockSetting.Side3Front.height == 16)
            spriteRenderer.sprite = Sprite.Create(blockSetting.Side3Front, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f), 16);
    }*/
}
