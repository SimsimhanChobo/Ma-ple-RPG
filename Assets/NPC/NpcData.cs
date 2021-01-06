using System.Collections.Generic;
using UnityEngine;

public class NpcData : MonoBehaviour
{
    [Header("NPC Data")]
    [Tooltip("NPC Data")]
    public int NpcID;
    public int NpcMap;

    [Header("NPC Talk")]
    [TextArea, Tooltip("대화 메시지")]
    public List<string> NpcTalk = new List<string>();

    [Header("NPC Name Change")]

    [Tooltip("(무조건 한개는 있어야 닉네임이 표시됩니다 만약 한개도 없다면 닉네임이 표시되지 않습니다) 대화 메시지를 넘어간 횟수 > Int Npc Name Change[i] 라면 i를 1 증가시키고 Npc Name Change[i]라는 닉네임으로 대화 상대의 닉네임을 변경")]
    public int[] IntNpcNameChange;

    [TextArea, Tooltip("(무조건 Int Npc Name Change 랑 길이가 같아야합니다!) 만약 칸이 비어있다면 닉네임 표시가 되지 않습니다.")]
    public string[] NpcNameChange;
}
