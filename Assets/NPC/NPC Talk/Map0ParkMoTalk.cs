using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map0ParkMoTalk : MonoBehaviour
{
    IEnumerator Coroutine;

    void Update()
    {
        //이벤트 레이캐스트
        RaycastHit2D Event = Physics2D.Raycast(new Vector2(transform.position.x - 2, transform.position.y + 1 * 0.9f), new Vector3(4, 0, 0), 4, LayerMask.GetMask("Player"));

        if (Event.collider != null)
        {
            //NPC 이벤트 실행
            if (Input.GetButtonDown("Event") && !ChattingManager.ChattingActive && !InvManager.InventoryShow && !GameManager.isAction)
            {
                Player.scanNPC = gameObject;
                Coroutine = Talk();
                StartCoroutine(Coroutine);
            }
            else if (GameManager.ZKey && !GameManager.isAction)
            {
                Player.scanNPC = gameObject;
                StartCoroutine(Coroutine);
                GameManager.ZKey = false;
            }
            else if (GameManager.ZKey && !GameManager.isAction)
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
        GameManager.gameManager.Talk("최대 허기는 레벨업할때 아주 조금씩 늘어나! 어떤 행동을 하면 허기가 조금씩 달지\n(마인크래프트 시스템과 같으니, 위키를 참고해도 좋습니다)");
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
        yield return new WaitForSecondsRealtime(0.75f);
        대화창TextEffect.SetText("그건");
        yield return new WaitForSecondsRealtime(0.75f);
        대화창TextEffect.SetText("그건.");
        yield return new WaitForSecondsRealtime(0.75f);
        대화창TextEffect.SetText("그건..");
        yield return new WaitForSecondsRealtime(0.75f);
        대화창TextEffect.SetText("그건...");
        yield return new WaitForSecondsRealtime(0.75f);
        GameManager.gameManager.Talk("나도 모르겠어!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("재밌게 놀아!");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.TalkEnd();
    }
}
