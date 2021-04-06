using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaruneBattleUIManager : MonoBehaviour
{
    public Sprite Player1Face;
    public Sprite Player2Face;
    public Sprite Player3Face;

    Image Player1Face2;
    Image Player2Face2;
    Image Player3Face2;

    public string Player1Name;
    public string Player2Name;
    public string Player3Name;

    Text Player1Name2;
    Text Player2Name2;
    Text Player3Name2;

    public Color Player1Color;
    public Color Player2Color;
    public Color Player3Color;

    Text Player1HP;
    Text Player2HP;
    Text Player3HP;

    Text Player1MaxHP;
    Text Player2MaxHP;
    Text Player3MaxHP;

    Image Player1HPBar;
    Image Player2HPBar;
    Image Player3HPBar;

    RectTransform PlayerBG;
    RectTransform TalkBG;

    RectTransform Player1;
    RectTransform Player2;
    RectTransform Player3;

    RectTransform TP2;
    Text TP;
    float tempTP;
    Image TPWhite;
    Image TPRed;
    Image TPYellow;

    public RectTransform MainCameraSize;

    void Awake()
    {
        TalkBG = transform.Find("Talk BG").GetComponent<RectTransform>();
        PlayerBG = transform.Find("Player BG").GetComponent<RectTransform>();

        Player1Face2 = transform.Find("Player 1").Find("Player").Find("Face").GetComponent<Image>();
        Player2Face2 = transform.Find("Player 2").Find("Player").Find("Face").GetComponent<Image>();
        Player3Face2 = transform.Find("Player 3").Find("Player").Find("Face").GetComponent<Image>();

        Player1Name2 = transform.Find("Player 1").Find("Player").Find("Name").GetComponent<Text>();
        Player2Name2 = transform.Find("Player 2").Find("Player").Find("Name").GetComponent<Text>();
        Player3Name2 = transform.Find("Player 3").Find("Player").Find("Name").GetComponent<Text>();

        Player1 = transform.Find("Player 1").GetComponent<RectTransform>();
        Player2 = transform.Find("Player 2").GetComponent<RectTransform>();
        Player3 = transform.Find("Player 3").GetComponent<RectTransform>();

        Player1HP = transform.Find("Player 1").Find("HP").Find("HP Text").GetComponent<Text>();
        Player2HP = transform.Find("Player 2").Find("HP").Find("HP Text").GetComponent<Text>();
        Player3HP = transform.Find("Player 3").Find("HP").Find("HP Text").GetComponent<Text>();

        Player1MaxHP = transform.Find("Player 1").Find("HP").Find("Max HP Text").GetComponent<Text>();
        Player2MaxHP = transform.Find("Player 2").Find("HP").Find("Max HP Text").GetComponent<Text>();
        Player3MaxHP = transform.Find("Player 3").Find("HP").Find("Max HP Text").GetComponent<Text>();

        Player1HPBar = transform.Find("Player 1").Find("HP").Find("BG").Find("HP").GetComponent<Image>();
        Player2HPBar = transform.Find("Player 2").Find("HP").Find("BG").Find("HP").GetComponent<Image>();
        Player3HPBar = transform.Find("Player 3").Find("HP").Find("BG").Find("HP").GetComponent<Image>();

        TP2 = transform.Find("TP").GetComponent<RectTransform>();
        TP = transform.Find("TP").Find("Text").GetComponent<Text>();
        TPWhite = transform.Find("TP").Find("TP White").GetComponent<Image>();
        TPRed = transform.Find("TP").Find("TP Red").GetComponent<Image>();
        TPYellow = transform.Find("TP").Find("TP Yellow").GetComponent<Image>();
    }

    void Update()
    {
        Player1Face2.sprite = Player1Face;
        Player2Face2.sprite = Player2Face;
        Player3Face2.sprite = Player3Face;

        Player1Name2.text = Player1Name;
        Player2Name2.text = Player2Name;
        Player3Name2.text = Player3Name;

        if (GameManager.PlayerHP != 0.0001f)
        {
            Player1HP.text = "" + (long)GameManager.PlayerHP;
            Player1MaxHP.text = "" + (long)GameManager.PlayerMaxHP;
            Player1HPBar.fillAmount = GameManager.PlayerHP / GameManager.PlayerMaxHP;
        }

        Player1Face2.color = Player1Color;
        Player1HPBar.color = Player1Color;

        Player2HP.text = "" + (long)DeltaruneBattleManager._Player2.GetComponent<EntitySetting>().HP;
        Player2MaxHP.text = "" + (long)DeltaruneBattleManager._Player2.GetComponent<EntitySetting>().MaxHP;
        Player2Face2.color = Player2Color;
        Player2HPBar.color = Player2Color;
        Player2HPBar.fillAmount = DeltaruneBattleManager._Player2.GetComponent<EntitySetting>().HP / DeltaruneBattleManager._Player2.GetComponent<EntitySetting>().MaxHP;

        Player3HP.text = "" + (long)DeltaruneBattleManager._Player3.GetComponent<EntitySetting>().HP;
        Player3MaxHP.text = "" + (long)DeltaruneBattleManager._Player3.GetComponent<EntitySetting>().MaxHP;
        Player3Face2.color = Player3Color;
        Player3HPBar.color = Player3Color;
        Player3HPBar.fillAmount = DeltaruneBattleManager._Player3.GetComponent<EntitySetting>().HP / DeltaruneBattleManager._Player3.GetComponent<EntitySetting>().MaxHP;

        tempTP = Mathf.MoveTowards(tempTP, DeltaruneBattleManager.TP * 0.01f, 0.03f * 60 * Time.deltaTime);

        if (tempTP < 100)
        {
            TP.text = (int)Mathf.Round(tempTP * 100) + "\n %";
            TP.color = Color.white;
        }
        else
        {
            TP.text = "M\n A\n  X";
            TP.color = Color.yellow;
        }

        TPWhite.fillAmount -= 0.015f * 60 * Time.deltaTime;
        TPYellow.fillAmount += 0.015f * 60 * Time.deltaTime;
        TPRed.fillAmount = 0;

        if (TPWhite.fillAmount < DeltaruneBattleManager.TP / 100f)
            TPWhite.fillAmount = DeltaruneBattleManager.TP / 100f;

        if (TPYellow.fillAmount > DeltaruneBattleManager.TP / 100f - 0.01f)
        {
            TPYellow.fillAmount = DeltaruneBattleManager.TP / 100f - 0.01f;
            TPRed.fillAmount = TPWhite.fillAmount - 0.01f;
        }

        if (GameManager.DeltaruneBattle && !DeltaruneBattleManager.StartAni)
        {
            MinecraftSkyboxColorChange.CustomColor = true;
            MinecraftSkyboxColorChange.CustomColorTop = Color.black;
            MinecraftSkyboxColorChange.CustomColorBottom = Color.black;

            TalkBG.anchoredPosition = Vector2.Lerp(TalkBG.anchoredPosition, Vector2.zero, 0.125f * 60 * Time.deltaTime);
            PlayerBG.anchoredPosition = Vector2.Lerp(PlayerBG.anchoredPosition, new Vector2(0, 230), 0.125f * 60 * Time.deltaTime);

            TP2.anchoredPosition = Vector2.Lerp(TP2.anchoredPosition, new Vector2(103, 185), 0.125f * 60 * Time.deltaTime);

            Player1.sizeDelta = new Vector2(((Screen.width / 3) - (Screen.width - MainCameraSize.sizeDelta.x) / 3) * (1f / GameManager.GUISize), 76.2f);
            Player2.sizeDelta = new Vector2(((Screen.width / 3) - (Screen.width - MainCameraSize.sizeDelta.x) / 3) * (1f / GameManager.GUISize), 76.2f);
            Player3.sizeDelta = new Vector2(((Screen.width / 3) - (Screen.width - MainCameraSize.sizeDelta.x) / 3) * (1f / GameManager.GUISize), 76.2f);

            if (DeltaruneBattleManager.PlayerCount == 1)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(426.6667f * (Screen.width / 1280f * (1f / GameManager.GUISize)), 230), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = new Vector2(0, 230);
                Player3.anchoredPosition = new Vector2(0, 230);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(false);
                Player3.gameObject.SetActive(false);
            }
            else if (DeltaruneBattleManager.PlayerCount == 2)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(213.3333f * (Screen.width / 1280f * (1f / GameManager.GUISize)), 230), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = Vector2.Lerp(Player2.anchoredPosition, new Vector2(213.3333f * (Screen.width / 1280f * (1f / GameManager.GUISize)), 230), 0.125f * 60 * Time.deltaTime);
                Player3.anchoredPosition = new Vector2(0, 230);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(false);
            }
            else if (DeltaruneBattleManager.PlayerCount == 3)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(0, 230), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = Vector2.Lerp(Player2.anchoredPosition, new Vector2(0, 230), 0.125f * 60 * Time.deltaTime);
                Player3.anchoredPosition = Vector2.Lerp(Player3.anchoredPosition, new Vector2(0, 230), 0.125f * 60 * Time.deltaTime);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(true);
            }
        }
        else if (!GameManager.DeltaruneBattle || DeltaruneBattleManager.StartAni)
        {
            TalkBG.anchoredPosition = Vector2.Lerp(TalkBG.anchoredPosition, new Vector2(0, -230), 0.125f * 60 * Time.deltaTime);
            PlayerBG.anchoredPosition = Vector2.Lerp(PlayerBG.anchoredPosition, new Vector2(0, -300), 0.125f * 60 * Time.deltaTime);

            TP2.anchoredPosition = Vector2.Lerp(TP2.anchoredPosition, new Vector2(-26, 185), 0.125f * 60 * Time.deltaTime);

            if (DeltaruneBattleManager.PlayerCount == 1)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(426.6667f * (Screen.width / 1280f * (1f / GameManager.GUISize)), -400), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = new Vector2(0, 230);
                Player3.anchoredPosition = new Vector2(0, 230);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(false);
                Player3.gameObject.SetActive(false);
            }
            else if (DeltaruneBattleManager.PlayerCount == 2)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(213.3333f * (Screen.width / 1280f * (1f / GameManager.GUISize)), -400), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = Vector2.Lerp(Player2.anchoredPosition, new Vector2(213.3333f * (Screen.width / 1280f * (1f / GameManager.GUISize)), -400), 0.125f * 60 * Time.deltaTime);
                Player3.anchoredPosition = new Vector2(0, 230);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(false);
            }
            else if (DeltaruneBattleManager.PlayerCount == 3)
            {
                Player1.anchoredPosition = Vector2.Lerp(Player1.anchoredPosition, new Vector2(0, -400), 0.125f * 60 * Time.deltaTime);
                Player2.anchoredPosition = Vector2.Lerp(Player2.anchoredPosition, new Vector2(0, -400), 0.125f * 60 * Time.deltaTime);
                Player3.anchoredPosition = Vector2.Lerp(Player3.anchoredPosition, new Vector2(0, -400), 0.125f * 60 * Time.deltaTime);

                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(true);
            }
        }
    }
}
