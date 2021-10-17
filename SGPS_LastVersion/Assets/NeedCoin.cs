using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedCoin : MonoBehaviour
{
    public GameObject NPC;// NPC를 담을 인스펙터 변수 창 -> 린 3D 소환하고 끌어다 놓으면 됨
    public GameObject Player; //플레이어를 담을 인스펙터 변수 창 -> Player 끌어다 놓으면 됨
    public float Distance_; // 두 오브젝트 간 거리변수
    public QuestManager Qmanager;
    public static bool isQuest = false;

    [SerializeField] public GameObject NeedBar; // 알림창에 대한 오브젝트 변수

    // Update is called once per frame
    void Update()
    {
        Distance_ = Vector3.Distance(NPC.transform.position, Player.transform.position);
        if (Distance_ < 3 && PlayerController.coinCount < 2 && Qmanager.questId == 20)
        {
            NeedBar.gameObject.SetActive(true);
            isQuest = true;
        }
        else if (Distance_ >= 3)
        {
            NeedBar.gameObject.SetActive(false);
        }
        if (PlayerController.coinCount >= 2)
        {
            isQuest = false;
        }
    }
}
