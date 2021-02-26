using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map0운터의숙소문운터Talk : MonoBehaviour
{
    public Image BlackImage;
    IEnumerator Coroutine;

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
        대화창NpcName.NpcName = "운터";
        GameManager.gameManager.Talk("안녕 여긴 숙소라고 해");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("여기서 100 골드를 내고 하룻밤을 자면\nHP랑 HG가 채워져!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        yield return new WaitForSecondsRealtime(0.02f);
        GameManager.gameManager.Talk("한번 자볼래?");

        NpcEventManager.Select("네\n아니요\n?", 3);
        while (!Input.GetKeyDown(KeyCode.Z) && !GameManager.ZKey)
        {
            yield return null;
            NpcEventManager.SelectMove();
        }
        NpcEventManager.SelectEnd();
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);

        if (GameManager.EventSelection == 0)
        {
            if (GameManager.PlayerGold >= 100)
            {
                GameManager.gameManager.Talk("잘자!");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);

                GameManager.Pause = true;
                for (float i = 0; i <= 1; i += 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed))
                {
                    yield return null;
                    BlackImage.color = new Color(0, 0, 0, i);
                }
                yield return new WaitForSecondsRealtime(1);
                for (float i = 1; i >= 0; i -= 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed))
                {
                    yield return null;
                    BlackImage.color = new Color(0, 0, 0, i);
                }
                GameManager.PlayerHP = GameManager.PlayerMaxHP;
                GameManager.PlayerHG += GameManager.PlayerMaxHG / 100 * 30;
                GameManager.PlayerGold -= 100;
                GameManager.Pause = false;
                GameManager.gameManager.Talk("다음에 필요하면 또 와!");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            }
            else
            {
                GameManager.gameManager.Talk("으음..");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
                GameManager.gameManager.Talk("돈이 없는것 같은데?");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            }
        }
        else if (GameManager.EventSelection == 1)
        {
            GameManager.gameManager.Talk("필요하면 나중에 다시 와줘!");
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        }
        else if (GameManager.EventSelection == 2)
        {
            GameManager.gameManager.Talk("어...");
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            GameManager.gameManager.Talk("그니까...");
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            GameManager.gameManager.Talk("(내가 뭘 해야할까...?)");
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            GameManager.gameManager.Talk("(그렇지!)");
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            GameManager.gameManager.Talk("알갰어 무료로 해달라는거지?");

            NpcEventManager.Select("그렇지 그쯤은 돼야지\n??", 2);
            while (!Input.GetKeyDown(KeyCode.Z) && !GameManager.ZKey)
            {
                yield return null;
                NpcEventManager.SelectMove();
            }
            NpcEventManager.SelectEnd();
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);

            if (GameManager.EventSelection == 0)
            {
                GameManager.gameManager.Talk("(역시 무료였구만)");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
                GameManager.gameManager.Talk("잘자!");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);

                GameManager.Pause = true;
                for (float i = 0; i <= 1; i += 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed))
                {
                    yield return null;
                    BlackImage.color = new Color(0, 0, 0, i);
                }
                yield return new WaitForSecondsRealtime(1);
                for (float i = 1; i >= 0; i -= 0.01f * (60 * Time.unscaledDeltaTime * GameManager.GameSpeed))
                {
                    yield return null;
                    BlackImage.color = new Color(0, 0, 0, i);
                }
                GameManager.PlayerHP = GameManager.PlayerMaxHP;
                GameManager.PlayerHG += GameManager.PlayerMaxHG / 100 * 30;
                GameManager.Pause = false;
                GameManager.gameManager.Talk("다음에 필요하면 또 와!");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            }
            else if (GameManager.EventSelection == 1)
            {
                GameManager.gameManager.Talk("(이게 아니였나...)");
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
            }
        }
        GameManager.gameManager.TalkEnd();
    }
}

