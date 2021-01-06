using UnityEngine;

public class PhoneControllerHide : MonoBehaviour
{
    public static bool phoneControllerHide = true;
    public Camera mainCamera;
    public Camera 벽Camera;
    public Camera PhoneControllerCamera;
    public GameObject 대화창NpcName;
    public RectTransform 대화창;
    public RectTransform 대화창Text;

    public RectTransform PhoneControllerCanvas;

    float i = 0;
    float i2 = 1;
    float i3 = 0;

    bool b = false;

    public GameObject LeftKey;
    public GameObject RightKey;
    public GameObject UpKey;
    public GameObject DownKey;
    public GameObject ZKey;
    public GameObject XKey;
    public GameObject CKey;
    public GameObject MKey;

    public GameObject 대화창선택지;

    public void PhoneController()
    {
        b = false;

        if (phoneControllerHide)
            phoneControllerHide = false;
        else
            phoneControllerHide = true;
    }

    void Update()
    {
        if (!GameManager.일시정지)
        {
            if (GameManager.MainMenu)
            {
                MKey.transform.SetSiblingIndex(0);
                ZKey.transform.SetSiblingIndex(1);
                DownKey.transform.SetSiblingIndex(2);
                UpKey.transform.SetSiblingIndex(3);
                UpKey.transform.SetSiblingIndex(4);
                DownKey.transform.SetSiblingIndex(5);
                XKey.transform.SetSiblingIndex(6);

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, -61), 0.125f * (Time.deltaTime * 60));
                    CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, -61), 0.125f * (Time.deltaTime * 60));
                }
                else
                {
                    ZKey.transform.localPosition = new Vector2(127, 190);
                    MKey.transform.localPosition = new Vector2(127, 190);
                    UpKey.transform.localPosition = new Vector2(127, 190);
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = new Vector2(127, 190);
                    XKey.transform.localPosition = new Vector2(65, -61);
                    CKey.transform.localPosition = new Vector2(191, -61);
                }
            }
            else if ((!GameManager.isAction) && (Player.rigid.velocity.x > 0.0025f || Player.rigid.velocity.x < -0.0025f || Player.rigid.velocity.y > 0.0025f || Player.rigid.velocity.y < -0.0025f || event_soft_lock.Play) && (Player.scanNPC == null))
            {
                MKey.transform.SetSiblingIndex(0);
                ZKey.transform.SetSiblingIndex(1);
                DownKey.transform.SetSiblingIndex(2);
                UpKey.transform.SetSiblingIndex(3);
                UpKey.transform.SetSiblingIndex(4);
                DownKey.transform.SetSiblingIndex(5);
                XKey.transform.SetSiblingIndex(6);

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, -61), 0.125f * (Time.deltaTime * 60));
                    CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, -61), 0.125f * (Time.deltaTime * 60));
                }
                else
                {
                    ZKey.transform.localPosition = new Vector2(127, 190);
                    MKey.transform.localPosition = new Vector2(127, 190);
                    UpKey.transform.localPosition = new Vector2(127, 190);
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = new Vector2(127, 190);
                    XKey.transform.localPosition = new Vector2(65, -61);
                    CKey.transform.localPosition = new Vector2(191, -61);
                }
            }
            else if ((!GameManager.isAction) && (Player.rigid.velocity.x > 0.0025f || Player.rigid.velocity.x < -0.0025f || Player.rigid.velocity.y > 0.0025f || Player.rigid.velocity.y < -0.0025f || event_soft_lock.Play) && (Player.scanNPC != null))
            {
                if (ZKey.transform.localPosition.y >= 314.025f)
                {
                    LeftKey.transform.SetSiblingIndex(0);
                    RightKey.transform.SetSiblingIndex(1);
                    DownKey.transform.SetSiblingIndex(2);
                    UpKey.transform.SetSiblingIndex(3);
                    MKey.transform.SetSiblingIndex(4);
                    ZKey.transform.SetSiblingIndex(5);
                    XKey.transform.SetSiblingIndex(6);
                }

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 315), 0.125f * (Time.deltaTime * 60));
                    MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 315), 0.125f * (Time.deltaTime * 60));
                    UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, -61), 0.125f * (Time.deltaTime * 60));
                    CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, -61), 0.125f * (Time.deltaTime * 60));
                }
                else
                {
                    ZKey.transform.localPosition = new Vector2(127, 315);
                    MKey.transform.localPosition = new Vector2(127, 315);
                    UpKey.transform.localPosition = new Vector2(127, 190);
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = new Vector2(127, 190);
                    XKey.transform.localPosition = new Vector2(65, -61);
                    CKey.transform.localPosition = new Vector2(191, -61);
                }
            }
            else if (!GameManager.isAction && Player.rigid.velocity.x <= 0.0025f && Player.rigid.velocity.x >= -0.0025f && Player.rigid.velocity.y <= 0.0025f && Player.rigid.velocity.y >= -0.0025f && !event_soft_lock.Play && Player.scanNPC == null)
            {
                MKey.transform.SetSiblingIndex(0);
                ZKey.transform.SetSiblingIndex(1);
                DownKey.transform.SetSiblingIndex(2);
                UpKey.transform.SetSiblingIndex(3);
                UpKey.transform.SetSiblingIndex(4);
                DownKey.transform.SetSiblingIndex(5);
                XKey.transform.SetSiblingIndex(6);

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 315), 0.125f * (Time.deltaTime * 60));
                    UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, -61), 0.125f * (Time.deltaTime * 60));
                    CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, -61), 0.125f * (Time.deltaTime * 60));
                }
                else
                {
                    ZKey.transform.localPosition = new Vector2(127, 190);
                    MKey.transform.localPosition = new Vector2(127, 315);
                    UpKey.transform.localPosition = new Vector2(127, 190);
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = new Vector2(127, 190);
                    XKey.transform.localPosition = new Vector2(65, -61);
                    CKey.transform.localPosition = new Vector2(191, -61);
                }
            }
            else if (!GameManager.isAction && Player.rigid.velocity.x <= 0.0025f && Player.rigid.velocity.x >= -0.0025f && Player.rigid.velocity.y <= 0.0025f && Player.rigid.velocity.y >= -0.0025f && !event_soft_lock.Play && Player.scanNPC != null)
            {
                if (ZKey.transform.localPosition.y >= 314.025f)
                {
                    LeftKey.transform.SetSiblingIndex(0);
                    RightKey.transform.SetSiblingIndex(1);
                    DownKey.transform.SetSiblingIndex(2);
                    UpKey.transform.SetSiblingIndex(3);
                    MKey.transform.SetSiblingIndex(4);
                    ZKey.transform.SetSiblingIndex(5);
                    XKey.transform.SetSiblingIndex(6);
                }

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(65, 315), 0.125f * (Time.deltaTime * 60));
                    MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(191, 315), 0.125f * (Time.deltaTime * 60));
                    UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                    XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, -61), 0.125f * (Time.deltaTime * 60));
                    CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, -61), 0.125f * (Time.deltaTime * 60));
                }
                else
                {
                    ZKey.transform.localPosition = new Vector2(65, 315);
                    MKey.transform.localPosition = new Vector2(191, 315);
                    UpKey.transform.localPosition = new Vector2(127, 190);
                    if (DownKey.transform.localPosition.y >= 189.025f)
                        DownKey.SetActive(false);
                    DownKey.transform.localPosition = new Vector2(127, 190);
                    XKey.transform.localPosition = new Vector2(65, -61);
                    CKey.transform.localPosition = new Vector2(191, -61);
                }
            }
            else if (GameManager.isAction)
            {
                if (!대화창선택지.activeSelf)
                {
                    LeftKey.transform.SetSiblingIndex(0);
                    RightKey.transform.SetSiblingIndex(1);
                    DownKey.transform.SetSiblingIndex(2);
                    UpKey.transform.SetSiblingIndex(3);
                    MKey.transform.SetSiblingIndex(4);
                    ZKey.transform.SetSiblingIndex(5);
                    XKey.transform.SetSiblingIndex(6);

                    if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                    {
                        ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                        MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                        UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                        if (DownKey.transform.localPosition.y >= 189.025f)
                            DownKey.SetActive(false);
                        DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(127, 190), 0.125f * (Time.deltaTime * 60));
                        XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, 65), 0.125f * (Time.deltaTime * 60));
                        CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, 65), 0.125f * (Time.deltaTime * 60));
                    }
                    else
                    {
                        ZKey.transform.localPosition = new Vector2(127, 190);
                        MKey.transform.localPosition = new Vector2(127, 190);
                        UpKey.transform.localPosition = new Vector2(127, 190);
                        if (DownKey.transform.localPosition.y >= 189.025f)
                            DownKey.SetActive(false);
                        DownKey.transform.localPosition = new Vector2(127, 190);
                        XKey.transform.localPosition = new Vector2(65, 65);
                        CKey.transform.localPosition = new Vector2(191, 65);
                    }
                }
                else
                {
                    LeftKey.transform.SetSiblingIndex(0);
                    RightKey.transform.SetSiblingIndex(1);
                    DownKey.transform.SetSiblingIndex(2);
                    UpKey.transform.SetSiblingIndex(3);
                    MKey.transform.SetSiblingIndex(4);
                    ZKey.transform.SetSiblingIndex(5);
                    XKey.transform.SetSiblingIndex(6);

                    if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                    {
                        ZKey.transform.localPosition = Vector2.Lerp(ZKey.transform.localPosition, new Vector2(127, 315), 0.125f * (Time.deltaTime * 60));
                        MKey.transform.localPosition = Vector2.Lerp(MKey.transform.localPosition, new Vector2(127, 315), 0.125f * (Time.deltaTime * 60));
                        UpKey.transform.localPosition = Vector2.Lerp(UpKey.transform.localPosition, new Vector2(65, 65), 0.125f * (Time.deltaTime * 60));
                        DownKey.SetActive(true);
                        DownKey.transform.localPosition = Vector2.Lerp(DownKey.transform.localPosition, new Vector2(191, 65), 0.125f * (Time.deltaTime * 60));
                        XKey.transform.localPosition = Vector2.Lerp(XKey.transform.localPosition, new Vector2(65, 190), 0.125f * (Time.deltaTime * 60));
                        CKey.transform.localPosition = Vector2.Lerp(CKey.transform.localPosition, new Vector2(191, 190), 0.125f * (Time.deltaTime * 60));
                    }
                    else
                    {
                        ZKey.transform.localPosition = new Vector2(127, 315);
                        MKey.transform.localPosition = new Vector2(127, 315);
                        UpKey.transform.localPosition = new Vector2(65, 65);
                        DownKey.SetActive(true);
                        DownKey.transform.localPosition = new Vector2(191, 65);
                        XKey.transform.localPosition = new Vector2(65, 190);
                        CKey.transform.localPosition = new Vector2(191, 190);
                    }
                }
            }

            if (!GameManager.isAction)
            {
                GameManager.XKey = false;
                GameManager.CKey = false;
            }

            if (phoneControllerHide)
            {
                대화창.sizeDelta = Vector2.Lerp(대화창.sizeDelta, new Vector2(1261.5f, 176), 0.125f * (Time.deltaTime * 60));
                대화창Text.sizeDelta = Vector2.Lerp(대화창Text.sizeDelta, new Vector2(4906, 585.1f), 0.125f * (Time.deltaTime * 60));

                if (!b)
                {
                    if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                        transform.localPosition = Vector2.Lerp(transform.localPosition, new Vector2(-1280 * 0.5f - 256, -PhoneControllerCanvas.sizeDelta.y * 0.5f), 0.125f * (Time.deltaTime * 60));
                    else
                        transform.localPosition = new Vector2(-1280 * 0.5f - 256, -PhoneControllerCanvas.sizeDelta.y * 0.5f);
                }
                else
                    transform.localPosition = new Vector2(-1280 * 0.5f - 256, -PhoneControllerCanvas.sizeDelta.y * 0.5f);

                if (transform.localPosition.x - (-1280 * 0.5f - 256) <= 0.05f)
                    b = true;

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    i = Mathf.Lerp(i, 0, 0.125f * (Time.deltaTime * 60));
                    i2 = Mathf.Lerp(i2, 1, 0.125f * (Time.deltaTime * 60));

                    mainCamera.rect = new Rect(i, 0, i2, 1);
                    벽Camera.rect = new Rect(i, 0, i2, 1);

                    i3 = Mathf.Lerp(i3, 0, 0.125f * (Time.deltaTime * 60));
                    if (i3 <= 0.01f)
                        i3 = 0;
                    PhoneControllerCamera.rect = new Rect(0, 0, i3, 1);
                }
                else
                {
                    i = 0;
                    i2 = 1;
                    i3 = 0;

                    mainCamera.rect = new Rect(i, 0, i2, 1);
                    벽Camera.rect = new Rect(i, 0, i2, 1);
                    PhoneControllerCamera.rect = new Rect(0, 0, i3, 1);
                }

            }
            else
            {
                대화창.sizeDelta = Vector2.Lerp(대화창.sizeDelta, new Vector2(1005.5f, 176), 0.125f * (Time.deltaTime * 60));
                대화창Text.sizeDelta = Vector2.Lerp(대화창Text.sizeDelta, new Vector2(3884, 585.1f), 0.125f * (Time.deltaTime * 60));

                if (!b)
                {
                    if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                        transform.localPosition = Vector2.Lerp(transform.localPosition, new Vector2(-1280 * 0.5f, -PhoneControllerCanvas.sizeDelta.y * 0.5f), 0.125f * (Time.deltaTime * 60));
                    else
                        transform.localPosition = new Vector2(-1280 * 0.5f, -PhoneControllerCanvas.sizeDelta.y * 0.5f);
                }
                if (b)
                    transform.localPosition = new Vector2(-1280 * 0.5f, -PhoneControllerCanvas.sizeDelta.y * 0.5f);

                if (transform.localPosition.x - (-1280 * 0.5f - 256) >= 255.05f)
                    b = true;

                if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
                {
                    i = Mathf.Lerp(i, 0.2f, 0.125f * (Time.deltaTime * 60));
                    i2 = Mathf.Lerp(i2, 0.8f, 0.125f * (Time.deltaTime * 60));
                    mainCamera.rect = new Rect(i, 0, i2, 1);
                    벽Camera.rect = new Rect(i, 0, i2, 1);
                    
                    i3 = Mathf.Lerp(i3, 0.2f, 0.125f * (Time.deltaTime * 60));

                    PhoneControllerCamera.rect = new Rect(0, 0, i3, 1);
                }
                else
                {
                    i = 0.2f;
                    i2 = 0.8f;
                    i3 = 0.2f;

                    mainCamera.rect = new Rect(i, 0, i2, 1);
                    벽Camera.rect = new Rect(i, 0, i2, 1);
                    PhoneControllerCamera.rect = new Rect(0, 0, i3, 1);
                }
            }
        }
    }
}
