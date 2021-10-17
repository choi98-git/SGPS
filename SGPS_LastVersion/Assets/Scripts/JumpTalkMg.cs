using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpTalkMg : MonoBehaviour
{
    public JumpN npcManager;
    public GameObject talkPanel;
    public JumpQuest Qmanager;
    public Text talkText;
    public GameObject scanNpc;
    public int talkIndex;
    public bool isAction; // 대화 중인지 아닌지 판별

    // Update is called once per frame
    public void Action(GameObject scanObj) // 대화 시스템 활성화 함수
    {
        scanNpc = scanObj;
        objData objData = scanNpc.GetComponent<objData>();
        Talk(objData.id, objData.isNpc);
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc) // 대화 중
    {
        int questTalkIndex = Qmanager.GetQuestTalkIndex(id); //호출할 퀘스트값 저장
        string talkData = npcManager.GetTalk(id + questTalkIndex, talkIndex); //호출할 대화 내용 저장

        if (talkData == null) //대화가 끝났다면
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            Debug.Log("NPC가 아닙니다.");
        }
        isAction = true;
        talkIndex++;
    }
}
