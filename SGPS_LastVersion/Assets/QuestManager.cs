using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId = 10;
    public int questActionIndex;

    Dictionary<int, QuestData> questList; //퀘스트를 저장하고 관리할 딕셔너리

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData() // 인게임에서 이용할 퀘스트 생성
    {
        questList.Add(10, new QuestData("코인 2개 수집!", new int[] { 1000 })); //10번은 퀘스트 ID
        //{}에는 해당 퀘스트와 관련된 npcID 기입
        questList.Add(20, new QuestData("쪽지를 찾아 떠나라!", new int[] { 1000 }));

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
