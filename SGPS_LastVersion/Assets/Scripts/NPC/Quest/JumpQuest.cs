using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpQuest : MonoBehaviour
{
    public int questId; //퀘스트 번호
    public int questActionIndex; //현재 퀘스트 대화 위치 번호


    Dictionary<int, QuestData> questList; //퀘스트를 저장하고 관리할 딕셔너리

    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData() // 인게임에서 이용할 퀘스트 생성
    {
        questList.Add(10, new QuestData("점프맵을 통과하라!", new int[] { 1000 })); //10번은 퀘스트 ID
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++; //퀘스트 ID가 일치하면 대화 진행

        if (questActionIndex == questList[questId].npcId.Length)
            Next(); // 현재 대화 번호가 전체 대화 길이하고 같아지면 Next() 함수 실행

        return questList[questId].questName;
    }

    void Next() //다음 퀘스트로 넘어가기 위한 함수
    {
        questId = 20;
        questActionIndex = 0;

    }
}
