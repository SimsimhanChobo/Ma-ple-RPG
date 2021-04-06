using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaruneBattleManager : MonoBehaviour
{
    public static int PlayerCount = 3;
    public int _PlayerCount = 3;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public static GameObject _Player1;
    public static GameObject _Player2;
    public static GameObject _Player3;

    public Vector3 tempPlayer1;
    public Vector3 tempPlayer2;
    public Vector3 tempPlayer3;

    public Quaternion tempPlayer12;
    public Quaternion tempPlayer22;
    public Quaternion tempPlayer32;

    bool tempGame3D = true;
    bool tempDeltaruneBattle = false;

    bool tempStartAni = false;
    public static bool StartAni = false;
    public static bool EndAni = false;

    public string BGM = "";
    public float BGMVol = 1;

    float Timer = 0;


    public static int TP = 0;
    public int _TP = 0;

    public RectTransform MainCameraSize;

    void Update()
    {
        TP = _TP;

        _Player1 = Player1;
        _Player2 = Player2;
        _Player3 = Player3;

        PlayerCount = _PlayerCount;

        if (Input.GetKeyDown(KeyCode.N))
            GameManager.DeltaruneBattle = !GameManager.DeltaruneBattle;

        if (GameManager.MainMenu)
        {
            StartAni = false;
            EndAni = false;
            GameManager.DeltaruneBattle = false;
        }

        if (TP > 100)
            TP = 100;
        else if (TP < 0)
            TP = 0;

        if (GameManager.DeltaruneBattle && tempDeltaruneBattle != GameManager.DeltaruneBattle)
        {
            tempGame3D = MainCamera.Camera.orthographic;
            tempPlayer1 = Player1.transform.position;
            tempPlayer2 = Player2.transform.position;
            tempPlayer3 = Player3.transform.position;

            tempPlayer12 = SkinRotation.PlayerObject.transform.localRotation;
            tempPlayer22 = Player2.transform.Find("Minecraft Player Skin").localRotation;
            tempPlayer32 = Player3.transform.Find("Minecraft Player Skin").localRotation;

            Timer = 0;
            tempStartAni = true;
            StartAni = true;
            SoundManager.StopAll(SoundType.BGM, false);
        }

        if (GameManager.DeltaruneBattle && StartAni)
        {
            EndAni = false;

            if (tempStartAni)
            {
                if (PlayerCount == 1)
                {
                    Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize)) - new Vector3(0, 0, 3), 0.25f * 60 * Time.deltaTime);

                    if (Vector2.Distance(Player1.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt((Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize)), "All", true);
                        
                        if (SkinRotation.PlayerObject.transform.localEulerAngles.y > 180)
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, SkinRotation.PlayerObject.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                    {
                        SoundManager.PlaySound("snd_weaponpull", 0.5f, 1);
                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        tempStartAni = false;
                    }
                }
                else if (PlayerCount == 2)
                {
                    if (Vector2.Distance(Player1.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(190 + Screen.width - MainCameraSize.sizeDelta.x, 550 * GameManager.GUISize))) < 0.1f && Vector2.Distance(Player2.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(220 + Screen.width - MainCameraSize.sizeDelta.x, 420 * GameManager.GUISize))) < 0.1f)
                    {
                        SoundManager.PlaySound("snd_weaponpull", 0.5f, 1);
                        tempStartAni = false;
                    }

                    Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(190 + Screen.width - MainCameraSize.sizeDelta.x, 550 * GameManager.GUISize)) - new Vector3(0, 0, 3), 0.25f * 60 * Time.deltaTime);
                    Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(220 + Screen.width - MainCameraSize.sizeDelta.x, 420 * GameManager.GUISize)) - new Vector3(0, 0, 4), 0.25f * 60 * Time.deltaTime);

                    if (Vector2.Distance(Player1.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(190 + Screen.width - MainCameraSize.sizeDelta.x, 550 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt((Vector2)Camera.main.ScreenToWorldPoint(new Vector2(190 + Screen.width - MainCameraSize.sizeDelta.x, 550 * GameManager.GUISize)), "All", true);

                        if (Player1.transform.localEulerAngles.y > 180)
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, SkinRotation.PlayerObject.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);

                    if (Vector2.Distance(Player2.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(220 + Screen.width - MainCameraSize.sizeDelta.x, 420 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt(Player2.transform.Find("Minecraft Player Skin").gameObject, (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(220 + Screen.width - MainCameraSize.sizeDelta.x, 420 * GameManager.GUISize)), "All", true);

                        if (Player2.transform.localEulerAngles.y > 180)
                            SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, Player2.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                        SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                }
                else if (PlayerCount == 3)
                {
                    if (Vector2.Distance(Player1.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(175 + Screen.width - MainCameraSize.sizeDelta.x, 567 * GameManager.GUISize))) < 0.1f && Vector2.Distance(Player2.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize))) < 0.1f && Vector2.Distance(Player3.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(230 + Screen.width - MainCameraSize.sizeDelta.x, 400 * GameManager.GUISize))) < 0.1f)
                    {
                        SoundManager.PlaySound("snd_weaponpull", 0.5f, 1);
                        tempStartAni = false;
                    }

                    Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(175 + Screen.width - MainCameraSize.sizeDelta.x, 567 * GameManager.GUISize)) - new Vector3(0, 0, 3), 0.25f * 60 * Time.deltaTime);
                    Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize)) - new Vector3(0, 0, 4), 0.25f * 60 * Time.deltaTime);
                    Player3.transform.position = Vector3.MoveTowards(Player3.transform.position, (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(230 + Screen.width - MainCameraSize.sizeDelta.x, 400 * GameManager.GUISize)) - new Vector3(0, 0, 5), 0.25f * 60 * Time.deltaTime);

                    if (Vector2.Distance(Player1.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(175 + Screen.width - MainCameraSize.sizeDelta.x, 567 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt((Vector2)Camera.main.ScreenToWorldPoint(new Vector2(175 + Screen.width - MainCameraSize.sizeDelta.x, 567 * GameManager.GUISize)), "All", true);

                        if (SkinRotation.PlayerObject.transform.localEulerAngles.y > 180)
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, SkinRotation.PlayerObject.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                        SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);

                    if (Vector2.Distance(Player2.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt(Player2.transform.Find("Minecraft Player Skin").gameObject, (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize)), "All", true);

                        if (Player2.transform.Find("Minecraft Player Skin").localEulerAngles.y > 180)
                            SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, Player2.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                        SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);

                    if (Vector2.Distance(Player3.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(230 + Screen.width - MainCameraSize.sizeDelta.x, 400 * GameManager.GUISize))) > 0.1f)
                    {
                        SkinRotation.skinLookAt(Player3.transform.Find("Minecraft Player Skin").gameObject, (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(230 + Screen.width - MainCameraSize.sizeDelta.x, 400 * GameManager.GUISize)), "All", true);

                        if (Player3.transform.Find("Minecraft Player Skin").localEulerAngles.y > 180)
                            SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                        else
                            SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

                        SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, Player3.transform.localRotation.eulerAngles.y, 0)), true);
                    }
                    else
                        SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                }
            }

            if (!tempStartAni)
                Timer += Time.deltaTime;
            if (Timer >= 0.5f)
            {
                Timer = 0;
                StartAni = false;
                SoundManager.PlayBGM(BGM, true, BGMVol, 1, true, false);
            }
        }
        else if (!GameManager.DeltaruneBattle && GameManager.DeltaruneBattle != tempDeltaruneBattle)
        {
            MinecraftSkyboxColorChange.CustomColor = false;
            MainCamera.Camera.orthographic = tempGame3D;
            SoundManager.StopAll(SoundType.BGM, false);
            EndAni = true;
        }
        else if (!GameManager.DeltaruneBattle && EndAni)
        {
            tempStartAni = false;
            StartAni = false;

            Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, tempPlayer1, 0.25f * 60 * Time.deltaTime);
            Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, tempPlayer2, 0.25f * 60 * Time.deltaTime);
            Player3.transform.position = Vector3.MoveTowards(Player3.transform.position, tempPlayer3, 0.25f * 60 * Time.deltaTime);

            SkinRotation.skinLookAt(tempPlayer1, "All", true);

            if (SkinRotation.PlayerObject.transform.localEulerAngles.y > 180)
                SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
            else
                SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

            SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, SkinRotation.PlayerObject.transform.localRotation.eulerAngles.y, 0)), true);

            SkinRotation.skinLookAt(Player2.transform.Find("Minecraft Player Skin").gameObject, tempPlayer2, "All", true);

            if (Player2.transform.Find("Minecraft Player Skin").localEulerAngles.y > 180)
                SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
            else
                SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

            SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, Player2.transform.localRotation.eulerAngles.y, 0)), true);

            SkinRotation.skinLookAt(Player3.transform.Find("Minecraft Player Skin").gameObject, tempPlayer2, "All", true);

            if (Player3.transform.Find("Minecraft Player Skin").localEulerAngles.y > 180)
                SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
            else
                SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, 90, 0)), true);

            SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, Player3.transform.localRotation.eulerAngles.y, 0)), true);

            if (Vector2.Distance(Player1.transform.position, tempPlayer1) < 0.1f && Vector2.Distance(Player2.transform.position, tempPlayer2) < 0.1f && Vector2.Distance(Player3.transform.position, tempPlayer3) < 0.1f)
            {
                EndAni = false;
                MainCamera.Camera.orthographic = tempGame3D;
                SkinRotation.PlayerObject.transform.localRotation = tempPlayer12;
                Player2.transform.Find("Minecraft Player Skin").localRotation = tempPlayer22;
                Player3.transform.Find("Minecraft Player Skin").localRotation = tempPlayer32;
                GameManager.SoundRestart = true;
            }

            if (Vector2.Distance(Player1.transform.position, tempPlayer1) < 0.1f)
                SkinRotation.PlayerObject.transform.localRotation = tempPlayer12;
            if (Vector2.Distance(Player2.transform.position, tempPlayer2) < 0.1f)
                Player2.transform.localRotation = tempPlayer22;
            if (Vector2.Distance(Player3.transform.position, tempPlayer3) < 0.1f)
                Player3.transform.localRotation = tempPlayer32;
        }

        if (GameManager.DeltaruneBattle)
        {
            MainCamera.Camera.orthographic = true;

            if (!StartAni)
            {
                SkinRotation.skinRotation("All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                SkinRotation.skinRotation(Player2.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);
                SkinRotation.skinRotation(Player3.transform.Find("Minecraft Player Skin").gameObject, "All", Quaternion.Euler(new Vector3(0, -90, 0)), true);

                if (PlayerCount == 1)
                    Player1.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize));
                else if (PlayerCount == 2)
                {
                    Player1.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(190 + Screen.width - MainCameraSize.sizeDelta.x, 550 * GameManager.GUISize));
                    Player2.transform.position = (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(220 + Screen.width - MainCameraSize.sizeDelta.x, 420 * GameManager.GUISize)) - new Vector3(0, 0, 4);
                }
                else if (PlayerCount == 3)
                {
                    Player1.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(175 + Screen.width - MainCameraSize.sizeDelta.x, 567 * GameManager.GUISize));
                    Player2.transform.position = (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(200 + Screen.width - MainCameraSize.sizeDelta.x, 480 * GameManager.GUISize)) - new Vector3(0, 0, 4);
                    Player3.transform.position = (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(new Vector2(230 + Screen.width - MainCameraSize.sizeDelta.x, 400 * GameManager.GUISize)) - new Vector3(0, 0, 5);
                }
            }
        }

        if (EndAni && !GameManager.DeltaruneBattle)
            MainCamera.Camera.orthographic = true;

        tempDeltaruneBattle = GameManager.DeltaruneBattle;
    }
}
