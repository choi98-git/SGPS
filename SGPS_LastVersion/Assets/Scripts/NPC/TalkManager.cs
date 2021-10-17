using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public NPCManager npcManager;
    public GameObject talkPanel;
    public QuestManager Qmanager;
    public Text talkText;
    public Text questText;
    public GameObject questBar;
    public GameObject scanNpc;
    public int talkIndex;
    public bool isAction; // 대화 중인지 아닌지 판별
    private AudioSource theAudio;
    [SerializeField] private AudioClip questSound;

    private void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

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
            questBar.gameObject.SetActive(true);
            Qmanager.CheckQuest(id);
            if (RayZ.cnt >= 5 && RayZ.cnt <= 8)
            {
                PlaySE(questSound);
                questText.text = "Main Quest";
                questText.text = "코인 2개 수집하시오";
            }
            else if (RayZ.cnt >= 9 && PlayerController.coinCount >= 2)
            {
                PlaySE(questSound);
                questText.text = "쪽지를 찾아 떠나라!";
            }
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

    private void PlaySE(AudioClip _clip)
    {
        theAudio.clip = _clip;
        theAudio.Play();
    }
}
