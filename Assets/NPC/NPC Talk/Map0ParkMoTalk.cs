using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map0ParkMoTalk : MonoBehaviour
{
    IEnumerator Coroutine;

    public Image Background;
    public Image Background2;
    public Text MagicText;
    public RectTransform Ray;

    public GameObject PlayerSkin;

    void Update()
    {
        //이벤트 레이캐스트
        RaycastHit2D Event = Physics2D.Raycast(new Vector2(transform.position.x - 2, transform.position.y + 1 * 0.9f), new Vector3(4, 0, 0), 4, LayerMask.GetMask("Player"));

        if (Event.collider != null)
        {
            //NPC 이벤트 실행
            if (Input.GetButtonDown("Event") && !ChattingManager.ChattingActive && !InvManager.InventoryShow && !GameManager.isAction && !GameManager.talkStop)
            {
                Player.scanNPC = gameObject;
                Coroutine = Talk();
                StartCoroutine(Coroutine);
            }
            else if (GameManager.ZKey && !GameManager.isAction && !GameManager.talkStop)
            {
                Player.scanNPC = gameObject;
                StartCoroutine(Coroutine);
                GameManager.ZKey = false;
            }
            else if (GameManager.ZKey && !GameManager.isAction && !GameManager.talkStop)
            {
                Player.scanNPC = gameObject;
                GameManager.ZKey = false;
            }
        }
    }

    IEnumerator Talk()
    {
        대화창NpcName.NpcName = "파크모";
        GameManager.gameManager.Talk("잘했어! Z키를 누르면 지금처럼 다른 NPC 또는 몹, 건물과 상호작용이 가능하니까 잘 기억해둬!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("ESC를 눌러서 각종 설정을 할수가 있고\n세이브 파일을 저장할수도 있어!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("M키를 누르면 메인화면으로 가져");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("HP가 0이 되면 게임오버가 되고 메인화면으로가\n그래도 안심해! 데이터는 초기화 되지 않아!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("물론 방금전에 했던 맵은 처음부터 다시해야 할거야...");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("최대 허기는 레벨업할때 아주 조금씩 늘어나! 어떤 행동을 하면 허기가 조금씩 달지\n (마인크래프트 시스템과 같으니, 위키를 참고해도 좋습니다)");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("이쯤에서 내 설명은 끝났어!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("이번에 할말은 제작자의 말이야!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        대화창NpcName.NpcName = "제작자";
        GameManager.gameManager.Talk("이 허접한 게임을 플레이 해주셔서 감사합니다! 방금 파크모가 게임 시스템의 설명은 다 했으니,\n더이상의 설명은 필요 없을것같네요! 재밌게 플레이 해주세요!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        대화창NpcName.NpcName = "파크모";
        GameManager.gameManager.Talk("아참 X키를 누르면 대사 애니메이션을 스킵할수 있으니, 말이 지루하거나 애니메이션이 느리다고 생각하는 사람은\nX키를 누르면 한결 나아질거야!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("그리고 C키를 누르면 대사를 완전히 스킵할수 있어! 이미 봤던 대사를 다시 볼때는 C키를 길게 누르면 편해(델타룬이랑 동일)");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("아, 왜 대사 스킵을 마지막에 설명했냐고?");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        대화창TextEffect.SetText("그");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("그건");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("그건.");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("그건..");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("그건...");
        yield return new WaitForSecondsRealtime(0.06f);
        GameManager.gameManager.Talk("나도 모르겠어!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("그리고 이 세상은 다른 세상에 있는것들이 종합된 세상이야! 재일 많이 분포하고 있는거는 마인크래프트지");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("뭐.. 이 세상에 있는 것중에 예를 몇가지 들어보자면");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("언더테일이나");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        대화창TextEffect.SetText("동");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("동방");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("동방프");
        yield return new WaitForSecondsRealtime(0.06f);
        대화창TextEffect.SetText("동방프로");
        yield return new WaitForSecondsRealtime(0.06f);


        BeatManager.beatManager.NextBeatRestart();
        GameManager.Boss = true;
        SoundManager.StopAll(SoundType.BGM, true);
        SoundManager.PlayBGM("사랑색 마스터 스파크", true, 0.3f, 1, true, true);
        GameManager.BossMaxHP = 100;
        GameManager.BossHP = 35;
        GameManager.BPM = 169;
        GameManager.StartDelay = 0.1f;

        RectTransform rectTransform = MagicText.gameObject.GetComponent<RectTransform>();
        RectTransform rectTransform2 = Background.GetComponent<RectTransform>();
        RectTransform rectTransform3 = Background2.GetComponent<RectTransform>();
        MagicText.text = "마포 「파이널 마스터 스파크」";
        MagicText.color = new Color(1, 1, 1, 0);
        MagicText.transform.localScale = new Vector3(2, 2, 2);
        MagicText.rectTransform.anchoredPosition = new Vector2(0, -Screen.height + 150);
        Background.color = new Color(1, 1, 1, 0);
        Ray.localEulerAngles = new Vector3(0, 0, 355);
        Ray.sizeDelta = new Vector2(0, 0);

        float Timer = 0;
        float Timer2 = 0;
        float Timer3 = 0;
        bool b = false;
        bool bb = false;
        Outline outline = Ray.GetComponents<Outline>()[0];
        Outline outline2 = Ray.GetComponents<Outline>()[1];

        GameManager.gameManager.TalkEnd();
        GameManager.talkStop = true;
        Player.PlayerNotMove = true;

        rectTransform3.anchoredPosition = new Vector3(0, 50);
        Background2.color = new Color(1, 1, 1, 0);
        while (true)
        {
            yield return null;
            GameManager.BossHP -= 0.085f * 60 * Time.deltaTime;
            GameManager.gameManager.BossHPBar.maxValue = GameManager.BossMaxHP;
            GameManager.gameManager.BossHPBar.value = Mathf.Lerp(GameManager.gameManager.BossHPBar.value, GameManager.BossHP, 0.1f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed));

            Timer2 += Time.deltaTime;

            if (MagicText.transform.localScale.x > 1)
            {
                MagicText.transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f) * 60 * Time.deltaTime;
                MagicText.color += new Color(0, 0, 0, 0.04f) * 60 * Time.deltaTime;
            }

            if (MagicText.transform.localScale.x <= 1 && Timer < 1.5f)
            {
                MagicText.transform.localScale = Vector3.one;
                MagicText.color = Color.white;
                Timer += Time.deltaTime;
            }
            else if (Timer >= 1.5f)
            {
                if (Vector2.Distance(rectTransform.anchoredPosition, new Vector2(0, -15)) < 0.05f)
                {
                    Timer += Time.deltaTime;
                    if (Timer >= 2)
                        MagicText.color -= new Color(0, 0, 0, 0.04f) * 60 * Time.deltaTime;
                }
                else
                {
                    MagicText.transform.localScale = Vector3.one;
                    MagicText.color = Color.white;
                    rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(0, -15), 0.05f * 60 * Time.deltaTime);
                }
            }

            if (Background.color.a > 1)
                Background.color += new Color(0, 0, 0, 0.01f) * 60 * Time.deltaTime;
            else
                Background.color = new Color(1, 1, 1, 1);

            rectTransform2.anchoredPosition += new Vector2(0, 1.5f) * 60 * Time.deltaTime;
            rectTransform2.sizeDelta += new Vector2(0, 3) * 60 * Time.deltaTime;

            if (rectTransform2.anchoredPosition.y > 136)
            {
                rectTransform2.anchoredPosition = new Vector2(0, 0);
                rectTransform2.sizeDelta = new Vector2(0, 0);
            }

            MinecraftSkyboxColorChange.CustomColor = true;
            MinecraftSkyboxColorChange.CustomColorTop = new Color(0.5333334f, 0.2431373f, 0.3215686f);
            MinecraftSkyboxColorChange.CustomColorBottom = new Color(0.5333334f, 0.2431373f, 0.3215686f);

            if (Timer2 >= 2 && !b)
            {
                SoundManager.PlaySound("마스터 스파크", 0.25f, 1);
                b = true;
            }
            if (Timer2 >= 2 && Timer2 < 3.5f)
                Ray.sizeDelta = Vector2.MoveTowards(Ray.sizeDelta, new Vector2(1850, 5), 20f * 60 * Time.deltaTime);
            if (Timer2 >= 3.5f && Ray.sizeDelta.y < 200)
                Ray.sizeDelta += new Vector2(0, 5 * 60 * Time.deltaTime);
            if (Timer2 >= 3.5f && Ray.sizeDelta.y >= 200)
                Ray.sizeDelta = new Vector2(1850, 200);
            if (Timer2 >= 4.1f)
                Ray.localEulerAngles = Vector3.MoveTowards(Ray.localEulerAngles, new Vector3(0, 0, 270), 0.5f * 60 * Time.deltaTime);
            if (Vector3.Distance(Ray.localEulerAngles, new Vector3(0, 0, 270)) < 0.01f)
                break;

            outline.effectDistance = new Vector2(0, Ray.sizeDelta.y * 0.15f);
            outline2.effectDistance = new Vector2(0, Ray.sizeDelta.y * 0.15f);

            Background2.transform.localPosition -= new Vector3(0, 2, 0);
            if (!bb)
                Background2.color += new Color(0, 0, 0, 0.01f * 60 * Time.deltaTime);
            if (!bb && Background2.color.a >= 0.8f)
            {
                Timer3 += Time.deltaTime;
                Background2.color = new Color(1, 1, 1, 0.8f);
                
                if (Timer3 >= 1)
                    bb = true;
            }
            if (bb)
                Background2.color -= new Color(0, 0, 0, 0.01f * 60 * Time.deltaTime);
        }
        MinecraftSkyboxColorChange.CustomColor = false;
        GameManager.Boss = false;
        SoundManager.StopAll(SoundType.All, false);
        GameManager.SoundRestart = true;
        Background.color = new Color(1, 1, 1, 0);
        GameManager.talkStop = false;
        Player.PlayerNotMove = false;


        GameManager.gameManager.Talk("... 미안해 잠깐만 기다려봐");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.TalkEnd();
        PlayerSkin.SetActive(false);
        GameManager.talkStop = true;
        Player.PlayerNotMove = true;
        yield return new WaitForSeconds(5);
        PlayerSkin.SetActive(true);
        GameManager.talkStop = false;
        Player.PlayerNotMove = false;
        GameManager.gameManager.Talk("여기서 싸우지 말고 다른데가서 싸우라고 했어");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("자.. 그래서 하던말을 마저 하면");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("동방 프로젝트나, 델타룬, 슈퍼마리오 메이커 2가 있지");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("말이 너무 길어진것같네 미안해");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("재밌게 놀아!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.TalkEnd();
    }
}
