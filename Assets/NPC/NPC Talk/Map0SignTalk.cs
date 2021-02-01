using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map0SignTalk : MonoBehaviour
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
        대화창NpcName.NpcName = "";
        GameManager.gameManager.Talk("오른쪽에 구조물은 물리엔진 버그를 테스트 하는 장소입니다.");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.Talk("더 오른쪽으로 가면 파크모가 기다리고 있으니, 한번 Z키를 눌러서 말을 걸어보세요.");
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Z) || GameManager.ZKey || Input.GetKey(KeyCode.C) || GameManager.CKey) && !대화창TextEffect.isAnim);
        GameManager.gameManager.TalkEnd();
    }
}