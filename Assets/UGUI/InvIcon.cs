using UnityEngine;
using UnityEngine.UI;

public class InvIcon : MonoBehaviour
{
    public Image Image;

    int i = 0;

    string PlayerInvItemTemp;

    void Update()
    {
        i = 0;
        while (i < 9)
        {
            if (transform.localPosition.x == 20 * i)
            {
                ItemIcon(i);
                return;
            }
            i++;
        }
    }

    void ItemIcon(int variable)
    {
        string SelectItem = "";

        if (GameManager.PlayerInv.Count > variable + 9 * GameManager.PlayerInvLine)
            SelectItem = GameManager.PlayerInv[variable + 9 * GameManager.PlayerInvLine];
        else
            SelectItem = "air";

        //아이템 표시
        if (PlayerInvItemTemp != GameManager.PlayerInvItem)
        {
            Texture2D texture2D = ResourceManager.ResourceSearch<Texture2D>(ResourceManager.ItemTexturePath + SelectItem);

            if (texture2D != null)
                Image.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 16);
            PlayerInvItemTemp = GameManager.PlayerInvItem;
        }
    }

    public void ItemIconButton()
    {
        int ii = 0;
        while (ii < 9)
        {
            if (transform.localPosition.x == 20 * ii)
            {
                if (ii == 0)
                    GameManager.PlayerInvCannes = 0;
                else if (ii == 1)
                    GameManager.PlayerInvCannes = 1;
                else if (ii == 2)
                    GameManager.PlayerInvCannes = 2;
                else if (ii == 3)
                    GameManager.PlayerInvCannes = 3;
                else if (ii == 4)
                    GameManager.PlayerInvCannes = 4;
                else if (ii == 5)
                    GameManager.PlayerInvCannes = 5;
                else if (ii == 6)
                    GameManager.PlayerInvCannes = 6;
                else if (ii == 7)
                    GameManager.PlayerInvCannes = 7;
                else if (ii == 8)
                    GameManager.PlayerInvCannes = 8;
            }
            ii++;
        }
    }
}
