using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayerSkin : MonoBehaviour
{
    public GameObject PlayerPos;

    Vector3 MousePos;

    void LateUpdate()
    {
        if (InvManager.InventoryShow)
        {
            MousePos = Input.mousePosition;
            MousePos.x -= 565f * (Screen.width / 1280f);
            MousePos.y -= 470f * (Screen.width / 1280f);
            MousePos.z += 100;

            PlayerPos.transform.localPosition = new Vector3(0, 0, 0);

            SkinRotation.skinLookAt(PlayerPos, MousePos, "All", true);
            if (PlayerPos.transform.localRotation.w >= 0)
            {
                SkinRotation.skinRotation(gameObject, "All", Quaternion.Euler(PlayerPos.transform.localEulerAngles.x * 0.25f, (-PlayerPos.transform.localEulerAngles.y - 180) * 0.5f, 0), true);
                SkinRotation.skinRotation(gameObject, "Head", Quaternion.Euler(PlayerPos.transform.localEulerAngles.x * 0.25f, (((-PlayerPos.transform.localEulerAngles.y - 180) * 0.5f) + 180) * 0.5f, 0), true);
            }
            else
            {
                SkinRotation.skinRotation(gameObject, "All", Quaternion.Euler((PlayerPos.transform.localEulerAngles.x - 360) * 0.25f, (-PlayerPos.transform.localEulerAngles.y - 180) * 0.5f, 0), true);
                SkinRotation.skinRotation(gameObject, "Head", Quaternion.Euler((PlayerPos.transform.localEulerAngles.x - 360) * 0.25f, (((-PlayerPos.transform.localEulerAngles.y - 180) * 0.5f) + 180) * 0.5f, 0), true);
            }

            PlayerPos.transform.localPosition = new Vector2(0, 15);
        }

        //애니메이션
        if (GameManager.PlayerMove && GameManager.PlayerHP > 0.0001f)
        {
            if (Player.MoveAniTimer >= 0.3f)
                if (Player.MoveB)
                {
                    Player.MoveAniTimer = 0;
                    Player.MoveB = false;
                }
                else
                {
                    Player.MoveAniTimer = 0;
                    Player.MoveB = true;
                }

            if (Player.MoveB)
            {
                SkinRotation.skinRotation(gameObject, "Left Arm", new Vector3(90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Right Arm", new Vector3(-90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Left Leg", new Vector3(-90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Right Leg", new Vector3(90f, 0, 0), false, 0.065f);
            }
            else
            {
                SkinRotation.skinRotation(gameObject, "Left Arm", new Vector3(-90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Right Arm", new Vector3(90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Left Leg", new Vector3(90f, 0, 0), false, 0.065f);
                SkinRotation.skinRotation(gameObject, "Right Leg", new Vector3(-90f, 0, 0), false, 0.065f);
            }
        }
        else
        {
            SkinRotation.skinRotation(gameObject, "Left Arm", new Vector3(0, 0, 0));
            SkinRotation.skinRotation(gameObject, "Right Arm", new Vector3(0, 0, 0));
            SkinRotation.skinRotation(gameObject, "Left Leg", new Vector3(0, 0, 0));
            SkinRotation.skinRotation(gameObject, "Right Leg", new Vector3(0, 0, 0));
        }
    }
}
