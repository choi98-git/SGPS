using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpN : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // 대화 내용을 저장할 딕셔너리

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000 + 10, new string[] { "오! 오랜만에 다시 보네?", "무사히 여기까지 왔구나 축하해", "하지만 아직 좀 더 가야해 이 앞을 봐!", "문제를 해결하고 조심히 건너서 저 앞에 문까지 가봐!" });
        //NPCID + QuestID를 더한 값이 새로운 key가 되어 대화 내용이라는 value를 가져온다.
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
