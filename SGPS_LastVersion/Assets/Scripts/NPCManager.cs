using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
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
        talkData.Add(10+1000, new string[] { "안녕?", "이 곳에 처음 왔구나?", "궁금한게 많겠지만 공짜는 없어~", "코인 2개를 가져다주면 정보를 줄게!"});
        //NPCID + QuestID를 더한 값이 새로운 key가 되어 대화 내용이라는 value를 가져온다.
        //Quest Talk
        talkData.Add(20+1000, new string[] { "오 코인이잖아? 고마워!", "여긴 너의 무의식이 만들어낸 세계", 
            "일상이 지루하다 느낀 나머지 이런 느작없는 곳에 떨어지고 만거지~", "이 공간 어딘가에 떨어진 쪽지가 있을거야", "그를 통해 너의 앞 길을 찾아봐"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
